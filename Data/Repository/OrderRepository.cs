using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using BookHaven.Data.Models;

namespace BookHaven.Data.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly string _connectionString = "Server=DESKTOP-KVP3P8D\\MSSQLSERVER2022;Database=BookHaven;Integrated Security=True;TrustServerCertificate=True;";

        // Create Order
        public int CreateOrder(OrderModel order, List<OrderDetailsModel> orderDetails)
        {
            int orderID = 0;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Insert Order
                    string query = "INSERT INTO [Order] (CustomerID, OrderDate, TotalAmount, OrderStatus, PaymentStatus, DeliveryType, ExpectedDeliveryDate, UserID) " +
                                   "OUTPUT INSERTED.OrderID " +
                                   "VALUES (@CustomerID, @OrderDate, @TotalAmount, @OrderStatus, @PaymentStatus, @DeliveryType, @ExpectedDeliveryDate, @UserID)";

                    using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@CustomerID", order.CustomerID);
                        cmd.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                        cmd.Parameters.AddWithValue("@TotalAmount", order.TotalAmount);
                        cmd.Parameters.AddWithValue("@OrderStatus", order.OrderStatus);
                        cmd.Parameters.AddWithValue("@PaymentStatus", order.PaymentStatus);
                        cmd.Parameters.AddWithValue("@DeliveryType", order.DeliveryType);
                        cmd.Parameters.AddWithValue("@ExpectedDeliveryDate", order.ExpectedDeliveryDate);
                        cmd.Parameters.AddWithValue("@UserID", order.UserID);

                        orderID = (int)cmd.ExecuteScalar();
                    }

                    // Insert Order Details
                    foreach (var item in orderDetails)
                    {
                        string detailsQuery = "INSERT INTO OrderDetails (OrderID, BookID, Quantity, PricePerUnit, SubTotal) " +
                                              "VALUES (@OrderID, @BookID, @Quantity, @PricePerUnit, @SubTotal)";

                        using (SqlCommand cmd = new SqlCommand(detailsQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@OrderID", orderID);
                            cmd.Parameters.AddWithValue("@BookID", item.BookID);
                            cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                            cmd.Parameters.AddWithValue("@PricePerUnit", item.PricePerUnit);
                            cmd.Parameters.AddWithValue("@SubTotal", item.SubTotal);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
            return orderID;
        }

        // Get All Orders
        public List<OrderModel> GetAllOrders()
        {
            List<OrderModel> orders = new List<OrderModel>();
            string query = "SELECT o.OrderID, o.CustomerID, c.Name AS CustomerName, o.OrderDate, o.TotalAmount, " +
                           "o.OrderStatus, o.PaymentStatus, o.DeliveryType, o.ExpectedDeliveryDate, o.UserID " +
                           "FROM [Order] o " +
                           "LEFT JOIN Customer c ON o.CustomerID = c.CustomerID";  // Ensure LEFT JOIN is used

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        orders.Add(new OrderModel
                        {
                            OrderID = reader.GetInt32(0),
                            CustomerID = reader.GetGuid(1),  // Ensure CustomerID is fetched correctly
                            CustomerName = reader.IsDBNull(2) ? "Unknown" : reader.GetString(2), // Prevent null values
                            OrderDate = reader.GetDateTime(3),
                            TotalAmount = reader.GetDecimal(4),
                            OrderStatus = reader.GetString(5),
                            PaymentStatus = reader.GetString(6),
                            DeliveryType = reader.GetString(7),
                            ExpectedDeliveryDate = reader.GetDateTime(8),
                            UserID = reader.GetGuid(9)
                        });
                    }
                }
            }
            return orders;
        }

        // Get Order Details by OrderID
        public List<OrderDetailsModel> GetOrderDetails(int orderID)
        {
            List<OrderDetailsModel> orderDetails = new List<OrderDetailsModel>();
            string query = "SELECT od.OrderDetailsID, od.OrderID, od.BookID, b.Title, od.Quantity, od.PricePerUnit, od.SubTotal " +
                           "FROM OrderDetails od " +
                           "JOIN Book b ON od.BookID = b.BookID " +
                           "WHERE od.OrderID = @OrderID";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@OrderID", orderID);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        orderDetails.Add(new OrderDetailsModel
                        {
                            OrderDetailsID = reader.GetInt32(0),
                            OrderID = reader.GetInt32(1),
                            BookID = reader.GetGuid(2),
                            BookTitle = reader.GetString(3),
                            Quantity = reader.GetInt32(4),
                            PricePerUnit = reader.GetDecimal(5),
                            SubTotal = reader.GetDecimal(6)
                        });
                    }
                }
            }
            return orderDetails;
        }

        // Delete Order
        public void DeleteOrder(int orderID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction(); 

                try
                {
                    // First, delete related records from OrderDetails
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM OrderDetails WHERE OrderID = @OrderID", conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@OrderID", orderID);
                        cmd.ExecuteNonQuery();
                    }

                    // Now delete the order
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM [Order] WHERE OrderID = @OrderID", conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@OrderID", orderID);
                        cmd.ExecuteNonQuery();
                    }

                    transaction.Commit(); // Commit the transaction if both deletions are successful
                }
                catch
                {
                    transaction.Rollback(); // Rollback if any error occurs
                    throw;
                }
            }
        }

        public void UpdateOrder(int orderId, OrderModel order, List<OrderDetailsModel> orderDetails)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();  // Use Transaction for Safety

                try
                {
                    // Update Order Table
                    string query = "UPDATE [Order] SET OrderStatus = @OrderStatus, PaymentStatus = @PaymentStatus, " +
                                   "DeliveryType = @DeliveryType, ExpectedDeliveryDate = @ExpectedDeliveryDate, " +
                                   "TotalAmount = @TotalAmount WHERE OrderID = @OrderID";

                    using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@OrderID", orderId);
                        cmd.Parameters.AddWithValue("@OrderStatus", order.OrderStatus);
                        cmd.Parameters.AddWithValue("@PaymentStatus", order.PaymentStatus);
                        cmd.Parameters.AddWithValue("@DeliveryType", order.DeliveryType);
                        cmd.Parameters.AddWithValue("@ExpectedDeliveryDate", order.ExpectedDeliveryDate);
                        cmd.Parameters.AddWithValue("@TotalAmount", order.TotalAmount);

                        cmd.ExecuteNonQuery();
                    }

                    // Update Order Details Table
                    foreach (var item in orderDetails)
                    {
                        string detailsQuery = "UPDATE OrderDetails SET Quantity = @Quantity, PricePerUnit = @PricePerUnit, " +
                                              "SubTotal = @SubTotal WHERE OrderID = @OrderID AND BookID = @BookID";

                        using (SqlCommand cmd = new SqlCommand(detailsQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@OrderID", orderId);
                            cmd.Parameters.AddWithValue("@BookID", item.BookID);
                            cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                            cmd.Parameters.AddWithValue("@PricePerUnit", item.PricePerUnit);
                            cmd.Parameters.AddWithValue("@SubTotal", item.SubTotal);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    if (order.OrderStatus == "Completed" && order.PaymentStatus == "Completed")
                    {
                        string stockUpdateQuery = @"
                            UPDATE Book 
                            SET StockQuantity = StockQuantity - od.Quantity
                            FROM Book 
                            INNER JOIN OrderDetails od ON Book.BookID = od.BookID
                            WHERE od.OrderID = @OrderID";

                        using (SqlCommand stockCmd = new SqlCommand(stockUpdateQuery, conn, transaction))
                        {
                            stockCmd.Parameters.AddWithValue("@OrderID", orderId);
                            stockCmd.ExecuteNonQuery();
                        }
                    }
                    transaction.Commit();  // Commit Transaction if Successful
                }
                catch
                {
                    transaction.Rollback();  // Rollback if Any Error
                    throw;
                }
            }
        }

    }
}

