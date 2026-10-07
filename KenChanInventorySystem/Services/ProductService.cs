using KenChanInventorySystem.Models;
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
    
    public class ProductService
    {
        private readonly string _connectionString;

        public ProductService()
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
                    SELECT 
                        p.ProductID,
                        p.ProductCode,
                        p.ProductName,
                        ISNULL(p.Category, 'Uncategorized') AS Category,
                        p.UnitPrice,
                        p.QuantityInStock,
                        p.ReorderLevel,
                        p.SupplierID,
                        ISNULL(s.SupplierName, '—') AS SupplierName
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
        public Product GetProductById(int productId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = @"
                                SELECT ProductID, ProductCode, ProductName, Category,
                                UnitPrice, QuantityInStock, ReorderLevel, SupplierID
                                FROM Products WHERE ProductID = @id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", productId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Product
                            {
                                ProductID = (int)reader["ProductID"],
                                ProductCode = reader["ProductCode"].ToString(),
                                ProductName = reader["ProductName"].ToString(),
                                Category = reader["Category"] == DBNull.Value ? "" : reader["Category"].ToString(),
                                UnitPrice = Convert.ToDecimal(reader["UnitPrice"]),
                                QuantityInStock = (int)reader["QuantityInStock"],
                                ReorderLevel = (int)reader["ReorderLevel"],
                                SupplierID = reader["SupplierID"] == DBNull.Value ? 0 : (int)reader["SupplierID"]
                            };
                        }
                    }
                }
            }
            return null;
        }
        public int AddProduct(Product product)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = @"
                    INSERT INTO Products 
                        (ProductCode, ProductName, Category, UnitPrice,
                         QuantityInStock, ReorderLevel, SupplierID)
                    VALUES 
                        (@code, @name, @cat, @price, @qty, @reorder, @supplier);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@code", product.ProductCode);
                    cmd.Parameters.AddWithValue("@name", product.ProductName);
                    cmd.Parameters.AddWithValue("@cat",
                        string.IsNullOrWhiteSpace(product.Category) ? (object)DBNull.Value : product.Category);
                    cmd.Parameters.AddWithValue("@price", product.UnitPrice);
                    cmd.Parameters.AddWithValue("@qty", product.QuantityInStock);
                    cmd.Parameters.AddWithValue("@reorder", product.ReorderLevel);
                    cmd.Parameters.AddWithValue("@supplier",
                        product.SupplierID > 0 ? (object)product.SupplierID : DBNull.Value);

                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }
        public bool UpdateProduct(Product product)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = @"
                    UPDATE Products SET
                        ProductCode = @code,
                        ProductName = @name,
                        Category = @cat,
                        UnitPrice = @price,
                        QuantityInStock = @qty,
                        ReorderLevel = @reorder,
                        SupplierID = @supplier
                    WHERE ProductID = @id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", product.ProductID);
                    cmd.Parameters.AddWithValue("@code", product.ProductCode);
                    cmd.Parameters.AddWithValue("@name", product.ProductName);
                    cmd.Parameters.AddWithValue("@cat",
                        string.IsNullOrWhiteSpace(product.Category) ? (object)DBNull.Value : product.Category);
                    cmd.Parameters.AddWithValue("@price", product.UnitPrice);
                    cmd.Parameters.AddWithValue("@qty", product.QuantityInStock);
                    cmd.Parameters.AddWithValue("@reorder", product.ReorderLevel);
                    cmd.Parameters.AddWithValue("@supplier",
                        product.SupplierID > 0 ? (object)product.SupplierID : DBNull.Value);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public bool DeleteProduct(int productId)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(
                    "DELETE FROM Products WHERE ProductID = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", productId);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public DataTable SearchProducts(string searchTerm, string categoryFilter)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = @"
                    SELECT 
                        p.ProductID, p.ProductCode, p.ProductName,
                        ISNULL(p.Category, 'Uncategorized') AS Category,
                        p.UnitPrice, p.QuantityInStock, p.ReorderLevel,
                        p.SupplierID, ISNULL(s.SupplierName, '—') AS SupplierName
                    FROM Products p
                    LEFT JOIN Suppliers s ON p.SupplierID = s.SupplierID
                    WHERE 1=1";

                if (!string.IsNullOrWhiteSpace(searchTerm))
                    query += " AND (p.ProductCode LIKE @search OR p.ProductName LIKE @search)";
                if (!string.IsNullOrWhiteSpace(categoryFilter) && categoryFilter != "All Categories")
                    query += " AND p.Category = @cat";
                query += " ORDER BY p.ProductName";

                using (var cmd = new SqlCommand(query, conn))
                {
                    if (!string.IsNullOrWhiteSpace(searchTerm))
                        cmd.Parameters.AddWithValue("@search", "%" + searchTerm + "%");
                    if (!string.IsNullOrWhiteSpace(categoryFilter) && categoryFilter != "All Categories")   
                    cmd.Parameters.AddWithValue("@cat", categoryFilter);
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
                    @"SELECT DISTINCT Category FROM Products 
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
        public DataTable GetAllSuppliers()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var adapter = new SqlDataAdapter(
                    "SELECT SupplierID, SupplierName FROM Suppliers ORDER BY SupplierName", conn))

                {
                    var dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
        public bool ProductCodeExists(string code, int excludeId = 0)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Products WHERE ProductCode = @code AND ProductID <> @id", conn))
                {
                    cmd.Parameters.AddWithValue("@code", code);
                    cmd.Parameters.AddWithValue("@id", excludeId);
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }
    }
}
