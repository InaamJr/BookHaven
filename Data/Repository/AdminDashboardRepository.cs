using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using BookHaven.Data.Models;

namespace BookHaven.Data.Repository
{
    public class AdminDashboardRepository : IAdminDashboardRepository
    {
        private readonly string _connectionString = "Server=DESKTOP-KVP3P8D\\MSSQLSERVER2022;Database=BookHaven;Integrated Security=True;TrustServerCertificate=True;";

        // Get Total Sales Amount
        public decimal GetTotalSales()
        {
            decimal totalSales = 0;
            string query = "SELECT SUM(TotalAmount) FROM SalesTransaction";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                object result = cmd.ExecuteScalar();
                totalSales = result != DBNull.Value ? Convert.ToDecimal(result) : 0;

                Console.WriteLine($"DEBUG: Total Sales Retrieved - {totalSales}");
            }
            return totalSales;
        }

        // Get Total Orders Count
        public int GetTotalOrders()
        {
            string query = "SELECT COUNT(*) FROM [Order]";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // Get Total Registered Customers
        public int GetTotalCustomers()
        {
            string query = "SELECT COUNT(*) FROM Customer";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // Get Total Books in Stock
        public int GetTotalBooksInStock()
        {
            string query = "SELECT SUM(StockQuantity) FROM Book";
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                object result = cmd.ExecuteScalar();
                return result != DBNull.Value ? Convert.ToInt32(result) : 0;
            }
        }

        // Get Monthly Sales Data for Charts
        public List<SalesReportModel> GetMonthlySales()
        {
            List<SalesReportModel> salesData = new List<SalesReportModel>();
            string query = @"
                SELECT FORMAT(TransactionDate, 'yyyy-MM') AS Month, SUM(TotalAmount) AS TotalSales
                FROM SalesTransaction
                GROUP BY FORMAT(TransactionDate, 'yyyy-MM')
                ORDER BY Month";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        salesData.Add(new SalesReportModel
                        {
                            Month = reader.GetString(0),
                            TotalSales = reader.GetDecimal(1)
                        });
                    }
                }
            }
            return salesData;
        }

        // Get Best-Selling Books
        public List<BookSalesModel> GetBestSellingBooks()
        {
            List<BookSalesModel> bestSellers = new List<BookSalesModel>();
            string query = @"
                SELECT TOP 5 b.Title, SUM(sd.Quantity) AS SalesCount
                FROM SalesDetails sd
                JOIN Book b ON sd.BookID = b.BookID
                GROUP BY b.Title
                ORDER BY SalesCount DESC";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bestSellers.Add(new BookSalesModel
                        {
                            BookTitle = reader.GetString(0),
                            SalesCount = reader.GetInt32(1)
                        });
                    }
                }
            }
            return bestSellers;
        }

        // Get Low Stock Books
        public List<LowStockBookModel> GetLowStockBooks()
        {
            List<LowStockBookModel> lowStockBooks = new List<LowStockBookModel>();
            string query = "SELECT Title, StockQuantity FROM Book WHERE StockQuantity < 5"; // Threshold < 5

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lowStockBooks.Add(new LowStockBookModel
                        {
                            Title = reader.GetString(0),
                            StockQuantity = reader.GetInt32(1)
                        });
                    }
                }
            }
            return lowStockBooks;
        }

        // Get Staff Performance (Sales per Staff Member)
        public List<StaffPerformanceModel> GetStaffPerformance()
        {
            List<StaffPerformanceModel> staffPerformance = new List<StaffPerformanceModel>();
            string query = @"
                    SELECT u.Username, COUNT(s.TransactionID) AS SalesCount
                    FROM SalesTransaction s
                    JOIN [User] u ON s.UserID = u.UserID
                    GROUP BY u.Username
                    ORDER BY SalesCount DESC";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"DEBUG: Staff - {reader.GetString(0)}, Sales: {reader.GetInt32(1)}");

                        staffPerformance.Add(new StaffPerformanceModel
                        {
                            StaffName = reader.GetString(0),
                            SalesCount = reader.GetInt32(1)
                        });
                    }
                }
            }
            Console.WriteLine($"DEBUG: Total Staff Performance Records: {staffPerformance.Count}");
            return staffPerformance;
        }

        public List<CustomerActivityModel> GetCustomerActivity()
        {
            List<CustomerActivityModel> customerActivity = new List<CustomerActivityModel>();
            string query = @"
                    SELECT c.Name AS CustomerName, COUNT(s.TransactionID) AS PurchaseCount
                    FROM SalesTransaction s
                    JOIN Customer c ON s.CustomerID = c.CustomerID
                    GROUP BY c.Name
                    ORDER BY PurchaseCount DESC";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customerActivity.Add(new CustomerActivityModel
                        {
                            CustomerName = reader.GetString(0),
                            PurchaseCount = reader.GetInt32(1)
                        });
                    }
                }
            }
            return customerActivity;
        }
    }
}
