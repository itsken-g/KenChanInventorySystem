using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using KenChanInventorySystem.Models;
namespace KenChanInventorySystem.Services
{
    public class SuppliersService
    {
        private readonly string _connectionString;
        
        public SuppliersService()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["KenChanDB"].ConnectionString;
        }
        public DataTable GetAllSuppliers()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string querry = @"SELECT SupplierID, SupplierName, ContactPerson, Phone, Email, Address FROM Suppliers ORDER BY SupplierName";
                using (var adapter = new SqlDataAdapter(querry, conn))
                {
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
        public Suppliers GetSupplierById (int SupplierID)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string querry = @"SELECT SupplierID, SupplierName, ContactPerson, Phone, Email, Address 
                                FROM Suppliers 
                                WHERE SupplierID = @id";
                using (var cmd = new SqlCommand(querry, conn))
                {
                    cmd.Parameters.AddWithValue(@"id", SupplierID);
                    using(var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Suppliers
                            {
                                SupplierID = (int)reader["SupplierID"],
                                SupplierName = reader["SupplierName"].ToString(),
                                ContactPerson = reader["ContactPerson"] == DBNull.Value ? "" : reader["ContactPerson"].ToString(),
                                Phone = reader["Phone"] == DBNull.Value ? "" : reader["Phone"].ToString(),
                                Email = reader["Email"] == DBNull.Value ? "" : reader["Email"].ToString(),
                                Address = reader["Address"] == DBNull.Value ? "" : reader["Address"].ToString()
                            };
                        }
                    }
                    
                }
            }
            return null;
        }
        public int AddSupplier(Suppliers supplier)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = @"
                    INSERT INTO Suppliers 
                        (SupplierName, ContactPerson, Phone, Email, Address)
                    VALUES 
                        (@name, @contact, @phone, @email, @address);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", supplier.SupplierName);
                    cmd.Parameters.AddWithValue("@contact",
                        string.IsNullOrWhiteSpace(supplier.ContactPerson) ? (object)DBNull.Value : supplier.ContactPerson);
                    cmd.Parameters.AddWithValue("@phone",
                        string.IsNullOrWhiteSpace(supplier.Phone) ? (object)DBNull.Value : supplier.Phone);
                    cmd.Parameters.AddWithValue("@email",
                        string.IsNullOrWhiteSpace(supplier.Email) ? (object)DBNull.Value : supplier.Email);
                    cmd.Parameters.AddWithValue("@address",
                        string.IsNullOrWhiteSpace(supplier.Address) ? (object)DBNull.Value : supplier.Address);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
        public bool UpdateSupplier(Suppliers supplier)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = @"
                    UPDATE Suppliers SET
                        SupplierName = @name,
                        ContactPerson = @contact,
                        Phone = @phone,
                        Email = @email,
                        Address = @address
                    WHERE SupplierID = @id";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", supplier.SupplierID);
                    cmd.Parameters.AddWithValue("@name", supplier.SupplierName);
                    cmd.Parameters.AddWithValue("@contact",
                        string.IsNullOrWhiteSpace(supplier.ContactPerson) ? (object)DBNull.Value : supplier.ContactPerson);
                    cmd.Parameters.AddWithValue("@phone",
                        string.IsNullOrWhiteSpace(supplier.Phone) ? (object)DBNull.Value : supplier.Phone);
                    cmd.Parameters.AddWithValue("@email",
                        string.IsNullOrWhiteSpace(supplier.Email) ? (object)DBNull.Value : supplier.Email);
                    cmd.Parameters.AddWithValue("@address",
                        string.IsNullOrWhiteSpace(supplier.Address) ? (object)DBNull.Value : supplier.Address);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public bool DeleteSupplier(int SupplierID)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

        
                using (var checkCmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Products WHERE SupplierID = @id", conn))
                {
                    checkCmd.Parameters.AddWithValue("@id", SupplierID);
                    if ((int)checkCmd.ExecuteScalar() > 0)
                        throw new Exception("Cannot delete — this supplier is linked to existing products.");
                }

                using (var cmd = new SqlCommand(
                    "DELETE FROM Suppliers WHERE SupplierID = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", SupplierID);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public DataTable SearchSuppliers(string searchTerm)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT SupplierID, SupplierName, ContactPerson, Phone, Email, Address
                    FROM Suppliers
                    WHERE 1=1";

                if (!string.IsNullOrWhiteSpace(searchTerm))
                    query += " AND (SupplierName LIKE @search OR ContactPerson LIKE @search OR Phone LIKE @search OR Email LIKE @search)";

                query += " ORDER BY SupplierName";

                using (var cmd = new SqlCommand(query, conn))
                {
                    if (!string.IsNullOrWhiteSpace(searchTerm))
                        cmd.Parameters.AddWithValue("@search", "%" + searchTerm + "%");

                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        var dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }
        public bool SupplierNameExists(string name, int excludeId = 0)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Suppliers WHERE SupplierName = @name AND SupplierID <> @id", conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@id", excludeId);
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }
    }
}
