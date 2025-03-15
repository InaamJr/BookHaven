using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using BookHaven.Data.Models;

namespace BookHaven.Data.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly string _connectionString = "Server=DESKTOP-KVP3P8D\\MSSQLSERVER2022;Database=BookHaven;Integrated Security=True;TrustServerCertificate=True;";

        // Get Sales Report Data (Filtered by Date Range)
        public List<SalesTransactionReportModel> GetSalesReport(DateTime startDate, DateTime endDate)
        {
            List<SalesTransactionReportModel> salesReports = new List<SalesTransactionReportModel>();

            string query = @"
                SELECT TransactionID, TransactionDate, TotalAmount, PaymentMethod, UserID
                FROM SalesTransaction
                WHERE TransactionDate BETWEEN @StartDate AND @EndDate
                ORDER BY TransactionDate DESC";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        salesReports.Add(new SalesTransactionReportModel
                        {
                            TransactionID = reader.GetInt32(0),
                            TransactionDate = reader.GetDateTime(1),
                            TotalAmount = reader.GetDecimal(2),
                            PaymentMethod = reader.GetString(3),
                            UserID = reader.GetGuid(4)
                        });
                    }
                }
            }
            return salesReports;
        }

        // Get Inventory Report (Book Stock Levels)
        public List<InventoryReportModel> GetInventoryReport()
        {
            List<InventoryReportModel> inventoryReports = new List<InventoryReportModel>();

            string query = @"
                SELECT b.BookID, b.Title, b.StockQuantity, b.Price, s.Name AS SupplierName 
                FROM Book b
                LEFT JOIN Supplier s ON b.SupplierID = s.SupplierID
                ORDER BY b.StockQuantity ASC"; // Sorted by lowest stock

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        inventoryReports.Add(new InventoryReportModel
                        {
                            BookID = reader.GetGuid(0),
                            Title = reader.GetString(1),
                            StockQuantity = reader.GetInt32(2),
                            Price = reader.GetDecimal(3),
                            SupplierName = reader.IsDBNull(4) ? "N/A" : reader.GetString(4)
                        });
                    }
                }
            }
            return inventoryReports;
        }

        // 📌 Get Staff Performance Report
        public List<StaffPerformanceReportModel> GetStaffPerformanceReport()
        {
            List<StaffPerformanceReportModel> staffPerformanceReports = new List<StaffPerformanceReportModel>();

            string query = @"
                SELECT u.Username, COUNT(s.TransactionID) AS SalesCount, SUM(s.TotalAmount) AS TotalSales
                FROM SalesTransaction s
                JOIN [User] u ON s.UserID = u.UserID
                GROUP BY u.Username
                ORDER BY TotalSales DESC"; // Highest sales first

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        staffPerformanceReports.Add(new StaffPerformanceReportModel
                        {
                            StaffName = reader.GetString(0),
                            SalesCount = reader.GetInt32(1),
                            TotalSales = reader.GetDecimal(2)
                        });
                    }
                }
            }
            return staffPerformanceReports;
        }

        public decimal GetTotalSalesForPeriod(string reportType)
        {
            string query = "";

            if (reportType == "Daily")
                query = "SELECT SUM(TotalAmount) FROM SalesTransaction WHERE CAST(TransactionDate AS DATE) = CAST(GETDATE() AS DATE)";
            else if (reportType == "Weekly")
                query = "SELECT SUM(TotalAmount) FROM SalesTransaction WHERE TransactionDate >= DATEADD(DAY, -7, GETDATE())";
            else if (reportType == "Monthly")
                query = "SELECT SUM(TotalAmount) FROM SalesTransaction WHERE TransactionDate >= DATEADD(MONTH, -1, GETDATE())";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                object result = cmd.ExecuteScalar();
                return (result == null || result == DBNull.Value) ? 0 : Convert.ToDecimal(result);
            }
        }

        public Guid GetBestSellingBook()
        {
            string query = @"
                SELECT TOP 1 b.BookID 
                FROM SalesDetails sd
                JOIN Book b ON sd.BookID = b.BookID
                GROUP BY b.BookID 
                ORDER BY SUM(sd.Quantity) DESC";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                object result = cmd.ExecuteScalar();
                return (result == null || result == DBNull.Value) ? Guid.Empty : (Guid)result;
            }
        }

        public List<BookSalesModel> GetBestSellingBooks()
        {
            List<BookSalesModel> bestSellingBooks = new List<BookSalesModel>();

            string query = @"
                SELECT TOP 1 b.BookID, b.Title, SUM(od.Quantity) AS TotalSold
                FROM OrderDetails od
                JOIN Book b ON od.BookID = b.BookID
                GROUP BY b.BookID, b.Title
                ORDER BY TotalSold DESC"; // Get the best-selling book

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bestSellingBooks.Add(new BookSalesModel
                        {
                            BookID = reader.GetGuid(0),
                            BookTitle = reader.GetString(1),
                            SalesCount = reader.GetInt32(2)
                        });
                    }
                }
            }
            return bestSellingBooks;
        }

        public string GetInventoryStatus()
        {
            string query = @"
                SELECT COUNT(BookID) AS LowStockBooks
                FROM Book 
                WHERE StockQuantity < 5"; // Books with low stock

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                object result = cmd.ExecuteScalar();
                int lowStockCount = (result == null || result == DBNull.Value) ? 0 : Convert.ToInt32(result);
                return lowStockCount > 0 ? $"{lowStockCount} books are low in stock" : "Inventory levels are sufficient.";
            }
        }

        public void SaveGeneratedReport(string reportType, decimal totalSales, Guid bestSellingBookId, string inventoryStatus, Guid generatedBy)
        {
            // If no valid best-selling book is found, set to NULL in DB
            object bestSellingBookParam = bestSellingBookId == Guid.Empty ? DBNull.Value : bestSellingBookId;

            string query = @"
                INSERT INTO Report (ReportType, TotalSales, BestSellingBookID, InventoryStatus, GeneratedBy) 
                VALUES (@ReportType, @TotalSales, @BestSellingBookID, @InventoryStatus, @GeneratedBy)";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ReportType", reportType);
                cmd.Parameters.AddWithValue("@TotalSales", totalSales);
                cmd.Parameters.AddWithValue("@BestSellingBookID", bestSellingBookParam);  // Handle NULL
                cmd.Parameters.AddWithValue("@InventoryStatus", inventoryStatus ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@GeneratedBy", generatedBy);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
