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

namespace KenChanInventorySystem.Forms
{
    public partial class SupplierForm : System.Windows.Forms.Form
    {
        private readonly SuppliersService _supplierService = new SuppliersService();
        private int _selectedSupplierId = -1;
        public SupplierForm()
        {
            InitializeComponent();
        }

        private void SupplierForm_Load(object sender, EventArgs e)
        {
            LoadSuppliers();
            ClearForm();
        }
        private void LoadSuppliers()
        {
            try
            {
                dgvSuppliers.DataSource = _supplierService.GetAllSuppliers();

                if (dgvSuppliers.Columns.Contains("SupplierID"))
                    dgvSuppliers.Columns["SupplierID"].Visible = false;

                if (dgvSuppliers.Columns.Contains("SupplierName"))
                    dgvSuppliers.Columns["SupplierName"].HeaderText = "Supplier Name";
                if (dgvSuppliers.Columns.Contains("ContactPerson"))
                    dgvSuppliers.Columns["ContactPerson"].HeaderText = "Contact";
                if (dgvSuppliers.Columns.Contains("Phone"))
                    dgvSuppliers.Columns["Phone"].HeaderText = "Phone";
                if (dgvSuppliers.Columns.Contains("Email"))
                    dgvSuppliers.Columns["Email"].HeaderText = "Email";
                if (dgvSuppliers.Columns.Contains("Address"))
                    dgvSuppliers.Columns["Address"].HeaderText = "Address";

                lblStatus.Text = $"Ready  |  Supplier Management  |  {dgvSuppliers.Rows.Count} suppliers";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load suppliers:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RunSearch()
        {
            try
            {
                string term = txtSearch.Text.Trim();

                if (string.IsNullOrWhiteSpace(term))
                {
                    LoadSuppliers();
                    return;
                }

                dgvSuppliers.DataSource = _supplierService.SearchSuppliers(term);

                if (dgvSuppliers.Columns.Contains("SupplierID"))
                    dgvSuppliers.Columns["SupplierID"].Visible = false;

                lblStatus.Text = $"Filtered  |  {dgvSuppliers.Rows.Count} suppliers found";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search failed:\n" + ex.Message, "Error");
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
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
            LoadSuppliers();
        }
        private void dgvSuppliers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvSuppliers.Rows[e.RowIndex];
            _selectedSupplierId = Convert.ToInt32(row.Cells["SupplierID"].Value);

            txtSupplierName.Text = row.Cells["SupplierName"].Value?.ToString() ?? "";
            txtContactPerson.Text = row.Cells["ContactPerson"].Value?.ToString() ?? "";
            txtPhone.Text = row.Cells["Phone"].Value?.ToString() ?? "";
            txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";
            txtAddress.Text = row.Cells["Address"].Value?.ToString() ?? "";

            btnAdd.Enabled = false;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            try
            {
                var supplier = BuildSupplierFromForm();

                if (_supplierService.SupplierNameExists(supplier.SupplierName))
                {
                    MessageBox.Show("Supplier name already exists.", "Duplicate",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSupplierName.Focus();
                    return;
                }

                int newId = _supplierService.AddSupplier(supplier);
                if (newId > 0)
                {
                    MessageBox.Show("Supplier added successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadSuppliers();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add failed:\n" + ex.Message, "Error");
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedSupplierId <= 0)
            {
                MessageBox.Show("Please select a supplier first.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateForm()) return;

            try
            {
                var supplier = BuildSupplierFromForm();
                supplier.SupplierID = _selectedSupplierId;

                if (_supplierService.SupplierNameExists(supplier.SupplierName, _selectedSupplierId))
                {
                    MessageBox.Show("Supplier name already exists.", "Duplicate",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (_supplierService.UpdateSupplier(supplier))
                {
                    MessageBox.Show("Supplier updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadSuppliers();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update failed:\n" + ex.Message, "Error");
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedSupplierId <= 0)
            {
                MessageBox.Show("Please select a supplier first.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                "Are you sure you want to delete this supplier?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes) return;

            try
            {
                if (_supplierService.DeleteSupplier(_selectedSupplierId))
                {
                    MessageBox.Show("Supplier deleted successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadSuppliers();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Delete failed:\n" + ex.Message, "Error");
            }
        }
        private Suppliers BuildSupplierFromForm()
        {
            return new Suppliers
            {
                SupplierName = txtSupplierName.Text.Trim(),
                ContactPerson = txtContactPerson.Text.Trim(),
                Phone = txtPhone.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Address = txtAddress.Text.Trim()
            };
        }
        private void btnClearForm_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
        private void ClearForm()
        {
            _selectedSupplierId = -1;
            txtSupplierName.Clear();
            txtContactPerson.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            txtSupplierName.Focus();
        }
        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtSupplierName.Text))
            {
                MessageBox.Show("Supplier Name is required.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSupplierName.Focus();
                return false;
            }
            return true;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
