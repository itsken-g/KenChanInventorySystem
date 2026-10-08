using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using KenChanInventorySystem.Services;
namespace KenChanInventorySystem.Forms
{
    public partial class ReportsForm : System.Windows.Forms.Form
    {
        private readonly ReportService _reportService = new ReportService();
        public ReportsForm()
        {
            InitializeComponent();
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            dtpFrom.Value = DateTime.Today.AddDays(-30);
            dtpTo.Value = DateTime.Today;

            rbInventorySummary.Checked = true;

            lblStatus.Text = "Ready  |  Reports  |  Select a report and click Generate";
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbInventorySummary.Checked)
                    GenerateInventorySummary();
                else if (rbLowStock.Checked)
                    GenerateLowStockReport();
                else if (rbTransactionHistory.Checked)
                    GenerateTransactionHistory();
                else
                    MessageBox.Show("Please select a report type.", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to generate report:\n" + ex.Message,
                    "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GenerateInventorySummary()
        {
            DataTable dt = _reportService.GetInventorySummary();

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No products found.", "Empty Report",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            LoadReportIntoViewer(dt, "InventoryReport.rpt");
            lblStatus.Text = $"Ready  |  Inventory Summary  |  {dt.Rows.Count} products";
        }
        private void GenerateLowStockReport()
        {
            DataTable dt = _reportService.GetLowStockReport();

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No low-stock items found. Inventory is healthy!",
                    "Empty Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            LoadReportIntoViewer(dt, "LowStockReport.rpt");
            lblStatus.Text = $"Ready  |  Low Stock Report  |  {dt.Rows.Count} items";
        }
        private void GenerateTransactionHistory()
        {
            DataTable dt = _reportService.GetTransactionHistory(dtpFrom.Value, dtpTo.Value);

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No transactions found in the selected date range.",
                    "Empty Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            LoadReportIntoViewer(dt, "TransactionHistoryReport.rpt");
            lblStatus.Text = $"Ready  |  Transaction History  |  {dt.Rows.Count} transactions";
        }
        private void LoadReportIntoViewer(DataTable dt, string reportFileName)
        {
            var report = new ReportDocument();

            string path = Path.Combine(
                Application.StartupPath, "Reports", reportFileName);

            if (!File.Exists(path))
            {
                MessageBox.Show(
                    $"Report file not found at:\n{path}\n\n" +
                    $"Set '{reportFileName}'s 'Copy to Output Directory' to 'Copy always' and rebuild.",
                    "Missing File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            report.Load(path);
            dt.TableName = "Products";
            report.SetDataSource(dt);

            crystalReportViewer1.ReportSource = report;
            crystalReportViewer1.RefreshReport();
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (crystalReportViewer1.ReportSource == null)
            {
                MessageBox.Show("Please generate a report first.",
                    "No Report", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                crystalReportViewer1.PrintReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Print failed:\n" + ex.Message,
                    "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            if (crystalReportViewer1.ReportSource == null)
            {
                MessageBox.Show("Please generate a report first.",
                    "No Report", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "PDF Files (*.pdf)|*.pdf",
                FileName = "KenchanReport_" + DateTime.Now.ToString("yyyyMMdd_HHmmss")
            };

            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                var report = (ReportDocument)crystalReportViewer1.ReportSource;
                report.ExportToDisk(ExportFormatType.PortableDocFormat, sfd.FileName);

                MessageBox.Show("PDF exported successfully!\n\nSaved to:\n" + sfd.FileName,
                    "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Export failed:\n" + ex.Message,
                    "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void pnlTopHeader_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
