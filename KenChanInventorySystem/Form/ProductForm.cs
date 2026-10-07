using KenChanInventorySystem.Models;
using KenChanInventorySystem.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace KenChanInventorySystem.Forms
{
    public partial class ProductForm : System.Windows.Forms.Form
    {

        private readonly ProductService _productService = new ProductService();
        private int _selectedProductId = -1;


        public ProductForm()
        {
            InitializeComponent();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            LoadCategoryFilter();
            LoadSuppliers();
            LoadProducts();
            ClearForm();
        }
        private void LoadProducts()
        {
            try
            {
                dgvProducts.DataSource = _productService.GetAllProducts();

                if (dgvProducts.Columns.Contains("ProductID"))
                    dgvProducts.Columns["ProductID"].Visible = false;
                if (dgvProducts.Columns.Contains("SupplierID"))
                    dgvProducts.Columns["SupplierID"].Visible = false;

                SetColumn("ProductCode", "Code");
                SetColumn("ProductName", "Product Name");
                SetColumn("Category", "Category");
                SetColumn("UnitPrice", "Price (₱)");
                SetColumn("QuantityInStock", "Stock");
                SetColumn("ReorderLevel", "Reorder");
                SetColumn("SupplierName", "Supplier");

                lblStatus.Text = $"Ready  |  Product Management  |  {dgvProducts.Rows.Count} products";
            
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load products:\n" + ex.Message,
            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetColumn(String name, string headerText)
        {
            if (dgvProducts.Columns.Contains(name))
            {
                dgvProducts.Columns[name].HeaderText = headerText;
                dgvProducts.Columns[name].Name = name;
            }
        }
        private void LoadCategoryFilter()
        {
            try
            {
                var cats = _productService.GetCategories();
                cmbCategoryFilter.Items.Clear();
                foreach (var c in cats) cmbCategoryFilter.Items.Add(c);
                if (cmbCategoryFilter.Items.Count > 0)
                    cmbCategoryFilter.SelectedIndex = 0;
            }
            catch { }
        }
        private void LoadSuppliers()
        {
            try
            {
                var dt = _productService.GetAllSuppliers();
                cmbSupplier.DataSource = dt;
                cmbSupplier.DisplayMember = "SupplierName";
                cmbSupplier.ValueMember = "SupplierID";
                cmbSupplier.SelectedIndex = -1;
            }
            catch { }
        }
        private void RunSearch()
        {
            try
            {
                string term = txtSearch.Text.Trim();
                string cat = cmbCategoryFilter.SelectedItem?.ToString() ?? "All Categories";

                if (string.IsNullOrWhiteSpace(term) && cat == "All Categories")
                {
                    LoadProducts();
                    return;
                }
                dgvProducts.DataSource = _productService.SearchProducts(term, cat);

                if (dgvProducts.Columns.Contains("ProductID"))
                    dgvProducts.Columns["ProductID"].Visible = false;
                if (dgvProducts.Columns.Contains("SupplierID"))
                    dgvProducts.Columns["SupplierID"].Visible = false;

                lblStatus.Text = $"Filtered  |  {dgvProducts.Rows.Count} products found";
            
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search failed:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            RunSearch();
        }

        private void cmbCategoryFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            RunSearch();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            RunSearch();
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            if (cmbCategoryFilter.Items.Count > 0)
                cmbCategoryFilter.SelectedIndex = 0;
            LoadProducts();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;
            try
            {
                var product = BuildProductFromForm();

                if (_productService.ProductCodeExists(product.ProductCode))
                {
                    MessageBox.Show("Product code already exists.", "Duplicate",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCode.Focus();
                    return;
                }

                int newId = _productService.AddProduct(product);
                if (newId > 0)
                {
                    MessageBox.Show("Product added successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProducts();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add failed:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedProductId <= 0)
            {
                MessageBox.Show("Please select a product first.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var confirm = MessageBox.Show(
                "Are you sure you want to delete this product?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            try
            {
                if (_productService.DeleteProduct(_selectedProductId))
                {
                    MessageBox.Show("Product deleted successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProducts();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete failed:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedProductId <= 0)
            {
                MessageBox.Show("Please select a product first.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidateForm()) return;
            try
            {
                var product = BuildProductFromForm();
                product.ProductID = _selectedProductId;

                if (_productService.ProductCodeExists(product.ProductCode, _selectedProductId))
                {
                    MessageBox.Show("Product code already exists.", "Duplicate",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_productService.UpdateProduct(product))
                {
                    MessageBox.Show("Product updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProducts();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update failed:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Product BuildProductFromForm()
        {
            return new Product
            {
                ProductCode = txtCode.Text.Trim(),
                ProductName = txtName.Text.Trim(),
                Category = cmbCategory.Text.Trim(),
                UnitPrice = numPrice.Value,
                QuantityInStock = (int)numStock.Value,
                ReorderLevel = (int)numReorder.Value,
                SupplierID = cmbSupplier.SelectedValue == null
                                    ? 0
                                    : (int)cmbSupplier.SelectedValue
            };
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
        private void ClearForm()
        {
            _selectedProductId = -1;
            txtCode.Clear();
            txtName.Clear();
            cmbCategory.SelectedItem = -1;
            numPrice.Value = 0;
            numStock.Value = 0;
            numReorder.Value = 10;
            cmbSupplier.SelectedIndex = -1;

            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            txtCode.Focus();
        }
        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtCode.Text))
            {
                MessageBox.Show("Product Code is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Product Name is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cmbCategory.Text))
            {
                MessageBox.Show("Please select a Category.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategory.Focus();
                return false;
            }

            if (numPrice.Value <= 0)
            {
                MessageBox.Show("Price must be greater than 0.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numPrice.Focus();
                return false;
            }
            return true;
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvProducts.Rows[e.RowIndex];
            _selectedProductId = GetCellInt(row, "ProductID");
            txtCode.Text = GetCellString(row, "ProductCode");
            txtName.Text = GetCellString(row, "ProductName");
            cmbCategory.Text = GetCellString(row, "Category");
            numPrice.Value = GetCellDecimal(row, "UnitPrice");
            numStock.Value = GetCellInt(row, "QuantityInStock");
            numReorder.Value = GetCellInt(row, "ReorderLevel");

            if (dgvProducts.Columns.Contains("SupplierID") && row.Cells["SupplierID"].Value != DBNull.Value)
                cmbSupplier.SelectedValue = row.Cells["SuuplierID"].Value;
            else
                cmbSupplier.SelectedIndex = -1;

            btnAdd.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private string GetCellString(DataGridViewRow row, string columnName)
        {
            if (!dgvProducts.Columns.Contains(columnName)) return "";
            var val = row.Cells[columnName].Value;
            return val == null || val == DBNull.Value ? "" : val.ToString();
        }
        private int GetCellInt(DataGridViewRow row, string columnName)
        {
            if (!dgvProducts.Columns.Contains(columnName)) return 0;
            var val = row.Cells[columnName].Value;
            return val == null || val == DBNull.Value ? 0 : Convert.ToInt32(val);
        }
        private decimal GetCellDecimal(DataGridViewRow row, string columnName)
        {
            if (!dgvProducts.Columns.Contains(columnName)) return 0;
            var val = row.Cells[columnName].Value;
            return val == null || val == DBNull.Value ? 0m : Convert.ToDecimal(val);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnlTopHeader_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
