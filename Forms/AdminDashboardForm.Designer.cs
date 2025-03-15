namespace BookHaven.Forms
{
    partial class AdminDashboardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminDashboardForm));
            groupBox1 = new GroupBox();
            lblLowStockBooks = new Label();
            lblBestSellingBook = new Label();
            lblTotalOrders = new Label();
            lblTotalSales = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dgvStaffPerformance = new DataGridView();
            label5 = new Label();
            btnExit = new Button();
            label6 = new Label();
            label7 = new Label();
            dgvCustomerActivity = new DataGridView();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            btnBusinessSettings = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStaffPerformance).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCustomerActivity).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.Transparent;
            groupBox1.Controls.Add(lblLowStockBooks);
            groupBox1.Controls.Add(lblBestSellingBook);
            groupBox1.Controls.Add(lblTotalOrders);
            groupBox1.Controls.Add(lblTotalSales);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(48, 145);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(390, 219);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Sales And Revenue Overview";
            // 
            // lblLowStockBooks
            // 
            lblLowStockBooks.AutoSize = true;
            lblLowStockBooks.Font = new Font("SF Mono", 9.75F, FontStyle.Bold);
            lblLowStockBooks.ForeColor = Color.DarkRed;
            lblLowStockBooks.Location = new Point(199, 171);
            lblLowStockBooks.Name = "lblLowStockBooks";
            lblLowStockBooks.Size = new Size(0, 16);
            lblLowStockBooks.TabIndex = 7;
            // 
            // lblBestSellingBook
            // 
            lblBestSellingBook.AutoSize = true;
            lblBestSellingBook.Font = new Font("SF Mono", 9.75F, FontStyle.Bold);
            lblBestSellingBook.ForeColor = Color.DarkRed;
            lblBestSellingBook.Location = new Point(198, 127);
            lblBestSellingBook.Name = "lblBestSellingBook";
            lblBestSellingBook.Size = new Size(0, 16);
            lblBestSellingBook.TabIndex = 6;
            // 
            // lblTotalOrders
            // 
            lblTotalOrders.AutoSize = true;
            lblTotalOrders.Font = new Font("SF Mono", 9.75F, FontStyle.Bold);
            lblTotalOrders.ForeColor = Color.DarkRed;
            lblTotalOrders.Location = new Point(199, 85);
            lblTotalOrders.Name = "lblTotalOrders";
            lblTotalOrders.Size = new Size(0, 16);
            lblTotalOrders.TabIndex = 5;
            // 
            // lblTotalSales
            // 
            lblTotalSales.AutoSize = true;
            lblTotalSales.Font = new Font("SF Mono", 9.75F, FontStyle.Bold);
            lblTotalSales.ForeColor = Color.DarkRed;
            lblTotalSales.Location = new Point(199, 43);
            lblTotalSales.Name = "lblTotalSales";
            lblTotalSales.Size = new Size(0, 16);
            lblTotalSales.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("SF Pro Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(26, 169);
            label4.Name = "label4";
            label4.Size = new Size(141, 19);
            label4.TabIndex = 3;
            label4.Text = "Low Stock Books: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("SF Pro Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(26, 125);
            label3.Name = "label3";
            label3.Size = new Size(138, 19);
            label3.TabIndex = 2;
            label3.Text = "Best Selling Book:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("SF Pro Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(26, 83);
            label2.Name = "label2";
            label2.Size = new Size(103, 19);
            label2.TabIndex = 1;
            label2.Text = "Total Orders:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("SF Pro Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(26, 41);
            label1.Name = "label1";
            label1.Size = new Size(92, 19);
            label1.TabIndex = 0;
            label1.Text = "Total Sales:";
            label1.Click += label1_Click;
            // 
            // dgvStaffPerformance
            // 
            dgvStaffPerformance.BackgroundColor = SystemColors.ActiveCaption;
            dgvStaffPerformance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStaffPerformance.Location = new Point(48, 443);
            dgvStaffPerformance.Name = "dgvStaffPerformance";
            dgvStaffPerformance.Size = new Size(390, 200);
            dgvStaffPerformance.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("SF Pro Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(45, 420);
            label5.Name = "label5";
            label5.Size = new Size(188, 19);
            label5.TabIndex = 2;
            label5.Text = "Staff Sales Performance";
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.DarkRed;
            btnExit.Font = new Font("SF Mono", 12F, FontStyle.Bold);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(997, 869);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 41);
            btnExit.TabIndex = 3;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("SF Pro Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(603, 420);
            label6.Name = "label6";
            label6.Size = new Size(156, 19);
            label6.TabIndex = 4;
            label6.Text = "Monthly Sales Chart";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("SF Pro Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(603, 132);
            label7.Name = "label7";
            label7.Size = new Size(142, 19);
            label7.TabIndex = 5;
            label7.Text = "Best Selling Books";
            // 
            // dgvCustomerActivity
            // 
            dgvCustomerActivity.BackgroundColor = SystemColors.ActiveCaption;
            dgvCustomerActivity.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomerActivity.Location = new Point(48, 699);
            dgvCustomerActivity.Name = "dgvCustomerActivity";
            dgvCustomerActivity.Size = new Size(390, 211);
            dgvCustomerActivity.TabIndex = 6;
            dgvCustomerActivity.CellContentClick += dgvCustomerActivity_CellContentClick;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("SF Pro Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(45, 677);
            label8.Name = "label8";
            label8.Size = new Size(208, 19);
            label8.TabIndex = 7;
            label8.Text = "Customer Activity Tracking";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Location = new Point(48, 930);
            label9.Name = "label9";
            label9.Size = new Size(0, 16);
            label9.TabIndex = 8;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = SystemColors.GradientActiveCaption;
            label10.Font = new Font("SF Pro Display", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(477, 51);
            label10.Name = "label10";
            label10.Size = new Size(210, 29);
            label10.TabIndex = 9;
            label10.Text = "Admin Dashboard";
            // 
            // btnBusinessSettings
            // 
            btnBusinessSettings.BackColor = Color.Silver;
            btnBusinessSettings.Font = new Font("SF Mono", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBusinessSettings.ForeColor = Color.Black;
            btnBusinessSettings.Location = new Point(889, 852);
            btnBusinessSettings.Name = "btnBusinessSettings";
            btnBusinessSettings.Size = new Size(102, 58);
            btnBusinessSettings.TabIndex = 10;
            btnBusinessSettings.Text = "Business\r\nSettings";
            btnBusinessSettings.UseVisualStyleBackColor = false;
            btnBusinessSettings.Click += btnBusinessSettings_Click;
            // 
            // AdminDashboardForm
            // 
            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.White;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1120, 707);
            Controls.Add(btnBusinessSettings);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(dgvCustomerActivity);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(btnExit);
            Controls.Add(label5);
            Controls.Add(dgvStaffPerformance);
            Controls.Add(groupBox1);
            Font = new Font("SF Pro Display", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "AdminDashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin Dashboard";
            Load += AdminDashboardForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvStaffPerformance).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCustomerActivity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private Label label4;
        private Label label3;
        private Label label2;
        private DataGridView dgvStaffPerformance;
        private Label lblLowStockBooks;
        private Label lblBestSellingBook;
        private Label lblTotalOrders;
        private Label lblTotalSales;
        private Label label5;
        private Button btnExit;
        private Label label6;
        private Label label7;
        private DataGridView dgvCustomerActivity;
        private Label label8;
        private Label label9;
        private Label label10;
        private Button btnBusinessSettings;
    }
}