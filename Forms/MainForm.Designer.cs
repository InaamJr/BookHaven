namespace BookHaven.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            btnManageUsers = new Button();
            btnGenerateReports = new Button();
            btnManageBooks = new Button();
            btnManageCustomers = new Button();
            btnLogout = new Button();
            btnManageOrders = new Button();
            btnSalesTransaction = new Button();
            btnSupplierManagement = new Button();
            btnAdminDashboard = new Button();
            SuspendLayout();
            // 
            // btnManageUsers
            // 
            btnManageUsers.BackColor = Color.MediumAquamarine;
            btnManageUsers.Font = new Font("SF Pro Display", 9.75F, FontStyle.Bold);
            btnManageUsers.Location = new Point(367, 157);
            btnManageUsers.Name = "btnManageUsers";
            btnManageUsers.Size = new Size(120, 60);
            btnManageUsers.TabIndex = 0;
            btnManageUsers.Text = "Manage Users";
            btnManageUsers.UseVisualStyleBackColor = false;
            btnManageUsers.Click += btnManageUsers_Click;
            // 
            // btnGenerateReports
            // 
            btnGenerateReports.BackColor = Color.MediumAquamarine;
            btnGenerateReports.Font = new Font("SF Pro Display", 9.75F, FontStyle.Bold);
            btnGenerateReports.Location = new Point(544, 157);
            btnGenerateReports.Name = "btnGenerateReports";
            btnGenerateReports.Size = new Size(120, 60);
            btnGenerateReports.TabIndex = 1;
            btnGenerateReports.Text = "Generate \r\nReports";
            btnGenerateReports.UseVisualStyleBackColor = false;
            btnGenerateReports.Click += btnGenerateReports_Click;
            // 
            // btnManageBooks
            // 
            btnManageBooks.BackColor = Color.MediumAquamarine;
            btnManageBooks.Font = new Font("SF Pro Display", 9.75F, FontStyle.Bold);
            btnManageBooks.Location = new Point(461, 251);
            btnManageBooks.Name = "btnManageBooks";
            btnManageBooks.Size = new Size(120, 60);
            btnManageBooks.TabIndex = 2;
            btnManageBooks.Text = "Manage Books";
            btnManageBooks.UseVisualStyleBackColor = false;
            btnManageBooks.Click += btnManageBooks_click;
            // 
            // btnManageCustomers
            // 
            btnManageCustomers.BackColor = Color.MediumAquamarine;
            btnManageCustomers.Font = new Font("SF Pro Display", 9.75F, FontStyle.Bold);
            btnManageCustomers.Location = new Point(272, 251);
            btnManageCustomers.Name = "btnManageCustomers";
            btnManageCustomers.Size = new Size(120, 60);
            btnManageCustomers.TabIndex = 5;
            btnManageCustomers.Text = " Manage Customers";
            btnManageCustomers.UseVisualStyleBackColor = false;
            btnManageCustomers.Click += btnManageCustomers_Click;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.DarkRed;
            btnLogout.Font = new Font("SF Pro Display", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(695, 444);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(103, 43);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "LOGOUT";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnManageOrders
            // 
            btnManageOrders.BackColor = Color.MediumAquamarine;
            btnManageOrders.Font = new Font("SF Pro Display", 9.75F, FontStyle.Bold);
            btnManageOrders.Location = new Point(185, 350);
            btnManageOrders.Name = "btnManageOrders";
            btnManageOrders.Size = new Size(120, 60);
            btnManageOrders.TabIndex = 7;
            btnManageOrders.Text = "Manage \r\nOrders";
            btnManageOrders.UseVisualStyleBackColor = false;
            btnManageOrders.Click += btnManageOrders_Click;
            // 
            // btnSalesTransaction
            // 
            btnSalesTransaction.BackColor = Color.MediumAquamarine;
            btnSalesTransaction.Font = new Font("SF Pro Display", 9.75F, FontStyle.Bold);
            btnSalesTransaction.Location = new Point(367, 350);
            btnSalesTransaction.Name = "btnSalesTransaction";
            btnSalesTransaction.Size = new Size(120, 60);
            btnSalesTransaction.TabIndex = 8;
            btnSalesTransaction.Text = "Sales \r\nTransaction";
            btnSalesTransaction.UseVisualStyleBackColor = false;
            btnSalesTransaction.Click += btnSalesTransaction_Click;
            // 
            // btnSupplierManagement
            // 
            btnSupplierManagement.BackColor = Color.MediumAquamarine;
            btnSupplierManagement.Font = new Font("SF Pro Display", 9.75F, FontStyle.Bold);
            btnSupplierManagement.Location = new Point(544, 350);
            btnSupplierManagement.Name = "btnSupplierManagement";
            btnSupplierManagement.Size = new Size(120, 60);
            btnSupplierManagement.TabIndex = 9;
            btnSupplierManagement.Text = "Supplier Management";
            btnSupplierManagement.UseVisualStyleBackColor = false;
            btnSupplierManagement.Click += btnSupplierManagement_Click;
            // 
            // btnAdminDashboard
            // 
            btnAdminDashboard.BackColor = Color.MediumAquamarine;
            btnAdminDashboard.Font = new Font("SF Pro Display", 9.75F, FontStyle.Bold);
            btnAdminDashboard.Location = new Point(185, 157);
            btnAdminDashboard.Name = "btnAdminDashboard";
            btnAdminDashboard.Size = new Size(120, 60);
            btnAdminDashboard.TabIndex = 10;
            btnAdminDashboard.Text = "Admin \r\nDashboard";
            btnAdminDashboard.UseVisualStyleBackColor = false;
            btnAdminDashboard.Click += btnAdminDashboard_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(848, 530);
            Controls.Add(btnAdminDashboard);
            Controls.Add(btnSupplierManagement);
            Controls.Add(btnSalesTransaction);
            Controls.Add(btnManageOrders);
            Controls.Add(btnLogout);
            Controls.Add(btnManageCustomers);
            Controls.Add(btnManageBooks);
            Controls.Add(btnGenerateReports);
            Controls.Add(btnManageUsers);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            Load += MainForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnManageUsers;
        private Button btnGenerateReports;
        private Button btnManageBooks;
        private Button btnManageCustomers;
        private Button btnLogout;
        private Button btnManageOrders;
        private Button btnSalesTransaction;
        private Button btnSupplierManagement;
        private Button btnAdminDashboard;
    }
}