using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using BookHaven.Data.Models;

namespace BookHaven.Data.Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly string _connectionString = "Server=DESKTOP-KVP3P8D\\MSSQLSERVER2022;Database=BookHaven;Integrated Security=True;TrustServerCertificate=True;";

        // Get All Suppliers
        public List<SupplierModel> GetAllSuppliers()
        {
            List<SupplierModel> suppliers = new List<SupplierModel>();
            string query = "SELECT SupplierID, Name, ContactPerson, Email, Phone, Address, UserID FROM Supplier";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        suppliers.Add(new SupplierModel
                        {
                            SupplierID = reader.GetGuid(0),
                            Name = reader.GetString(1),
                            ContactPerson = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                            Email = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                            Phone = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                            Address = reader.IsDBNull(5) ? string.Empty : reader.GetString(5),
                            UserID = reader.GetGuid(6)
                        });
                    }
                }
            }
            return suppliers;
        }

        // Add New Supplier
        public void AddSupplier(SupplierModel supplier)
        {
            string query = "INSERT INTO Supplier (Name, ContactPerson, Email, Phone, Address, UserID) " +
                           "VALUES (@Name, @ContactPerson, @Email, @Phone, @Address, @UserID)";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Name", supplier.Name);
                cmd.Parameters.AddWithValue("@ContactPerson", supplier.ContactPerson);
                cmd.Parameters.AddWithValue("@Email", supplier.Email);
                cmd.Parameters.AddWithValue("@Phone", supplier.Phone);
                cmd.Parameters.AddWithValue("@Address", supplier.Address);
                cmd.Parameters.AddWithValue("@UserID", supplier.UserID);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Update Supplier
        public void UpdateSupplier(SupplierModel supplier)
        {
            string query = "UPDATE Supplier SET Name = @Name, ContactPerson = @ContactPerson, Email = @Email, " +
                           "Phone = @Phone, Address = @Address WHERE SupplierID = @SupplierID";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@SupplierID", supplier.SupplierID);
                cmd.Parameters.AddWithValue("@Name", supplier.Name);
                cmd.Parameters.AddWithValue("@ContactPerson", supplier.ContactPerson);
                cmd.Parameters.AddWithValue("@Email", supplier.Email);
                cmd.Parameters.AddWithValue("@Phone", supplier.Phone);
                cmd.Parameters.AddWithValue("@Address", supplier.Address);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Delete Supplier
        public void DeleteSupplier(Guid supplierID)
        {
            string query = "DELETE FROM Supplier WHERE SupplierID = @SupplierID";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@SupplierID", supplierID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Get Supplier Email for Restock Notification
        public string GetSupplierEmail(Guid supplierID)
        {
            string email = "";
            string query = "SELECT Email FROM Supplier WHERE SupplierID = @SupplierID";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@SupplierID", supplierID);
                conn.Open();
                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    email = result.ToString();
                }
            }
            return email;
        }
    }
}
