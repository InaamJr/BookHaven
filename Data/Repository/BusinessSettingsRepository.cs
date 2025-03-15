using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using BookHaven.Data.Models;

namespace BookHaven.Data.Repository
{
    public class BusinessSettingsRepository : IBusinessSettingsRepository
    {
        private readonly string _connectionString = "Server=DESKTOP-KVP3P8D\\MSSQLSERVER2022;Database=BookHaven;Integrated Security=True;TrustServerCertificate=True;";

        public BusinessSettingsModel GetBusinessSettings()
        {
            BusinessSettingsModel settings = null;
            string query = "SELECT TOP 1 * FROM BusinessSettings"; // Ensure only one record exists

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        settings = new BusinessSettingsModel
                        {
                            BusinessID = reader.GetInt32(0),
                            BusinessName = reader.GetString(1),
                            Email = reader.GetString(2),
                            Phone = reader.GetString(3),
                            Address = reader.GetString(4)
                        };
                    }
                }
            }
            return settings;
        }

        public void UpdateBusinessSettings(BusinessSettingsModel settings)
        {
            string query = "UPDATE BusinessSettings SET BusinessName = @BusinessName, Email = @Email, Phone = @Phone, Address = @Address WHERE BusinessID = @BusinessID";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@BusinessID", settings.BusinessID);
                cmd.Parameters.AddWithValue("@BusinessName", settings.BusinessName);
                cmd.Parameters.AddWithValue("@Email", settings.Email);
                cmd.Parameters.AddWithValue("@Phone", settings.Phone);
                cmd.Parameters.AddWithValue("@Address", settings.Address);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
