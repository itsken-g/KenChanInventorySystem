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
    public class ReportService
    {
        private readonly string _connectionString;
        public ReportService()
        {
            _connectionString = ConfigurationManager
                .ConnectionStrings["KenchanDB"].ConnectionString;
        }
        public DataTable GetInventorySummary()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT 
                        p.ProductCode,
                        p.ProductName,
                        ISNULL(p.Category, 'Uncategorized') AS Category,
                        p.UnitPrice,
                        p.QuantityInStock,
                        p.ReorderLevel,
                        ISNULL(s.SupplierName, '—') AS SupplierName,
                        (p.UnitPrice * p.QuantityInStock) AS StockValue
                    FROM Products p
                    LEFT JOIN Suppliers s ON p.SupplierID = s.SupplierID
                    ORDER BY p.ProductName";

                using (var adapter = new SqlDataAdapter(query, conn))
                {
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable GetLowStockReport()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT 
                        p.ProductCode,
                        p.ProductName,
                        ISNULL(p.Category, 'Uncategorized') AS Category,
                        p.QuantityInStock,
                        p.ReorderLevel,
                        (p.ReorderLevel - p.QuantityInStock) AS Shortage,
                        ISNULL(s.SupplierName, '—') AS SupplierName
                    FROM Products p
                    LEFT JOIN Suppliers s ON p.SupplierID = s.SupplierID
                    WHERE p.QuantityInStock <= p.ReorderLevel
                    ORDER BY p.QuantityInStock ASC";

                using (var adapter = new SqlDataAdapter(query, conn))
                {
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable GetTransactionHistory(DateTime fromDate, DateTime toDate)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT 
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
                    WHERE CAST(t.TransactionDate AS DATE) >= @fromDate
                      AND CAST(t.TransactionDate AS DATE) <= @toDate
                    ORDER BY t.TransactionDate DESC";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@fromDate", fromDate.Date);
                    cmd.Parameters.AddWithValue("@toDate", toDate.Date);

                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        var dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }
    }
}
