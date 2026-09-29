using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KenChanInventorySystem.Models;
using KenChanInventorySystem.Services;

namespace KenChanInventorySystem.Forms
{
    public partial class DashboardForm : System.Windows.Forms.Form
    {
        private readonly Users _currentUser;
        private readonly DashboardService _dashboardService = new DashboardService();
        private readonly Color NavActiveColor = Color.FromArgb(30, 58, 138);
        private readonly Color NavInactiveColor = Color.FromArgb(31, 41, 55);
        public DashboardForm()
        {
            InitializeComponent();
        }
        internal DashboardForm(Users user) : this() 
        {
            _currentUser = user;
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnNavDashboard_Click(object sender, EventArgs e)
        {
            HighlightNavButton(btnNavDashboard);
            LoadDashboardData();
            loadCategoryFilter();
            LoadCategoryBreakdown();
        }

        private void btnNavProducts_Click(object sender, EventArgs e)
        {
            HighlightNavButton(btnNavProducts);

            using (var productForm = new ProductForm())
            {
                productForm.ShowDialog(this);
            }
            LoadDashboardData();
            loadCategoryFilter();
            LoadCategoryBreakdown();
        }

        private void btnNavSuppliers_Click(object sender, EventArgs e)
        {
            HighlightNavButton(btnNavDashboard);
            NotYet("Suppliers", "wla mi ani sir huhhu");
        }

        private void btnNavTransactions_Click(object sender, EventArgs e)
        {
            HighlightNavButton(btnNavTransactions);
            NotYet("Transactions", "wla pa siiir huhu");
        }

        private void btnNavReports_Click(object sender, EventArgs e)
        {
            HighlightNavButton(btnNavReports);
            NotYet("Reports", "wla pa mi ani sir HUUHUU"); ;
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            if (_currentUser != null)
            {
                lblWelcome.Text = $"Welcome, {_currentUser.Username} ({_currentUser.Role})";
                lblStatus.Text =
                    $"Ready  |  Kenchan Store  |  Logged in: {_currentUser.Username}";
            }

            LoadDashboardData();
            loadCategoryFilter();
            LoadCategoryBreakdown();
            HighlightNavButton(btnNavDashboard);
        }
        private void LoadDashboardData()
        {
            try
            {
                lblTotalProducts.Text = _dashboardService.GetTotalProducts().ToString();
                lblLowStock.Text = _dashboardService.GetLowStockCount().ToString();
                lblTotalSuppliers.Text = _dashboardService.GetTotalSuppliers().ToString();
                lblTodayTransactions.Text = _dashboardService.GetTodayTransactionsCount().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load dashboard data:\n" + ex.Message,
                    "Dashboard Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void loadCategoryFilter()
        {
            try
            {
                var cats = _dashboardService.GetCategories();
                cmbCategoryFilter.Items.Clear();
                foreach (var c in cats) cmbCategoryFilter.Items.Add(c);
                if (cmbCategoryFilter.Items.Count > 0)
                    cmbCategoryFilter.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load categories:\n" + ex.Message,
                    "Category Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadCategoryBreakdown()
        {
            try
            {
                var dt = _dashboardService.GetCategoryBreakdown();
                lstCategories.Items.Clear();

                if (dt.Rows.Count == 0)
                {
                    lstCategories.Items.Add("No products yet");
                    return;
                }

                foreach (System.Data.DataRow row in dt.Rows)
                    lstCategories.Items.Add(
                        $"{row["Category"],-20} {row["ProductCount"],5}");
            }
            catch (Exception ex)
            {
                lstCategories.Items.Clear();
                lstCategories.Items.Add("Error: " + ex.Message);
            }
        }
        private void RunSearch()
        {
            try
            {
                string term = txtSearch.Text.Trim();
                string cat = cmbCategoryFilter.SelectedItem?.ToString() ?? "All Categories";

                if (string.IsNullOrWhiteSpace(term) && cat == "All Categories")
                {
                    dgvSearchResults.DataSource = null;
                    lblSearchResultsTitle.Text = "🔍 Search Results";
                    return;
                }

                var dt = _dashboardService.SearchProducts(term, cat);

                dgvSearchResults.DataSource = dt;

                lblSearchResultsTitle.Text = $"🔍 Search Results ({dt.Rows.Count} found)";
                if (dgvSearchResults.Columns.Contains("ProductID"))
                    dgvSearchResults.Columns["ProductID"].HeaderText = "ID";
                if (dgvSearchResults.Columns.Contains("ProductCode"))
                    dgvSearchResults.Columns["ProductCode"].HeaderText = "Code";
                if (dgvSearchResults.Columns.Contains("ProductName"))
                    dgvSearchResults.Columns["ProductName"].HeaderText = "Product";
                if (dgvSearchResults.Columns.Contains("Category"))
                    dgvSearchResults.Columns["Category"].HeaderText = "Category";
                if (dgvSearchResults.Columns.Contains("QuantityInStock"))
                    dgvSearchResults.Columns["QuantityInStock"].HeaderText = "Stock";
                if (dgvSearchResults.Columns.Contains("ReorderLevel"))
                    dgvSearchResults.Columns["ReorderLevel"].HeaderText = "Reorder";
                if (dgvSearchResults.Columns.Contains("UnitPrice"))
                    dgvSearchResults.Columns["UnitPrice"].HeaderText = "Price";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search failed:\n" + ex.Message,
                    "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e) => RunSearch();
        private void cmbCategoryFilter_SelectedIndexChanged(object sender, EventArgs e) => RunSearch();
        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            if (cmbCategoryFilter.Items.Count > 0)
                cmbCategoryFilter.SelectedIndex = 0;
            dgvSearchResults.DataSource = null;
            lblSearchResultsTitle.Text = " Search Results";
        }
        private void HighlightNavButton(Button active)
        {
            Button[] navButtons = {
                btnNavDashboard, btnNavDashboard, btnNavDashboard,
                btnNavTransactions, btnNavReports
            };
            foreach (var btn in navButtons)
            {
                if (btn == null) continue;
                btn.BackColor = (btn == active) ? NavActiveColor : NavInactiveColor;
            }
        }

        private void btnNewProduct_Click(object sender, EventArgs e)
        {
            HighlightNavButton(btnNavProducts);

            using (var productForm = new ProductForm())
            {
                productForm.ShowDialog(this);
            }
            LoadDashboardData();
            loadCategoryFilter();
            LoadCategoryBreakdown();
        }

        private void btnStockIn_Click(object sender, EventArgs e)
        {
            HighlightNavButton(btnNavTransactions);
            NotYet("Stock In", "stuck pa mi sir");
        }

        private void btnStockOut_Click(object sender, EventArgs e)
        {
            HighlightNavButton(btnNavTransactions);
            NotYet("Stock Out", "humanon lng namo ni sir");
        }

        private void btnNewSupplier_Click(object sender, EventArgs e)
        {
            HighlightNavButton(btnNavDashboard);
            NotYet("New Supplier", "sabay ni sa supplier sir");
        }

        private void btnViewReports_Click(object sender, EventArgs e)
        {
            HighlightNavButton(btnNavReports);
            NotYet("Reports", "pinaka last na ni sir");
        }
        private void NotYet(string feature, string phase)
        {
            MessageBox.Show($"{feature} — coming in {phase}.",
                "Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnLogout_Click(object sender, EventArgs e) => Logout();

        private void Logout()
        {
            var confirm = MessageBox.Show(
                "Are you sure you want to log out?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            var login = new LoginForm();
            login.FormClosed += (s, args) => this.Close();
            login.Show();
            this.Hide();
        }

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}