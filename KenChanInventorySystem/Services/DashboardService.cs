using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace KenChanInventorySystem.Services
{
    public class DashboardService
    {
        private readonly string _connectionString;
        public DashboardService()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["KenChanDB"].ConnectionString;
        }
        public int GetTotalProducts()
        {
            return ExecuteCount("SELECT COUNT(*) FROM Products");
        }
        public int GetLowStockCount() 
        {
            return ExecuteCount("SELECT COUNT(*) FROM Products WHERE QuantityInStock <= ReorderLevel");
        }
        public int GetTotalSuppliers()
        {
            return ExecuteCount("SELECT COUNT(*) FROM Suppliers");
        }
        public int GetTodayTransactionsCount()
        {
            return ExecuteCount("SELECT COUNT(*) FROM Transactions WHERE CAST (TransactionDate AS DATE) = CAST(GETDATE() AS DATE)");
        }
        public DataTable GetCategoryBreakdown()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT ISNULL(Category, 'Uncategorized') AS Category,
                           COUNT(*) AS ProductCount
                    FROM Products
                    GROUP BY Category
                    ORDER BY COUNT(*) DESC";

                using (var adapter = new SqlDataAdapter(query, conn))
                {
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
        public DataTable SearchProducts(string searchTerm, string categoryFilter)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                string query = @"
                    SELECT TOP 50
                        p.ProductID,
                        p.ProductCode,
                        p.ProductName,
                        ISNULL(p.Category, 'Uncategorized') AS Category,
                        p.QuantityInStock,
                        p.ReorderLevel,
                        p.UnitPrice
                    FROM Products p
                    WHERE 1=1";

                if (!string.IsNullOrWhiteSpace(searchTerm))
                    query += " AND (p.ProductName LIKE @search OR p.ProductCode LIKE @search)";

                if (!string.IsNullOrWhiteSpace(categoryFilter) &&
                    categoryFilter != "All Categories")
                    query += " AND p.Category = @category";

                query += " ORDER BY p.ProductName";

                using (var cmd = new SqlCommand(query, conn))
                {
                    if (!string.IsNullOrWhiteSpace(searchTerm))
                        cmd.Parameters.AddWithValue("@search", "%" + searchTerm + "%");

                    if (!string.IsNullOrWhiteSpace(categoryFilter) &&
                        categoryFilter != "All Categories")
                        cmd.Parameters.AddWithValue("@category", categoryFilter);

                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        var dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }
        public List<string> GetCategories()
        {
            var list = new List<string> { "All Categories" };

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(
                    @"SELECT DISTINCT Category 
                      FROM Products 
                      WHERE Category IS NOT NULL AND Category <> '' 
                      ORDER BY Category", conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                        list.Add(reader["Category"].ToString());
                }
            }

            return list;
        }
        private int ExecuteCount(string query)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(query, conn))
                {
                    var result = cmd.ExecuteScalar();
                    return result == null || result == DBNull.Value
                        ? 0
                        : Convert.ToInt32(result);
                }
            }
        }
    }
}