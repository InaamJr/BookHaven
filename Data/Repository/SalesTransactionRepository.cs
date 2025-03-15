using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using BookHaven.Data.Models;

namespace BookHaven.Data.Repository
{
    public class SalesTransactionRepository : ISalesTransactionRepository
    {
        private readonly string _connectionString = "Server=DESKTOP-KVP3P8D\\MSSQLSERVER2022;Database=BookHaven;Integrated Security=True;TrustServerCertificate=True;";

        // Create Sales Transaction
        public int CreateSalesTransaction(SalesTransactionModel transaction, List<SalesDetailsModel> salesDetails)
        {
            int transactionID = 0;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlTransaction sqlTransaction = conn.BeginTransaction();

                try
                {
                    // Insert Sales Transaction
                    string query = "INSERT INTO SalesTransaction (CustomerID, TransactionDate, TotalAmount, Discount, FinalAmount, PaymentMethod, UserID) " +
                                   "OUTPUT INSERTED.TransactionID VALUES (@CustomerID, @TransactionDate, @TotalAmount, @Discount, @FinalAmount, @PaymentMethod, @UserID)";

                    using (SqlCommand cmd = new SqlCommand(query, conn, sqlTransaction))
                    {
                        cmd.Parameters.AddWithValue("@CustomerID", transaction.CustomerID);
                        cmd.Parameters.AddWithValue("@TransactionDate", transaction.TransactionDate);
                        cmd.Parameters.AddWithValue("@TotalAmount", transaction.TotalAmount);
                        cmd.Parameters.AddWithValue("@Discount", transaction.Discount);
                        cmd.Parameters.AddWithValue("@PaymentMethod", transaction.PaymentMethod);
                        cmd.Parameters.AddWithValue("@UserID", transaction.UserID);
                        cmd.Parameters.AddWithValue("@FinalAmount", transaction.FinalAmount);

                        transactionID = (int)cmd.ExecuteScalar();
                    }

                    // Insert Sales Details
                    foreach (var item in salesDetails)
                    {
                        string detailsQuery = "INSERT INTO SalesDetails (TransactionID, BookID, Quantity, PricePerUnit, SubTotal) " +
                                              "VALUES (@TransactionID, @BookID, @Quantity, @PricePerUnit, @SubTotal)";

                        using (SqlCommand cmd = new SqlCommand(detailsQuery, conn, sqlTransaction))
                        {
                            cmd.Parameters.AddWithValue("@TransactionID", transactionID);
                            cmd.Parameters.AddWithValue("@BookID", item.BookID);
                            cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                            cmd.Parameters.AddWithValue("@PricePerUnit", item.PricePerUnit);
                            cmd.Parameters.AddWithValue("@SubTotal", item.SubTotal);

                            cmd.ExecuteNonQuery();
                        }

                        // Update Stock Quantity
                        string updateStockQuery = "UPDATE Book SET StockQuantity = StockQuantity - @Quantity WHERE BookID = @BookID";

                        using (SqlCommand cmd = new SqlCommand(updateStockQuery, conn, sqlTransaction))
                        {
                            cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                            cmd.Parameters.AddWithValue("@BookID", item.BookID);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    sqlTransaction.Commit();
                }
                catch
                {
                    sqlTransaction.Rollback();
                    throw;
                }
            }
            return transactionID;
        }

        // Get All Sales Transactions
        public List<SalesTransactionModel> GetAllSalesTransactions()
        {
            List<SalesTransactionModel> transactions = new List<SalesTransactionModel>();
            string query = "SELECT TransactionID, CustomerID, TransactionDate, TotalAmount, Discount, FinalAmount, PaymentMethod, UserID FROM SalesTransaction";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        transactions.Add(new SalesTransactionModel
                        {
                            TransactionID = reader.GetInt32(0),
                            CustomerID = reader.GetGuid(1),
                            TransactionDate = reader.GetDateTime(2),
                            TotalAmount = reader.GetDecimal(3),
                            Discount = reader.GetDecimal(4),
                            FinalAmount = reader.GetDecimal(5), 
                            PaymentMethod = reader.GetString(6),
                            UserID = reader.GetGuid(7)
                        });
                    }
                }
            }
            return transactions;
        }

        // Get Sales Details
        public List<SalesDetailsModel> GetSalesDetails(int transactionID)
        {
            List<SalesDetailsModel> details = new List<SalesDetailsModel>();
            string query = @"
                    SELECT sd.SalesDetailsID, sd.TransactionID, sd.BookID, 
                           b.Title AS BookTitle, sd.Quantity, sd.PricePerUnit, sd.SubTotal
                    FROM SalesDetails sd
                    JOIN Book b ON sd.BookID = b.BookID
                    WHERE sd.TransactionID = @TransactionID";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@TransactionID", transactionID);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        details.Add(new SalesDetailsModel
                        {
                            SalesDetailsID = reader.GetInt32(0),
                            TransactionID = reader.GetInt32(1),
                            BookID = reader.GetGuid(2),
                            BookTitle = reader.GetString(3),
                            Quantity = reader.GetInt32(4),
                            PricePerUnit = reader.GetDecimal(5),
                            SubTotal = reader.GetDecimal(6)
                        });
                    }
                }
            }
            return details;
        }
    }
}
