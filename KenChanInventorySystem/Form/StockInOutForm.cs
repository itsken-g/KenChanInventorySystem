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
    public partial class TransactionForm : System.Windows.Forms.Form
    {
        private readonly TransactionService _transactionService = new TransactionService();
        private readonly Users _currentUser;

        private readonly Color InColor = Color.FromArgb(16, 185, 129);
        private readonly Color OutColor = Color.FromArgb(220, 38, 38);
        public TransactionForm()
        {
            InitializeComponent();
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
        }
        public TransactionForm(Users user) : this()
        {
            _currentUser = user;
        }

        private void TransactionForm_Load(object sender, EventArgs e)
        {
            ClearForm();

            LoadProducts();
            LoadTransactions();
        }
        private void LoadProducts()
        {
            try
            {
                var dt = _transactionService.GetAllProducts();
                cmbProduct.DataSource = dt;
                cmbProduct.DisplayMember = "Display";
                cmbProduct.ValueMember = "ProductID";
                cmbProduct.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load products:\n" + ex.Message, "Error");
            }
        }
        private void LoadTransactions()
        {
            try
            {
                dgvTransactions.DataSource = null;
                dgvTransactions.AutoGenerateColumns = true;
                dgvTransactions.AutoGenerateColumns = true;
                DataTable dt = _transactionService.GetAllTransactions();
                dgvTransactions.DataSource = dt;

                if (dgvTransactions.Columns.Contains("TransactionID"))
                    dgvTransactions.Columns["TransactionID"].Visible = false;

                if (dgvTransactions.Columns.Contains("TransactionDate"))
                    dgvTransactions.Columns["TransactionDate"].HeaderText = "Date";
                if (dgvTransactions.Columns.Contains("ProductCode"))
                    dgvTransactions.Columns["ProductCode"].HeaderText = "Code";
                if (dgvTransactions.Columns.Contains("ProductName"))
                    dgvTransactions.Columns["ProductName"].HeaderText = "Product";
                if (dgvTransactions.Columns.Contains("TransactionType"))
                    dgvTransactions.Columns["TransactionType"].HeaderText = "Type";
                if (dgvTransactions.Columns.Contains("Quantity"))
                    dgvTransactions.Columns["Quantity"].HeaderText = "Qty";
                if (dgvTransactions.Columns.Contains("Notes"))
                    dgvTransactions.Columns["Notes"].HeaderText = "Notes";
                if (dgvTransactions.Columns.Contains("Username"))
                    dgvTransactions.Columns["Username"].HeaderText = "By";

                int todayCount = _transactionService.GetTodayTransactionCount();
                lblStatus.Text = $"Ready  |  Stock Transactions  |  {todayCount} today";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load transactions:\n" + ex.Message, "Error");
            }
        }
        private void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateStockPreview();
        }

        private void rbStockIn_CheckedChanged(object sender, EventArgs e)
        {
            UpdateStockPreview();
        }

        private void rbStockOut_CheckedChanged(object sender, EventArgs e)
        {
            UpdateStockPreview();
        }

        private void numQuantity_ValueChanged(object sender, EventArgs e)
        {
            UpdateStockPreview();
        }
        private void UpdateStockPreview()
        {
            if (cmbProduct.SelectedValue == null)
            {
                lblCurrentStockValue.Text = "0";
                lblNewStockValue.Text = "0";
                return;
            }

            try
            {
                int productId = (int)cmbProduct.SelectedValue;
                int current = _transactionService.GetCurrentStock(productId);
                int qty = (int)numQuantity.Value;
                bool isStockIn = rbStockIn.Checked;

                int newStock = isStockIn ? current + qty : current - qty;
                if (newStock < 0) newStock = 0;

                lblCurrentStockValue.Text = current.ToString();
                lblNewStockValue.Text = newStock.ToString();
                lblNewStockValue.ForeColor = isStockIn ? InColor : OutColor;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Preview calculation error: " + ex.Message);
                lblCurrentStockValue.Text = "0";
                lblNewStockValue.Text = "0";
            }
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedValue == null)
            {
                MessageBox.Show("Please select a product.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbProduct.Focus();
                return;
            }

            if (!rbStockIn.Checked && !rbStockOut.Checked)
            {
                MessageBox.Show("Please select Stock In or Stock Out.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numQuantity.Value <= 0)
            {
                MessageBox.Show("Quantity must be greater than 0.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numQuantity.Focus();
                return;
            }

            int productId = (int)cmbProduct.SelectedValue;
            string type = rbStockIn.Checked ? "IN" : "OUT";
            int quantity = (int)numQuantity.Value;
            string notes = txtNotes.Text.Trim();
            int userId = _currentUser?.UserID ?? 0;

            try
            {
                bool success = _transactionService.RecordTransaction(
                    productId, type, quantity, notes, userId);

                if (success)
                {
                    MessageBox.Show(
                        $"Transaction recorded!\n\n" +
                        $"Product: {cmbProduct.Text}\n" +
                        $"Type: {(type == "IN" ? "Stock IN" : "Stock OUT")}\n" +
                        $"Quantity: {quantity}",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadProducts();
                    LoadTransactions();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("The database rejected the transaction. Please check your service layer logic or database tables.",
              "Database Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Transaction failed:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string term = txtSearch.Text.Trim();

                if (string.IsNullOrWhiteSpace(term))
                {
                    LoadTransactions();
                    return;
                }

                dgvTransactions.DataSource = _transactionService.SearchTransactions(term);

                if (dgvTransactions.Columns.Contains("TransactionID"))
                    dgvTransactions.Columns["TransactionID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search failed:\n" + ex.Message, "Error");
            }
        }
        private void btnClearForm_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
        private void ClearForm()
        {
            cmbProduct.SelectedIndexChanged -= cmbProduct_SelectedIndexChanged;
            rbStockIn.CheckedChanged -= rbStockIn_CheckedChanged;
            rbStockOut.CheckedChanged -= rbStockOut_CheckedChanged;
            numQuantity.ValueChanged -= numQuantity_ValueChanged;

            cmbProduct.SelectedIndex = -1;
            rbStockIn.Checked = false;
            rbStockOut.Checked = false;
            numQuantity.Value = 1;
            txtNotes.Clear();

            lblCurrentStockValue.Text = "0";
            lblNewStockValue.Text = "0";
            lblNewStockValue.ForeColor = InColor;

            cmbProduct.SelectedIndexChanged += cmbProduct_SelectedIndexChanged;
            rbStockIn.CheckedChanged += rbStockIn_CheckedChanged;
            rbStockOut.CheckedChanged += rbStockOut_CheckedChanged;
            numQuantity.ValueChanged += numQuantity_ValueChanged;

            dgvTransactions.Refresh();
            cmbProduct.Focus();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnlTopHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSubmit_Click_1(object sender, EventArgs e)
        {

        }

        private void btnClearForm_Click_1(object sender, EventArgs e)
        {

        }
    }
}
