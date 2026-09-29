namespace KenChanInventorySystem.Forms
{
    partial class DashboardForm
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlHeaderRight = new System.Windows.Forms.Panel();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblAppName = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pnlSidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.lblNavTitle = new System.Windows.Forms.Label();
            this.pnlNavDivider = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNavDashboard = new System.Windows.Forms.Button();
            this.btnNavProducts = new System.Windows.Forms.Button();
            this.btnNavSuppliers = new System.Windows.Forms.Button();
            this.btnNavTransactions = new System.Windows.Forms.Button();
            this.btnNavReports = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnViewReports = new System.Windows.Forms.Button();
            this.btnNewSupplier = new System.Windows.Forms.Button();
            this.btnStockOut = new System.Windows.Forms.Button();
            this.btnStockIn = new System.Windows.Forms.Button();
            this.btnNewProduct = new System.Windows.Forms.Button();
            this.lblQuickActions = new System.Windows.Forms.Label();
            this.pnlSearchResults = new System.Windows.Forms.Panel();
            this.dgvSearchResults = new System.Windows.Forms.DataGridView();
            this.lblSearchResultsTitle = new System.Windows.Forms.Label();
            this.pnlCategoryBreakdown = new System.Windows.Forms.Panel();
            this.lstCategories = new System.Windows.Forms.ListBox();
            this.lblCatTitle = new System.Windows.Forms.Label();
            this.pnlCardToday = new System.Windows.Forms.Panel();
            this.lblTodayTransactions = new System.Windows.Forms.Label();
            this.lblCardTodayTitle = new System.Windows.Forms.Label();
            this.pnlCardSuppliers = new System.Windows.Forms.Panel();
            this.lblTotalSuppliers = new System.Windows.Forms.Label();
            this.lblCardSuppliersTitle = new System.Windows.Forms.Label();
            this.pnlCardLowStock = new System.Windows.Forms.Panel();
            this.lblLowStock = new System.Windows.Forms.Label();
            this.lblCardLowStockTitle = new System.Windows.Forms.Label();
            this.pnlCardProducts = new System.Windows.Forms.Panel();
            this.lblTotalProducts = new System.Windows.Forms.Label();
            this.lblCardProductsTitle = new System.Windows.Forms.Label();
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.cmbCategoryFilter = new System.Windows.Forms.ComboBox();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearchIcon = new System.Windows.Forms.Label();
            this.lblDashTitle = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlHeaderRight.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlSearchResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchResults)).BeginInit();
            this.pnlCategoryBreakdown.SuspendLayout();
            this.pnlCardToday.SuspendLayout();
            this.pnlCardSuppliers.SuspendLayout();
            this.pnlCardLowStock.SuspendLayout();
            this.pnlCardProducts.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(138)))));
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHeader.Controls.Add(this.pnlHeaderRight);
            this.pnlHeader.Controls.Add(this.lblAppName);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.MaximumSize = new System.Drawing.Size(2, 80);
            this.pnlHeader.MinimumSize = new System.Drawing.Size(2, 80);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlHeader.Size = new System.Drawing.Size(2, 80);
            this.pnlHeader.TabIndex = 0;
            this.pnlHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlHeader_Paint);
            // 
            // pnlHeaderRight
            // 
            this.pnlHeaderRight.BackColor = System.Drawing.Color.Transparent;
            this.pnlHeaderRight.Controls.Add(this.btnLogout);
            this.pnlHeaderRight.Controls.Add(this.lblWelcome);
            this.pnlHeaderRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlHeaderRight.Location = new System.Drawing.Point(-400, 0);
            this.pnlHeaderRight.MaximumSize = new System.Drawing.Size(400, 80);
            this.pnlHeaderRight.MinimumSize = new System.Drawing.Size(400, 80);
            this.pnlHeaderRight.Name = "pnlHeaderRight";
            this.pnlHeaderRight.Size = new System.Drawing.Size(400, 80);
            this.pnlHeaderRight.TabIndex = 2;
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(228, 21);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(150, 40);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Location = new System.Drawing.Point(3, 30);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(202, 23);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome, admin (Admin)";
            // 
            // lblAppName
            // 
            this.lblAppName.AutoSize = true;
            this.lblAppName.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppName.ForeColor = System.Drawing.Color.White;
            this.lblAppName.Location = new System.Drawing.Point(30, 25);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(579, 35);
            this.lblAppName.TabIndex = 0;
            this.lblAppName.Text = "🏪 KENCHAN STORE — Inventory Management";
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.pnlFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFooter.Controls.Add(this.lblStatus);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 1019);
            this.pnlFooter.MaximumSize = new System.Drawing.Size(2, 36);
            this.pnlFooter.MinimumSize = new System.Drawing.Size(2, 36);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(2, 36);
            this.pnlFooter.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(213)))), ((int)(((byte)(219)))));
            this.lblStatus.Location = new System.Drawing.Point(0, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblStatus.Size = new System.Drawing.Size(317, 20);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "\"Ready | Kenchan Store | Logged in: admin\"";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            this.pnlSidebar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSidebar.Controls.Add(this.lblNavTitle);
            this.pnlSidebar.Controls.Add(this.pnlNavDivider);
            this.pnlSidebar.Controls.Add(this.btnNavDashboard);
            this.pnlSidebar.Controls.Add(this.btnNavProducts);
            this.pnlSidebar.Controls.Add(this.btnNavSuppliers);
            this.pnlSidebar.Controls.Add(this.btnNavTransactions);
            this.pnlSidebar.Controls.Add(this.btnNavReports);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(138)))));
            this.pnlSidebar.Location = new System.Drawing.Point(0, 80);
            this.pnlSidebar.MaximumSize = new System.Drawing.Size(240, 2);
            this.pnlSidebar.MinimumSize = new System.Drawing.Size(240, 2);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(240, 2);
            this.pnlSidebar.TabIndex = 2;
            // 
            // lblNavTitle
            // 
            this.lblNavTitle.AutoSize = true;
            this.lblNavTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblNavTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNavTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNavTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(163)))), ((int)(((byte)(175)))));
            this.lblNavTitle.Location = new System.Drawing.Point(3, 0);
            this.lblNavTitle.MaximumSize = new System.Drawing.Size(0, 45);
            this.lblNavTitle.MinimumSize = new System.Drawing.Size(0, 45);
            this.lblNavTitle.Name = "lblNavTitle";
            this.lblNavTitle.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.lblNavTitle.Size = new System.Drawing.Size(129, 45);
            this.lblNavTitle.TabIndex = 5;
            this.lblNavTitle.Text = "NAVIGATION";
            this.lblNavTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlNavDivider
            // 
            this.pnlNavDivider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.pnlNavDivider.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlNavDivider.Location = new System.Drawing.Point(3, 48);
            this.pnlNavDivider.MinimumSize = new System.Drawing.Size(0, 1);
            this.pnlNavDivider.Name = "pnlNavDivider";
            this.pnlNavDivider.Size = new System.Drawing.Size(200, 1);
            this.pnlNavDivider.TabIndex = 6;
            // 
            // btnNavDashboard
            // 
            this.btnNavDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavDashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.btnNavDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavDashboard.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavDashboard.ForeColor = System.Drawing.Color.White;
            this.btnNavDashboard.Location = new System.Drawing.Point(3, 55);
            this.btnNavDashboard.MinimumSize = new System.Drawing.Size(0, 55);
            this.btnNavDashboard.Name = "btnNavDashboard";
            this.btnNavDashboard.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnNavDashboard.Size = new System.Drawing.Size(200, 55);
            this.btnNavDashboard.TabIndex = 7;
            this.btnNavDashboard.Text = "Dashboard";
            this.btnNavDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavDashboard.UseVisualStyleBackColor = true;
            this.btnNavDashboard.Click += new System.EventHandler(this.btnNavDashboard_Click);
            // 
            // btnNavProducts
            // 
            this.btnNavProducts.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavProducts.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.btnNavProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavProducts.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavProducts.ForeColor = System.Drawing.Color.White;
            this.btnNavProducts.Location = new System.Drawing.Point(3, 116);
            this.btnNavProducts.MinimumSize = new System.Drawing.Size(0, 55);
            this.btnNavProducts.Name = "btnNavProducts";
            this.btnNavProducts.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnNavProducts.Size = new System.Drawing.Size(200, 55);
            this.btnNavProducts.TabIndex = 8;
            this.btnNavProducts.Text = "Products";
            this.btnNavProducts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavProducts.UseVisualStyleBackColor = true;
            this.btnNavProducts.Click += new System.EventHandler(this.btnNavProducts_Click);
            // 
            // btnNavSuppliers
            // 
            this.btnNavSuppliers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavSuppliers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.btnNavSuppliers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavSuppliers.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavSuppliers.ForeColor = System.Drawing.Color.White;
            this.btnNavSuppliers.Location = new System.Drawing.Point(3, 177);
            this.btnNavSuppliers.MinimumSize = new System.Drawing.Size(0, 55);
            this.btnNavSuppliers.Name = "btnNavSuppliers";
            this.btnNavSuppliers.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnNavSuppliers.Size = new System.Drawing.Size(200, 55);
            this.btnNavSuppliers.TabIndex = 9;
            this.btnNavSuppliers.Text = "Suppliers";
            this.btnNavSuppliers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavSuppliers.UseVisualStyleBackColor = true;
            this.btnNavSuppliers.Click += new System.EventHandler(this.btnNavSuppliers_Click);
            // 
            // btnNavTransactions
            // 
            this.btnNavTransactions.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavTransactions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.btnNavTransactions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavTransactions.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavTransactions.ForeColor = System.Drawing.Color.White;
            this.btnNavTransactions.Location = new System.Drawing.Point(3, 238);
            this.btnNavTransactions.MinimumSize = new System.Drawing.Size(0, 55);
            this.btnNavTransactions.Name = "btnNavTransactions";
            this.btnNavTransactions.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnNavTransactions.Size = new System.Drawing.Size(200, 55);
            this.btnNavTransactions.TabIndex = 10;
            this.btnNavTransactions.Text = "Stock In/Out";
            this.btnNavTransactions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavTransactions.UseVisualStyleBackColor = true;
            this.btnNavTransactions.Click += new System.EventHandler(this.btnNavTransactions_Click);
            // 
            // btnNavReports
            // 
            this.btnNavReports.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavReports.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.btnNavReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavReports.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavReports.ForeColor = System.Drawing.Color.White;
            this.btnNavReports.Location = new System.Drawing.Point(3, 299);
            this.btnNavReports.MinimumSize = new System.Drawing.Size(0, 55);
            this.btnNavReports.Name = "btnNavReports";
            this.btnNavReports.Padding = new System.Windows.Forms.Padding(25, 0, 0, 0);
            this.btnNavReports.Size = new System.Drawing.Size(200, 55);
            this.btnNavReports.TabIndex = 11;
            this.btnNavReports.Text = "Reports";
            this.btnNavReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavReports.UseVisualStyleBackColor = true;
            this.btnNavReports.Click += new System.EventHandler(this.btnNavReports_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.AutoSize = true;
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Controls.Add(this.btnViewReports);
            this.pnlMain.Controls.Add(this.btnNewSupplier);
            this.pnlMain.Controls.Add(this.btnStockOut);
            this.pnlMain.Controls.Add(this.btnStockIn);
            this.pnlMain.Controls.Add(this.btnNewProduct);
            this.pnlMain.Controls.Add(this.lblQuickActions);
            this.pnlMain.Controls.Add(this.pnlSearchResults);
            this.pnlMain.Controls.Add(this.pnlCategoryBreakdown);
            this.pnlMain.Controls.Add(this.pnlCardToday);
            this.pnlMain.Controls.Add(this.pnlCardSuppliers);
            this.pnlMain.Controls.Add(this.pnlCardLowStock);
            this.pnlMain.Controls.Add(this.pnlCardProducts);
            this.pnlMain.Controls.Add(this.btnClearFilter);
            this.pnlMain.Controls.Add(this.cmbCategoryFilter);
            this.pnlMain.Controls.Add(this.pnlSearch);
            this.pnlMain.Controls.Add(this.lblDashTitle);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlMain.ForeColor = System.Drawing.Color.White;
            this.pnlMain.Location = new System.Drawing.Point(240, 80);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(40);
            this.pnlMain.Size = new System.Drawing.Size(1642, 939);
            this.pnlMain.TabIndex = 3;
            // 
            // btnViewReports
            // 
            this.btnViewReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.btnViewReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewReports.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewReports.ForeColor = System.Drawing.Color.White;
            this.btnViewReports.Location = new System.Drawing.Point(840, 670);
            this.btnViewReports.Name = "btnViewReports";
            this.btnViewReports.Size = new System.Drawing.Size(190, 60);
            this.btnViewReports.TabIndex = 15;
            this.btnViewReports.Text = "View Reports";
            this.btnViewReports.UseVisualStyleBackColor = false;
            this.btnViewReports.Click += new System.EventHandler(this.btnViewReports_Click);
            // 
            // btnNewSupplier
            // 
            this.btnNewSupplier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(92)))), ((int)(((byte)(246)))));
            this.btnNewSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewSupplier.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewSupplier.ForeColor = System.Drawing.Color.White;
            this.btnNewSupplier.Location = new System.Drawing.Point(640, 670);
            this.btnNewSupplier.Name = "btnNewSupplier";
            this.btnNewSupplier.Size = new System.Drawing.Size(190, 60);
            this.btnNewSupplier.TabIndex = 14;
            this.btnNewSupplier.Text = "New Supplier";
            this.btnNewSupplier.UseVisualStyleBackColor = false;
            this.btnNewSupplier.Click += new System.EventHandler(this.btnNewSupplier_Click);
            // 
            // btnStockOut
            // 
            this.btnStockOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(158)))), ((int)(((byte)(11)))));
            this.btnStockOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStockOut.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStockOut.ForeColor = System.Drawing.Color.White;
            this.btnStockOut.Location = new System.Drawing.Point(440, 670);
            this.btnStockOut.Name = "btnStockOut";
            this.btnStockOut.Size = new System.Drawing.Size(190, 60);
            this.btnStockOut.TabIndex = 13;
            this.btnStockOut.Text = "Stock Out";
            this.btnStockOut.UseVisualStyleBackColor = false;
            this.btnStockOut.Click += new System.EventHandler(this.btnStockOut_Click);
            // 
            // btnStockIn
            // 
            this.btnStockIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(138)))));
            this.btnStockIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStockIn.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStockIn.ForeColor = System.Drawing.Color.White;
            this.btnStockIn.Location = new System.Drawing.Point(240, 670);
            this.btnStockIn.Name = "btnStockIn";
            this.btnStockIn.Size = new System.Drawing.Size(190, 60);
            this.btnStockIn.TabIndex = 12;
            this.btnStockIn.Text = "Stock In";
            this.btnStockIn.UseVisualStyleBackColor = false;
            this.btnStockIn.Click += new System.EventHandler(this.btnStockIn_Click);
            // 
            // btnNewProduct
            // 
            this.btnNewProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnNewProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewProduct.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewProduct.ForeColor = System.Drawing.Color.White;
            this.btnNewProduct.Location = new System.Drawing.Point(40, 670);
            this.btnNewProduct.Name = "btnNewProduct";
            this.btnNewProduct.Size = new System.Drawing.Size(190, 60);
            this.btnNewProduct.TabIndex = 11;
            this.btnNewProduct.Text = "New Product";
            this.btnNewProduct.UseVisualStyleBackColor = false;
            this.btnNewProduct.Click += new System.EventHandler(this.btnNewProduct_Click);
            // 
            // lblQuickActions
            // 
            this.lblQuickActions.AutoSize = true;
            this.lblQuickActions.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuickActions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblQuickActions.Location = new System.Drawing.Point(40, 620);
            this.lblQuickActions.Name = "lblQuickActions";
            this.lblQuickActions.Size = new System.Drawing.Size(155, 30);
            this.lblQuickActions.TabIndex = 10;
            this.lblQuickActions.Text = "Quick Actions";
            // 
            // pnlSearchResults
            // 
            this.pnlSearchResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSearchResults.Controls.Add(this.dgvSearchResults);
            this.pnlSearchResults.Controls.Add(this.lblSearchResultsTitle);
            this.pnlSearchResults.Location = new System.Drawing.Point(560, 340);
            this.pnlSearchResults.Name = "pnlSearchResults";
            this.pnlSearchResults.Size = new System.Drawing.Size(700, 250);
            this.pnlSearchResults.TabIndex = 9;
            // 
            // dgvSearchResults
            // 
            this.dgvSearchResults.AllowUserToAddRows = false;
            this.dgvSearchResults.AllowUserToDeleteRows = false;
            this.dgvSearchResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSearchResults.BackgroundColor = System.Drawing.Color.White;
            this.dgvSearchResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSearchResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearchResults.Location = new System.Drawing.Point(15, 50);
            this.dgvSearchResults.Name = "dgvSearchResults";
            this.dgvSearchResults.ReadOnly = true;
            this.dgvSearchResults.RowHeadersVisible = false;
            this.dgvSearchResults.RowHeadersWidth = 51;
            this.dgvSearchResults.RowTemplate.Height = 24;
            this.dgvSearchResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSearchResults.Size = new System.Drawing.Size(670, 185);
            this.dgvSearchResults.TabIndex = 1;
            this.dgvSearchResults.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // lblSearchResultsTitle
            // 
            this.lblSearchResultsTitle.AutoSize = true;
            this.lblSearchResultsTitle.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchResultsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblSearchResultsTitle.Location = new System.Drawing.Point(15, 15);
            this.lblSearchResultsTitle.Name = "lblSearchResultsTitle";
            this.lblSearchResultsTitle.Size = new System.Drawing.Size(135, 25);
            this.lblSearchResultsTitle.TabIndex = 0;
            this.lblSearchResultsTitle.Text = "Search Results";
            // 
            // pnlCategoryBreakdown
            // 
            this.pnlCategoryBreakdown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCategoryBreakdown.Controls.Add(this.lstCategories);
            this.pnlCategoryBreakdown.Controls.Add(this.lblCatTitle);
            this.pnlCategoryBreakdown.Location = new System.Drawing.Point(40, 340);
            this.pnlCategoryBreakdown.Name = "pnlCategoryBreakdown";
            this.pnlCategoryBreakdown.Size = new System.Drawing.Size(500, 250);
            this.pnlCategoryBreakdown.TabIndex = 8;
            // 
            // lstCategories
            // 
            this.lstCategories.BackColor = System.Drawing.Color.White;
            this.lstCategories.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstCategories.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstCategories.ForeColor = System.Drawing.Color.Black;
            this.lstCategories.FormattingEnabled = true;
            this.lstCategories.ItemHeight = 20;
            this.lstCategories.Location = new System.Drawing.Point(15, 50);
            this.lstCategories.Name = "lstCategories";
            this.lstCategories.Size = new System.Drawing.Size(470, 180);
            this.lstCategories.TabIndex = 1;
            // 
            // lblCatTitle
            // 
            this.lblCatTitle.AutoSize = true;
            this.lblCatTitle.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCatTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblCatTitle.Location = new System.Drawing.Point(15, 15);
            this.lblCatTitle.Name = "lblCatTitle";
            this.lblCatTitle.Size = new System.Drawing.Size(184, 25);
            this.lblCatTitle.TabIndex = 0;
            this.lblCatTitle.Text = "Products by Category";
            // 
            // pnlCardToday
            // 
            this.pnlCardToday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardToday.Controls.Add(this.lblTodayTransactions);
            this.pnlCardToday.Controls.Add(this.lblCardTodayTitle);
            this.pnlCardToday.Location = new System.Drawing.Point(880, 160);
            this.pnlCardToday.Name = "pnlCardToday";
            this.pnlCardToday.Size = new System.Drawing.Size(260, 150);
            this.pnlCardToday.TabIndex = 6;
            // 
            // lblTodayTransactions
            // 
            this.lblTodayTransactions.AutoSize = true;
            this.lblTodayTransactions.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTodayTransactions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(92)))), ((int)(((byte)(246)))));
            this.lblTodayTransactions.Location = new System.Drawing.Point(27, 60);
            this.lblTodayTransactions.Name = "lblTodayTransactions";
            this.lblTodayTransactions.Size = new System.Drawing.Size(70, 81);
            this.lblTodayTransactions.TabIndex = 4;
            this.lblTodayTransactions.Text = "0";
            // 
            // lblCardTodayTitle
            // 
            this.lblCardTodayTitle.AutoSize = true;
            this.lblCardTodayTitle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardTodayTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblCardTodayTitle.Location = new System.Drawing.Point(20, 20);
            this.lblCardTodayTitle.Name = "lblCardTodayTitle";
            this.lblCardTodayTitle.Size = new System.Drawing.Size(164, 23);
            this.lblCardTodayTitle.TabIndex = 0;
            this.lblCardTodayTitle.Text = "Today\'s Transactions";
            // 
            // pnlCardSuppliers
            // 
            this.pnlCardSuppliers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardSuppliers.Controls.Add(this.lblTotalSuppliers);
            this.pnlCardSuppliers.Controls.Add(this.lblCardSuppliersTitle);
            this.pnlCardSuppliers.Location = new System.Drawing.Point(600, 160);
            this.pnlCardSuppliers.Name = "pnlCardSuppliers";
            this.pnlCardSuppliers.Size = new System.Drawing.Size(260, 150);
            this.pnlCardSuppliers.TabIndex = 5;
            // 
            // lblTotalSuppliers
            // 
            this.lblTotalSuppliers.AutoSize = true;
            this.lblTotalSuppliers.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSuppliers.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblTotalSuppliers.Location = new System.Drawing.Point(20, 60);
            this.lblTotalSuppliers.Name = "lblTotalSuppliers";
            this.lblTotalSuppliers.Size = new System.Drawing.Size(70, 81);
            this.lblTotalSuppliers.TabIndex = 3;
            this.lblTotalSuppliers.Text = "0";
            // 
            // lblCardSuppliersTitle
            // 
            this.lblCardSuppliersTitle.AutoSize = true;
            this.lblCardSuppliersTitle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardSuppliersTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblCardSuppliersTitle.Location = new System.Drawing.Point(20, 20);
            this.lblCardSuppliersTitle.Name = "lblCardSuppliersTitle";
            this.lblCardSuppliersTitle.Size = new System.Drawing.Size(79, 23);
            this.lblCardSuppliersTitle.TabIndex = 0;
            this.lblCardSuppliersTitle.Text = "Suppliers";
            // 
            // pnlCardLowStock
            // 
            this.pnlCardLowStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardLowStock.Controls.Add(this.lblLowStock);
            this.pnlCardLowStock.Controls.Add(this.lblCardLowStockTitle);
            this.pnlCardLowStock.Location = new System.Drawing.Point(320, 160);
            this.pnlCardLowStock.Name = "pnlCardLowStock";
            this.pnlCardLowStock.Size = new System.Drawing.Size(260, 150);
            this.pnlCardLowStock.TabIndex = 0;
            // 
            // lblLowStock
            // 
            this.lblLowStock.AutoSize = true;
            this.lblLowStock.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowStock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblLowStock.Location = new System.Drawing.Point(20, 60);
            this.lblLowStock.Name = "lblLowStock";
            this.lblLowStock.Size = new System.Drawing.Size(70, 81);
            this.lblLowStock.TabIndex = 2;
            this.lblLowStock.Text = "0";
            // 
            // lblCardLowStockTitle
            // 
            this.lblCardLowStockTitle.AutoSize = true;
            this.lblCardLowStockTitle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardLowStockTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblCardLowStockTitle.Location = new System.Drawing.Point(20, 20);
            this.lblCardLowStockTitle.Name = "lblCardLowStockTitle";
            this.lblCardLowStockTitle.Size = new System.Drawing.Size(85, 23);
            this.lblCardLowStockTitle.TabIndex = 1;
            this.lblCardLowStockTitle.Text = "Low Stock";
            // 
            // pnlCardProducts
            // 
            this.pnlCardProducts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlCardProducts.Controls.Add(this.lblTotalProducts);
            this.pnlCardProducts.Controls.Add(this.lblCardProductsTitle);
            this.pnlCardProducts.Location = new System.Drawing.Point(40, 160);
            this.pnlCardProducts.Name = "pnlCardProducts";
            this.pnlCardProducts.Size = new System.Drawing.Size(260, 150);
            this.pnlCardProducts.TabIndex = 4;
            // 
            // lblTotalProducts
            // 
            this.lblTotalProducts.AutoSize = true;
            this.lblTotalProducts.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalProducts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(58)))), ((int)(((byte)(138)))));
            this.lblTotalProducts.Location = new System.Drawing.Point(20, 60);
            this.lblTotalProducts.Name = "lblTotalProducts";
            this.lblTotalProducts.Size = new System.Drawing.Size(70, 81);
            this.lblTotalProducts.TabIndex = 1;
            this.lblTotalProducts.Text = "0";
            // 
            // lblCardProductsTitle
            // 
            this.lblCardProductsTitle.AutoSize = true;
            this.lblCardProductsTitle.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCardProductsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(114)))), ((int)(((byte)(128)))));
            this.lblCardProductsTitle.Location = new System.Drawing.Point(20, 20);
            this.lblCardProductsTitle.Name = "lblCardProductsTitle";
            this.lblCardProductsTitle.Size = new System.Drawing.Size(118, 23);
            this.lblCardProductsTitle.TabIndex = 0;
            this.lblCardProductsTitle.Text = "Total Products";
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.btnClearFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearFilter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(65)))), ((int)(((byte)(81)))));
            this.btnClearFilter.Location = new System.Drawing.Point(1177, 90);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(100, 39);
            this.btnClearFilter.TabIndex = 3;
            this.btnClearFilter.Text = "✖ Clear";
            this.btnClearFilter.UseVisualStyleBackColor = false;
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);
            // 
            // cmbCategoryFilter
            // 
            this.cmbCategoryFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoryFilter.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategoryFilter.FormattingEnabled = true;
            this.cmbCategoryFilter.Location = new System.Drawing.Point(960, 92);
            this.cmbCategoryFilter.Name = "cmbCategoryFilter";
            this.cmbCategoryFilter.Size = new System.Drawing.Size(200, 31);
            this.cmbCategoryFilter.TabIndex = 2;
            // 
            // pnlSearch
            // 
            this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSearch.Controls.Add(this.txtSearch);
            this.pnlSearch.Controls.Add(this.lblSearchIcon);
            this.pnlSearch.Location = new System.Drawing.Point(40, 85);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(900, 46);
            this.pnlSearch.TabIndex = 1;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(45, 8);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(840, 24);
            this.txtSearch.TabIndex = 1;
            // 
            // lblSearchIcon
            // 
            this.lblSearchIcon.AutoSize = true;
            this.lblSearchIcon.BackColor = System.Drawing.Color.White;
            this.lblSearchIcon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchIcon.ForeColor = System.Drawing.Color.Black;
            this.lblSearchIcon.Location = new System.Drawing.Point(12, 8);
            this.lblSearchIcon.Name = "lblSearchIcon";
            this.lblSearchIcon.Size = new System.Drawing.Size(39, 28);
            this.lblSearchIcon.TabIndex = 0;
            this.lblSearchIcon.Text = "🔍";
            // 
            // lblDashTitle
            // 
            this.lblDashTitle.AutoSize = true;
            this.lblDashTitle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDashTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(24)))), ((int)(((byte)(39)))));
            this.lblDashTitle.Location = new System.Drawing.Point(40, 40);
            this.lblDashTitle.Name = "lblDashTitle";
            this.lblDashTitle.Size = new System.Drawing.Size(261, 35);
            this.lblDashTitle.TabIndex = 0;
            this.lblDashTitle.Text = "Dashboard Overview";
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(244)))), ((int)(((byte)(246)))));
            this.ClientSize = new System.Drawing.Size(1882, 1055);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlSidebar);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(1366, 948);
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kenchan Store — Inventory Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlHeaderRight.ResumeLayout(false);
            this.pnlHeaderRight.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebar.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlSearchResults.ResumeLayout(false);
            this.pnlSearchResults.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSearchResults)).EndInit();
            this.pnlCategoryBreakdown.ResumeLayout(false);
            this.pnlCategoryBreakdown.PerformLayout();
            this.pnlCardToday.ResumeLayout(false);
            this.pnlCardToday.PerformLayout();
            this.pnlCardSuppliers.ResumeLayout(false);
            this.pnlCardSuppliers.PerformLayout();
            this.pnlCardLowStock.ResumeLayout(false);
            this.pnlCardLowStock.PerformLayout();
            this.pnlCardProducts.ResumeLayout(false);
            this.pnlCardProducts.PerformLayout();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.FlowLayoutPanel pnlSidebar;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Label lblDashTitle;
        private System.Windows.Forms.ComboBox cmbCategoryFilter;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearchIcon;
        private System.Windows.Forms.Panel pnlCardProducts;
        private System.Windows.Forms.Label lblCardProductsTitle;
        private System.Windows.Forms.Button btnClearFilter;
        private System.Windows.Forms.Panel pnlCardLowStock;
        private System.Windows.Forms.Label lblTotalProducts;
        private System.Windows.Forms.Label lblLowStock;
        private System.Windows.Forms.Label lblCardLowStockTitle;
        private System.Windows.Forms.Panel pnlCardToday;
        private System.Windows.Forms.Label lblCardTodayTitle;
        private System.Windows.Forms.Panel pnlCardSuppliers;
        private System.Windows.Forms.Label lblTotalSuppliers;
        private System.Windows.Forms.Label lblCardSuppliersTitle;
        private System.Windows.Forms.Panel pnlCategoryBreakdown;
        private System.Windows.Forms.Label lblTodayTransactions;
        private System.Windows.Forms.ListBox lstCategories;
        private System.Windows.Forms.Label lblCatTitle;
        private System.Windows.Forms.Panel pnlSearchResults;
        private System.Windows.Forms.DataGridView dgvSearchResults;
        private System.Windows.Forms.Label lblSearchResultsTitle;
        private System.Windows.Forms.Button btnNewProduct;
        private System.Windows.Forms.Label lblQuickActions;
        private System.Windows.Forms.Button btnViewReports;
        private System.Windows.Forms.Button btnNewSupplier;
        private System.Windows.Forms.Button btnStockOut;
        private System.Windows.Forms.Button btnStockIn;
        private System.Windows.Forms.Label lblNavTitle;
        private System.Windows.Forms.FlowLayoutPanel pnlNavDivider;
        private System.Windows.Forms.Button btnNavDashboard;
        private System.Windows.Forms.Button btnNavProducts;
        private System.Windows.Forms.Button btnNavSuppliers;
        private System.Windows.Forms.Button btnNavTransactions;
        private System.Windows.Forms.Button btnNavReports;
        private System.Windows.Forms.Panel pnlHeaderRight;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label lblWelcome;
    }
}