using KenChanInventorySystem.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KenChanInventorySystem.Services
{
    public class AuthService
    {
        private readonly string _connectionString;

        public AuthService()
        {
            _connectionString = ConfigurationManager
                .ConnectionStrings["KenchanDB"].ConnectionString;
        }
        public Users Authenticate(string username, string password)
        {
            string hash = ComputeSha256Hash(password);

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                string query = @"SELECT UserID, Username, Role, CreatedAt
                                 FROM Users
                                 WHERE Username = @username
                                   AND PasswordHash = @hash";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@hash", hash);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Users
                            {
                                UserID = (int)reader["UserID"],
                                Username = reader["Username"].ToString(),
                                Role = reader["Role"].ToString(),
                                CreatedAt = (DateTime)reader["CreatedAt"]
                            };
                        }
                    }
                }
            }
            return null;
        }
        public int RegisterUser(string username, string password, string role)
        {
            string hash = ComputeSha256Hash(password);

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                string query = @"INSERT INTO Users (Username, PasswordHash, Role, CreatedAt)
                                 VALUES (@u, @h, @r, GETDATE());
                                 SELECT CAST(SCOPE_IDENTITY() AS INT);";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@u", username);
                    cmd.Parameters.AddWithValue("@h", hash);
                    cmd.Parameters.AddWithValue("@r", role);

                    object result = cmd.ExecuteScalar();
                    return result == null ? -1 : Convert.ToInt32(result);
                }
            }
        }
        public bool UsernameExists(string username)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Users WHERE Username = @u", conn))
                {
                    cmd.Parameters.AddWithValue("@u", username);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        public string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                    builder.Append(b.ToString("x2")); 

                return builder.ToString();
            }
        }
        
            

            
        
    }
}
