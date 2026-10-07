using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KenChanInventorySystem.Services
{
    public class TransactionService
    {
        private readonly string _connectionString;
        public TransactionService()
        {
            _connectionString = ConfigurationManager
                .ConnectionStrings["KenchanDB"].ConnectionString;
        }
        public DataTable GetAllProducts()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT ProductID, 
                           ProductCode + ' — ' + ProductName AS Display,
                           QuantityInStock
                    FROM Products 
                    ORDER BY ProductName";

                using (var adapter = new SqlDataAdapter(query, conn))
                {
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
        public int GetCurrentStock(int productId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(
                    "SELECT QuantityInStock FROM Products WHERE ProductID = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", productId);
                    object result = cmd.ExecuteScalar();
                    return result == null ? 0 : Convert.ToInt32(result);
                }
            }
        }
        public bool RecordTransaction(int productId, string type, int quantity, string notes, int userId)
        {
            if (type != "IN" && type != "OUT")
                throw new Exception("Invalid transaction type.");

            if (quantity <= 0)
                throw new Exception("Quantity must be greater than 0.");

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (var tx = conn.BeginTransaction())
                {
                    try
                    {
                        if (type == "OUT")
                        {
                            using (var checkCmd = new SqlCommand(
                                "SELECT QuantityInStock FROM Products WHERE ProductID = @id",
                                conn, tx))
                            {
                                checkCmd.Parameters.AddWithValue("@id", productId);
                                int stock = Convert.ToInt32(checkCmd.ExecuteScalar());

                                if (stock < quantity)
                                    throw new Exception(
                                        $"Insufficient stock. Available: {stock}, Requested: {quantity}");
                            }
                        }

                        using (var insertCmd = new SqlCommand(@"
                            INSERT INTO Transactions 
                                (ProductID, TransactionType, Quantity, TransactionDate, Notes, UserID)
                            VALUES 
                                (@pid, @type, @qty, GETDATE(), @notes, @uid)",
                            conn, tx))
                        {
                            insertCmd.Parameters.AddWithValue("@pid", productId);
                            insertCmd.Parameters.AddWithValue("@type", type);
                            insertCmd.Parameters.AddWithValue("@qty", quantity);
                            insertCmd.Parameters.AddWithValue("@notes",
                                string.IsNullOrWhiteSpace(notes) ? (object)DBNull.Value : notes);
                            insertCmd.Parameters.AddWithValue("@uid",
                                userId > 0 ? (object)userId : DBNull.Value);

                            insertCmd.ExecuteNonQuery();
                        }

                        string updateQuery = type == "IN"
                            ? "UPDATE Products SET QuantityInStock = QuantityInStock + @qty WHERE ProductID = @pid"
                            : "UPDATE Products SET QuantityInStock = QuantityInStock - @qty WHERE ProductID = @pid";

                        using (var updateCmd = new SqlCommand(updateQuery, conn, tx))
                        {
                            updateCmd.Parameters.AddWithValue("@qty", quantity);
                            updateCmd.Parameters.AddWithValue("@pid", productId);
                            updateCmd.ExecuteNonQuery();
                        }

                        tx.Commit();
                        return true;
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }
        public DataTable GetAllTransactions()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT TOP 200
                        t.TransactionID,
                        t.TransactionDate,
                        p.ProductCode,
                        p.ProductName,
                        t.TransactionType,
                        t.Quantity,
                        ISNULL(t.Notes, '') AS Notes,
                        ISNULL(u.Username, 'system') AS Username
                    FROM Transactions t
                    LEFT JOIN Products p ON t.ProductID = p.ProductID
                    LEFT JOIN Users u ON t.UserID = u.UserID
                    ORDER BY t.TransactionDate DESC";

                using (var adapter = new SqlDataAdapter(query, conn))
                {
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable SearchTransactions(string searchTerm)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT TOP 200
                        t.TransactionID,
                        t.TransactionDate,
                        p.ProductCode,
                        p.ProductName,
                        t.TransactionType,
                        t.Quantity,
                        ISNULL(t.Notes, '') AS Notes,
                        ISNULL(u.Username, 'system') AS Username
                    FROM Transactions t
                    LEFT JOIN Products p ON t.ProductID = p.ProductID
                    LEFT JOIN Users u ON t.UserID = u.UserID
                    WHERE 1=1";

                if (!string.IsNullOrWhiteSpace(searchTerm))
                    query += " AND (p.ProductName LIKE @search OR p.ProductCode LIKE @search OR t.TransactionType LIKE @search)";

                query += " ORDER BY t.TransactionDate DESC";

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
        public int GetTodayTransactionCount()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(
                    @"SELECT COUNT(*) FROM Transactions 
                      WHERE CAST(TransactionDate AS DATE) = CAST(GETDATE() AS DATE)", conn))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
    }

}
