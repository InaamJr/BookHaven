using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using BookHaven.Data.Models;

namespace BookHaven.Data.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly string _connectionString = "Server=DESKTOP-KVP3P8D\\MSSQLSERVER2022;Database=BookHaven;Integrated Security=True;TrustServerCertificate=True;";

        // Add Customer
        public void AddCustomer(CustomerModel customer)
        {
            string query = "INSERT INTO Customer (CustomerID, Name, Email, Phone, Address, JoinDate, UserID) " +
                           "VALUES (@CustomerID, @Name, @Email, @Phone, @Address, @JoinDate, @UserID)";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                cmd.Parameters.AddWithValue("@Name", customer.Name);
                cmd.Parameters.AddWithValue("@Email", customer.Email);
                cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                cmd.Parameters.AddWithValue("@Address", customer.Address);
                cmd.Parameters.AddWithValue("@JoinDate", customer.JoinDate);
                cmd.Parameters.AddWithValue("@UserID", customer.UserID);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Get All Customers
        public List<CustomerModel> GetAllCustomers()
        {
            List<CustomerModel> customers = new List<CustomerModel>(); // Correct return type

            string query = "SELECT CustomerID, Name, Email, Phone, Address, JoinDate, UserID FROM Customer"; // ✅ Removed WHERE clause

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())  // Read all customers
                    {
                        customers.Add(new CustomerModel
                        {
                            CustomerID = reader.GetGuid(0),
                            Name = reader.GetString(1),
                            Email = reader.GetString(2),
                            Phone = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                            Address = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                            JoinDate = reader.GetDateTime(5),
                            UserID = reader.GetGuid(6)
                        });
                    }
                }
            }
            return customers; // Correct return type (List<CustomerModel>)
        }

        // Update Customer
        public void UpdateCustomer(CustomerModel customer)
        {
            string query = "UPDATE Customer SET Name=@Name, Email=@Email, Phone=@Phone, Address=@Address WHERE CustomerID=@CustomerID";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                cmd.Parameters.AddWithValue("@Name", customer.Name);
                cmd.Parameters.AddWithValue("@Email", customer.Email);
                cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                cmd.Parameters.AddWithValue("@Address", customer.Address);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Delete Customer
        public void DeleteCustomer(Guid customerID)
        {
            string query = "DELETE FROM Customer WHERE CustomerID=@CustomerID";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@CustomerID", customerID);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public CustomerModel GetCustomerById(Guid customerID)
        {
            CustomerModel customer = null;
            string query = "SELECT * FROM Customer WHERE CustomerID = @CustomerID";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@CustomerID", customerID);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        customer = new CustomerModel
                        {
                            CustomerID = reader.GetGuid(0),
                            Name = reader.GetString(1),
                            Email = reader.GetString(2),
                            Phone = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                            Address = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                            JoinDate = reader.GetDateTime(5),
                            UserID = reader.GetGuid(6)
                        };
                    }
                }
            }
            return customer;
        }

    }
}
