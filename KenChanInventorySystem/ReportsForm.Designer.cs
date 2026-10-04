namespace KenChanInventorySystem
{
    partial class ReportsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlTopHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlHeaderRight = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.lblOptionsTitle = new System.Windows.Forms.Label();
            this.lblReportType = new System.Windows.Forms.Label();
            this.rbInventorySummary = new System.Windows.Forms.RadioButton();
            this.rbLowStock = new System.Windows.Forms.RadioButton();
            this.rbTransactionHistory = new System.Windows.Forms.RadioButton();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnExportPdf = new System.Windows.Forms.Button();
            this.pnlViewer = new System.Windows.Forms.Panel();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.pnlTopHeader.SuspendLayout();
            this.pnlHeaderRight.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlOptions.SuspendLayout();
            this.pnlViewer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTopHeader
            // 
            this.pnlTopHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(138)))));
            this.pnlTopHeader.Controls.Add(this.pnlHeaderRight);
            this.pnlTopHeader.Controls.Add(this.lblTitle);
            this.pnlTopHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlTopHeader.Name = "pnlTopHeader";
            this.pnlTopHeader.Size = new System.Drawing.Size(1555, 60);
            this.pnlTopHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(25, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(171, 29);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📄 REPORTS";
            // 
            // pnlHeaderRight
            // 
            this.pnlHeaderRight.BackColor = System.Drawing.Color.Transparent;
            this.pnlHeaderRight.Controls.Add(this.btnClose);
            this.pnlHeaderRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlHeaderRight.Location = new System.Drawing.Point(1355, 0);
            this.pnlHeaderRight.Name = "pnlHeaderRight";
            this.pnlHeaderRight.Size = new System.Drawing.Size(200, 60);
            this.pnlHeaderRight.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(20, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(160, 36);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "✖ Close";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.pnlFooter.Controls.Add(this.lblStatus);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 867);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1555, 36);
            this.pnlFooter.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(213)))), ((int)(((byte)(219)))));
            this.lblStatus.Location = new System.Drawing.Point(0, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblStatus.Size = new System.Drawing.Size(372, 18);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Ready | Reports | Select a report and click Generate";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlViewer);
            this.pnlMain.Controls.Add(this.pnlOptions);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 60);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1555, 807);
            this.pnlMain.TabIndex = 2;
            // 
            // pnlOptions
            // 
            this.pnlOptions.BackColor = System.Drawing.Color.White;
            this.pnlOptions.Controls.Add(this.btnExportPdf);
            this.pnlOptions.Controls.Add(this.btnPrint);
            this.pnlOptions.Controls.Add(this.btnGenerate);
            this.pnlOptions.Controls.Add(this.dtpTo);
            this.pnlOptions.Controls.Add(this.lblTo);
            this.pnlOptions.Controls.Add(this.dtpFrom);
            this.pnlOptions.Controls.Add(this.lblFrom);
            this.pnlOptions.Controls.Add(this.rbTransactionHistory);
            this.pnlOptions.Controls.Add(this.rbLowStock);
            this.pnlOptions.Controls.Add(this.rbInventorySummary);
            this.pnlOptions.Controls.Add(this.lblReportType);
            this.pnlOptions.Controls.Add(this.lblOptionsTitle);
            this.pnlOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOptions.Location = new System.Drawing.Point(0, 0);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Padding = new System.Windows.Forms.Padding(25, 20, 25, 20);
            this.pnlOptions.Size = new System.Drawing.Size(1555, 150);
            this.pnlOptions.TabIndex = 0;
            // 
            // lblOptionsTitle
            // 
            this.lblOptionsTitle.AutoSize = true;
            this.lblOptionsTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOptionsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblOptionsTitle.Location = new System.Drawing.Point(25, 15);
            this.lblOptionsTitle.Name = "lblOptionsTitle";
            this.lblOptionsTitle.Size = new System.Drawing.Size(186, 22);
            this.lblOptionsTitle.TabIndex = 0;
            this.lblOptionsTitle.Text = "REPORT OPTIONS";
            // 
            // lblReportType
            // 
            this.lblReportType.AutoSize = true;
            this.lblReportType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblReportType.Location = new System.Drawing.Point(25, 50);
            this.lblReportType.Name = "lblReportType";
            this.lblReportType.Size = new System.Drawing.Size(117, 20);
            this.lblReportType.TabIndex = 1;
            this.lblReportType.Text = "Report Type:";
            // 
            // rbInventorySummary
            // 
            this.rbInventorySummary.AutoSize = true;
            this.rbInventorySummary.Checked = true;
            this.rbInventorySummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbInventorySummary.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(138)))));
            this.rbInventorySummary.Location = new System.Drawing.Point(25, 75);
            this.rbInventorySummary.Name = "rbInventorySummary";
            this.rbInventorySummary.Size = new System.Drawing.Size(213, 24);
            this.rbInventorySummary.TabIndex = 2;
            this.rbInventorySummary.TabStop = true;
            this.rbInventorySummary.Text = "📦 Inventory Summary";
            this.rbInventorySummary.UseVisualStyleBackColor = true;
            // 
            // rbLowStock
            // 
            this.rbLowStock.AutoSize = true;
            this.rbLowStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbLowStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.rbLowStock.Location = new System.Drawing.Point(240, 75);
            this.rbLowStock.Name = "rbLowStock";
            this.rbLowStock.Size = new System.Drawing.Size(140, 24);
            this.rbLowStock.TabIndex = 3;
            this.rbLowStock.TabStop = true;
            this.rbLowStock.Text = "⚠ Low Stock";
            this.rbLowStock.UseVisualStyleBackColor = true;
            // 
            // rbTransactionHistory
            // 
            this.rbTransactionHistory.AutoSize = true;
            this.rbTransactionHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTransactionHistory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(92)))), ((int)(((byte)(246)))));
            this.rbTransactionHistory.Location = new System.Drawing.Point(405, 75);
            this.rbTransactionHistory.Name = "rbTransactionHistory";
            this.rbTransactionHistory.Size = new System.Drawing.Size(219, 24);
            this.rbTransactionHistory.TabIndex = 4;
            this.rbTransactionHistory.TabStop = true;
            this.rbTransactionHistory.Text = "📊 Transaction History";
            this.rbTransactionHistory.UseVisualStyleBackColor = true;
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblFrom.Location = new System.Drawing.Point(25, 105);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(53, 20);
            this.lblFrom.TabIndex = 5;
            this.lblFrom.Text = "From:";
            // 
            // dtpFrom
            // 
            this.dtpFrom.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(75, 102);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(150, 24);
            this.dtpFrom.TabIndex = 6;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.lblTo.Location = new System.Drawing.Point(240, 105);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(33, 20);
            this.lblTo.TabIndex = 7;
            this.lblTo.Text = "To:";
            // 
            // dtpTo
            // 
            this.dtpTo.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTo.Location = new System.Drawing.Point(270, 102);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(150, 24);
            this.dtpTo.TabIndex = 8;
            // 
            // btnGenerate
            // 
            this.btnGenerate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(138)))));
            this.btnGenerate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerate.FlatAppearance.BorderSize = 0;
            this.btnGenerate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.ForeColor = System.Drawing.Color.White;
            this.btnGenerate.Location = new System.Drawing.Point(450, 100);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(160, 32);
            this.btnGenerate.TabIndex = 9;
            this.btnGenerate.Text = "🔄 Generate Report";
            this.btnGenerate.UseVisualStyleBackColor = false;
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(625, 100);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 32);
            this.btnPrint.TabIndex = 10;
            this.btnPrint.Text = "🖨 Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            // 
            // btnExportPdf
            // 
            this.btnExportPdf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(92)))), ((int)(((byte)(246)))));
            this.btnExportPdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportPdf.FlatAppearance.BorderSize = 0;
            this.btnExportPdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportPdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportPdf.ForeColor = System.Drawing.Color.White;
            this.btnExportPdf.Location = new System.Drawing.Point(735, 100);
            this.btnExportPdf.Name = "btnExportPdf";
            this.btnExportPdf.Size = new System.Drawing.Size(140, 32);
            this.btnExportPdf.TabIndex = 11;
            this.btnExportPdf.Text = "💾 Export PDF";
            this.btnExportPdf.UseVisualStyleBackColor = false;
            // 
            // pnlViewer
            // 
            this.pnlViewer.BackColor = System.Drawing.Color.White;
            this.pnlViewer.Controls.Add(this.crystalReportViewer1);
            this.pnlViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlViewer.Location = new System.Drawing.Point(0, 150);
            this.pnlViewer.Name = "pnlViewer";
            this.pnlViewer.Padding = new System.Windows.Forms.Padding(10);
            this.pnlViewer.Size = new System.Drawing.Size(1555, 657);
            this.pnlViewer.TabIndex = 1;
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(10, 10);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ShowGroupTreeButton = false;
            this.crystalReportViewer1.Size = new System.Drawing.Size(1535, 637);
            this.crystalReportViewer1.TabIndex = 0;
            // 
            // ReportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(1555, 903);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlTopHeader);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "ReportsForm";
            this.Text = "Kenchan Store — Reports";
            this.pnlTopHeader.ResumeLayout(false);
            this.pnlTopHeader.PerformLayout();
            this.pnlHeaderRight.ResumeLayout(false);
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlOptions.ResumeLayout(false);
            this.pnlOptions.PerformLayout();
            this.pnlViewer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTopHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlHeaderRight;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.Label lblOptionsTitle;
        private System.Windows.Forms.Label lblReportType;
        private System.Windows.Forms.RadioButton rbLowStock;
        private System.Windows.Forms.RadioButton rbInventorySummary;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.RadioButton rbTransactionHistory;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Panel pnlViewer;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Button btnExportPdf;
    }
}