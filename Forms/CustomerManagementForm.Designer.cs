namespace BookHaven.Forms
{
    partial class CustomerManagementForm
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
            lblTitle = new Label();
            btnExit = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtAddress = new TextBox();
            txtPhone = new TextBox();
            txtEmail = new TextBox();
            txtName = new TextBox();
            btnDeleteCustomer = new Button();
            btnUpdateCustomer = new Button();
            btnAddCustomer = new Button();
            dgvCustomers = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("SF Pro Display", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = SystemColors.ControlText;
            lblTitle.Location = new Point(387, 40);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(305, 32);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Customer Management";
            lblTitle.Click += lblTitle_Click;
            // 
            // btnExit
            // 
            btnExit.Font = new Font("SF Mono", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExit.ForeColor = Color.DarkRed;
            btnExit.Location = new Point(27, 27);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 37);
            btnExit.TabIndex = 18;
            btnExit.Text = "EXIT";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("SF Pro Display", 12F, FontStyle.Bold);
            label4.Location = new Point(59, 306);
            label4.Name = "label4";
            label4.Size = new Size(71, 19);
            label4.TabIndex = 28;
            label4.Text = "Address";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("SF Pro Display", 12F, FontStyle.Bold);
            label3.Location = new Point(59, 255);
            label3.Name = "label3";
            label3.Size = new Size(55, 19);
            label3.TabIndex = 27;
            label3.Text = "Phone";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("SF Pro Display", 12F, FontStyle.Bold);
            label2.Location = new Point(59, 206);
            label2.Name = "label2";
            label2.Size = new Size(49, 19);
            label2.TabIndex = 26;
            label2.Text = "Email";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("SF Pro Display", 12F, FontStyle.Bold);
            label1.Location = new Point(59, 157);
            label1.Name = "label1";
            label1.Size = new Size(52, 19);
            label1.TabIndex = 25;
            label1.Text = "Name";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(207, 306);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(169, 23);
            txtAddress.TabIndex = 22;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(207, 255);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(169, 23);
            txtPhone.TabIndex = 21;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(207, 206);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(169, 23);
            txtEmail.TabIndex = 20;
            // 
            // txtName
            // 
            txtName.Location = new Point(207, 157);
            txtName.Name = "txtName";
            txtName.Size = new Size(169, 23);
            txtName.TabIndex = 19;
            // 
            // btnDeleteCustomer
            // 
            btnDeleteCustomer.BackColor = Color.Firebrick;
            btnDeleteCustomer.Font = new Font("SF Mono", 9.75F, FontStyle.Bold);
            btnDeleteCustomer.ForeColor = Color.White;
            btnDeleteCustomer.Location = new Point(59, 522);
            btnDeleteCustomer.Name = "btnDeleteCustomer";
            btnDeleteCustomer.Size = new Size(96, 35);
            btnDeleteCustomer.TabIndex = 31;
            btnDeleteCustomer.Text = "DELETE";
            btnDeleteCustomer.UseVisualStyleBackColor = false;
            btnDeleteCustomer.Click += btnDeleteCustomer_Click;
            // 
            // btnUpdateCustomer
            // 
            btnUpdateCustomer.Font = new Font("SF Mono", 9.75F, FontStyle.Bold);
            btnUpdateCustomer.Location = new Point(59, 470);
            btnUpdateCustomer.Name = "btnUpdateCustomer";
            btnUpdateCustomer.Size = new Size(96, 35);
            btnUpdateCustomer.TabIndex = 30;
            btnUpdateCustomer.Text = "UPDATE";
            btnUpdateCustomer.UseVisualStyleBackColor = true;
            btnUpdateCustomer.Click += btnUpdateCustomer_Click;
            // 
            // btnAddCustomer
            // 
            btnAddCustomer.BackColor = Color.White;
            btnAddCustomer.Font = new Font("SF Mono", 9.75F, FontStyle.Bold);
            btnAddCustomer.ForeColor = Color.Black;
            btnAddCustomer.Location = new Point(59, 419);
            btnAddCustomer.Name = "btnAddCustomer";
            btnAddCustomer.Size = new Size(137, 35);
            btnAddCustomer.TabIndex = 29;
            btnAddCustomer.Text = "ADD CUSTOMER";
            btnAddCustomer.UseVisualStyleBackColor = false;
            btnAddCustomer.Click += btnAddCustomer_Click;
            // 
            // dgvCustomers
            // 
            dgvCustomers.BackgroundColor = SystemColors.ActiveCaption;
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomers.Location = new Point(446, 120);
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.Size = new Size(595, 455);
            dgvCustomers.TabIndex = 32;
            dgvCustomers.CellContentClick += dgvCustomers_CellContentClick;
            // 
            // CustomerManagementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(1094, 626);
            Controls.Add(dgvCustomers);
            Controls.Add(btnDeleteCustomer);
            Controls.Add(btnUpdateCustomer);
            Controls.Add(btnAddCustomer);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtAddress);
            Controls.Add(txtPhone);
            Controls.Add(txtEmail);
            Controls.Add(txtName);
            Controls.Add(btnExit);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CustomerManagementForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CustomerManagementForm";
            Load += CustomerManagementForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Button btnExit;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtAddress;
        private TextBox txtPhone;
        private TextBox txtEmail;
        private TextBox txtName;
        private Button btnDeleteCustomer;
        private Button btnUpdateCustomer;
        private Button btnAddCustomer;
        private DataGridView dgvCustomers;
    }
}