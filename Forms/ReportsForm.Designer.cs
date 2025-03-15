namespace BookHaven.Forms
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
            label1 = new Label();
            button1 = new Button();
            label2 = new Label();
            dtpStartDate = new DateTimePicker();
            dtpEndDate = new DateTimePicker();
            label3 = new Label();
            label4 = new Label();
            btnFilterSalesReport = new Button();
            dgvSalesReport = new DataGridView();
            btnExportSalesExcel = new Button();
            label5 = new Label();
            dgvInventoryReport = new DataGridView();
            btnExportSalesPDF = new Button();
            btnExportInventoryPDF = new Button();
            btnExportInventoryExcel = new Button();
            btnExportStaffPDF = new Button();
            btnExportStaffExcel = new Button();
            dgvStaffPerformanceReport = new DataGridView();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            cmbReportType = new ComboBox();
            btnSaveReport = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSalesReport).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvInventoryReport).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvStaffPerformanceReport).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("SF Pro Display", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(436, 37);
            label1.Name = "label1";
            label1.Size = new Size(275, 29);
            label1.TabIndex = 0;
            label1.Text = "Reporting and Analytics";
            // 
            // button1
            // 
            button1.Font = new Font("SF Mono", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.DarkRed;
            button1.Location = new Point(1061, 12);
            button1.Name = "button1";
            button1.Size = new Size(75, 38);
            button1.TabIndex = 1;
            button1.Text = "EXIT";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("SF Pro Display", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DimGray;
            label2.Location = new Point(45, 122);
            label2.Name = "label2";
            label2.Size = new Size(106, 20);
            label2.TabIndex = 2;
            label2.Text = "Sales Report";
            // 
            // dtpStartDate
            // 
            dtpStartDate.Location = new Point(45, 194);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(200, 23);
            dtpStartDate.TabIndex = 3;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Location = new Point(271, 194);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(200, 23);
            dtpEndDate.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(45, 175);
            label3.Name = "label3";
            label3.Size = new Size(103, 16);
            label3.TabIndex = 5;
            label3.Text = "Start Date :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(271, 175);
            label4.Name = "label4";
            label4.Size = new Size(87, 16);
            label4.TabIndex = 6;
            label4.Text = "End Date :";
            // 
            // btnFilterSalesReport
            // 
            btnFilterSalesReport.Location = new Point(498, 190);
            btnFilterSalesReport.Name = "btnFilterSalesReport";
            btnFilterSalesReport.Size = new Size(75, 31);
            btnFilterSalesReport.TabIndex = 7;
            btnFilterSalesReport.Text = "Filter";
            btnFilterSalesReport.UseVisualStyleBackColor = true;
            btnFilterSalesReport.Click += btnFilterSalesReport_Click;
            // 
            // dgvSalesReport
            // 
            dgvSalesReport.BackgroundColor = SystemColors.GradientActiveCaption;
            dgvSalesReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSalesReport.Location = new Point(45, 250);
            dgvSalesReport.Name = "dgvSalesReport";
            dgvSalesReport.Size = new Size(426, 175);
            dgvSalesReport.TabIndex = 8;
            // 
            // btnExportSalesExcel
            // 
            btnExportSalesExcel.Location = new Point(498, 376);
            btnExportSalesExcel.Name = "btnExportSalesExcel";
            btnExportSalesExcel.Size = new Size(75, 49);
            btnExportSalesExcel.TabIndex = 9;
            btnExportSalesExcel.Text = "Export Excel";
            btnExportSalesExcel.UseVisualStyleBackColor = true;
            btnExportSalesExcel.Click += btnExportSalesExcel_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("SF Pro Display", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.DimGray;
            label5.Location = new Point(675, 122);
            label5.Name = "label5";
            label5.Size = new Size(137, 20);
            label5.TabIndex = 11;
            label5.Text = "Inventory Report";
            label5.Click += label5_Click;
            // 
            // dgvInventoryReport
            // 
            dgvInventoryReport.BackgroundColor = SystemColors.GradientActiveCaption;
            dgvInventoryReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInventoryReport.Location = new Point(675, 155);
            dgvInventoryReport.Name = "dgvInventoryReport";
            dgvInventoryReport.Size = new Size(426, 175);
            dgvInventoryReport.TabIndex = 12;
            // 
            // btnExportSalesPDF
            // 
            btnExportSalesPDF.Location = new Point(498, 321);
            btnExportSalesPDF.Name = "btnExportSalesPDF";
            btnExportSalesPDF.Size = new Size(75, 49);
            btnExportSalesPDF.TabIndex = 10;
            btnExportSalesPDF.Text = "Export PDF";
            btnExportSalesPDF.UseVisualStyleBackColor = true;
            btnExportSalesPDF.Click += btnExportSalesPDF_Click;
            // 
            // btnExportInventoryPDF
            // 
            btnExportInventoryPDF.Location = new Point(1026, 336);
            btnExportInventoryPDF.Name = "btnExportInventoryPDF";
            btnExportInventoryPDF.Size = new Size(75, 49);
            btnExportInventoryPDF.TabIndex = 14;
            btnExportInventoryPDF.Text = "Export PDF";
            btnExportInventoryPDF.UseVisualStyleBackColor = true;
            btnExportInventoryPDF.Click += btnExportInventoryPDF_Click;
            // 
            // btnExportInventoryExcel
            // 
            btnExportInventoryExcel.Location = new Point(945, 336);
            btnExportInventoryExcel.Name = "btnExportInventoryExcel";
            btnExportInventoryExcel.Size = new Size(75, 49);
            btnExportInventoryExcel.TabIndex = 13;
            btnExportInventoryExcel.Text = "Export Excel";
            btnExportInventoryExcel.UseVisualStyleBackColor = true;
            btnExportInventoryExcel.Click += btnExportInventoryExcel_Click;
            // 
            // btnExportStaffPDF
            // 
            btnExportStaffPDF.Location = new Point(498, 589);
            btnExportStaffPDF.Name = "btnExportStaffPDF";
            btnExportStaffPDF.Size = new Size(75, 49);
            btnExportStaffPDF.TabIndex = 18;
            btnExportStaffPDF.Text = "Export PDF";
            btnExportStaffPDF.UseVisualStyleBackColor = true;
            btnExportStaffPDF.Click += btnExportStaffPDF_Click;
            // 
            // btnExportStaffExcel
            // 
            btnExportStaffExcel.Location = new Point(498, 644);
            btnExportStaffExcel.Name = "btnExportStaffExcel";
            btnExportStaffExcel.Size = new Size(75, 49);
            btnExportStaffExcel.TabIndex = 17;
            btnExportStaffExcel.Text = "Export Excel";
            btnExportStaffExcel.UseVisualStyleBackColor = true;
            btnExportStaffExcel.Click += btnExportStaffExcel_Click;
            // 
            // dgvStaffPerformanceReport
            // 
            dgvStaffPerformanceReport.BackgroundColor = SystemColors.GradientActiveCaption;
            dgvStaffPerformanceReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStaffPerformanceReport.Location = new Point(45, 518);
            dgvStaffPerformanceReport.Name = "dgvStaffPerformanceReport";
            dgvStaffPerformanceReport.Size = new Size(426, 175);
            dgvStaffPerformanceReport.TabIndex = 16;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("SF Pro Display", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.DimGray;
            label6.Location = new Point(45, 485);
            label6.Name = "label6";
            label6.Size = new Size(150, 20);
            label6.TabIndex = 15;
            label6.Text = "Staff Performance";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("SF Mono", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(675, 449);
            label7.Name = "label7";
            label7.Size = new Size(119, 19);
            label7.TabIndex = 19;
            label7.Text = "Save Report";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("SF Mono", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(675, 489);
            label8.Name = "label8";
            label8.Size = new Size(167, 16);
            label8.TabIndex = 20;
            label8.Text = "Select Report Type :";
            // 
            // cmbReportType
            // 
            cmbReportType.FormattingEnabled = true;
            cmbReportType.Items.AddRange(new object[] { "Sales Report", "Inventory Report", "Staff Performance Report" });
            cmbReportType.Location = new Point(858, 485);
            cmbReportType.Name = "cmbReportType";
            cmbReportType.Size = new Size(162, 24);
            cmbReportType.TabIndex = 21;
            // 
            // btnSaveReport
            // 
            btnSaveReport.Location = new Point(930, 536);
            btnSaveReport.Name = "btnSaveReport";
            btnSaveReport.Size = new Size(90, 45);
            btnSaveReport.TabIndex = 22;
            btnSaveReport.Text = "Save Report";
            btnSaveReport.UseVisualStyleBackColor = true;
            btnSaveReport.Click += btnSaveReport_Click;
            // 
            // ReportsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(1148, 740);
            Controls.Add(btnSaveReport);
            Controls.Add(cmbReportType);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(btnExportStaffPDF);
            Controls.Add(btnExportStaffExcel);
            Controls.Add(dgvStaffPerformanceReport);
            Controls.Add(label6);
            Controls.Add(btnExportInventoryPDF);
            Controls.Add(btnExportInventoryExcel);
            Controls.Add(dgvInventoryReport);
            Controls.Add(label5);
            Controls.Add(btnExportSalesPDF);
            Controls.Add(btnExportSalesExcel);
            Controls.Add(dgvSalesReport);
            Controls.Add(btnFilterSalesReport);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(dtpEndDate);
            Controls.Add(dtpStartDate);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(label1);
            Font = new Font("SF Mono", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ReportsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ReportsForm";
            Load += ReportsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSalesReport).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvInventoryReport).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvStaffPerformanceReport).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Label label2;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private Label label3;
        private Label label4;
        private Button btnFilterSalesReport;
        private DataGridView dgvSalesReport;
        private Button btnExportSalesExcel;
        private Label label5;
        private DataGridView dgvInventoryReport;
        private Button btnExportSalesPDF;
        private Button btnExportInventoryPDF;
        private Button btnExportInventoryExcel;
        private Button btnExportStaffPDF;
        private Button btnExportStaffExcel;
        private DataGridView dgvStaffPerformanceReport;
        private Label label6;
        private Label label7;
        private Label label8;
        private ComboBox cmbReportType;
        private Button btnSaveReport;
    }
}