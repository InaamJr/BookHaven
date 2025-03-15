namespace BookHaven.Forms
{
    partial class ManageUsersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageUsersForm));
            label1 = new Label();
            dgvUsers = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtUsername = new TextBox();
            txtEmail = new TextBox();
            cmbRole = new ComboBox();
            txtPassword = new TextBox();
            btnAddUser = new Button();
            btnUpdateUser = new Button();
            btnDeleteUser = new Button();
            btnResetPassword = new Button();
            btnExit = new Button();
            cmbStatus = new ComboBox();
            label7 = new Label();
            btnUnlockUser = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("SF Pro Display", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(425, 45);
            label1.Name = "label1";
            label1.Size = new Size(169, 29);
            label1.TabIndex = 0;
            label1.Text = "Manage Users";
            // 
            // dgvUsers
            // 
            dgvUsers.BackgroundColor = SystemColors.InactiveCaption;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Location = new Point(411, 113);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.Size = new Size(519, 249);
            dgvUsers.TabIndex = 1;
            dgvUsers.SelectionChanged += dgvUsers_SelectionChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("SF Pro Display", 12F, FontStyle.Bold);
            label2.Location = new Point(37, 113);
            label2.Name = "label2";
            label2.Size = new Size(84, 19);
            label2.TabIndex = 2;
            label2.Text = "Username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("SF Pro Display", 12F, FontStyle.Bold);
            label3.Location = new Point(37, 197);
            label3.Name = "label3";
            label3.Size = new Size(49, 19);
            label3.TabIndex = 3;
            label3.Text = "Email";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("SF Pro Display", 12F, FontStyle.Bold);
            label5.Location = new Point(37, 239);
            label5.Name = "label5";
            label5.Size = new Size(41, 19);
            label5.TabIndex = 5;
            label5.Text = "Role";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("SF Pro Display", 12F, FontStyle.Bold);
            label6.Location = new Point(37, 154);
            label6.Name = "label6";
            label6.Size = new Size(81, 19);
            label6.TabIndex = 6;
            label6.Text = "Password";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(179, 113);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(115, 23);
            txtUsername.TabIndex = 7;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(179, 197);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(115, 23);
            txtEmail.TabIndex = 8;
            // 
            // cmbRole
            // 
            cmbRole.FormattingEnabled = true;
            cmbRole.Items.AddRange(new object[] { "Admin", "SalesClerk" });
            cmbRole.Location = new Point(179, 239);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(115, 23);
            cmbRole.TabIndex = 10;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(179, 154);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(115, 23);
            txtPassword.TabIndex = 11;
            // 
            // btnAddUser
            // 
            btnAddUser.Font = new Font("SF Mono", 9.75F, FontStyle.Bold);
            btnAddUser.Location = new Point(37, 377);
            btnAddUser.Name = "btnAddUser";
            btnAddUser.Size = new Size(75, 45);
            btnAddUser.TabIndex = 12;
            btnAddUser.Text = "Add User";
            btnAddUser.UseVisualStyleBackColor = true;
            btnAddUser.Click += btnAddUser_Click;
            // 
            // btnUpdateUser
            // 
            btnUpdateUser.Font = new Font("SF Mono", 9.75F, FontStyle.Bold);
            btnUpdateUser.Location = new Point(126, 377);
            btnUpdateUser.Name = "btnUpdateUser";
            btnUpdateUser.Size = new Size(75, 45);
            btnUpdateUser.TabIndex = 13;
            btnUpdateUser.Text = "Update User";
            btnUpdateUser.UseVisualStyleBackColor = true;
            btnUpdateUser.Click += btnUpdateUser_Click;
            // 
            // btnDeleteUser
            // 
            btnDeleteUser.Font = new Font("SF Mono", 9.75F, FontStyle.Bold);
            btnDeleteUser.Location = new Point(213, 377);
            btnDeleteUser.Name = "btnDeleteUser";
            btnDeleteUser.Size = new Size(75, 45);
            btnDeleteUser.TabIndex = 14;
            btnDeleteUser.Text = "Delete User";
            btnDeleteUser.UseVisualStyleBackColor = true;
            btnDeleteUser.Click += btnDeleteUser_Click;
            // 
            // btnResetPassword
            // 
            btnResetPassword.Font = new Font("SF Mono", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnResetPassword.Location = new Point(411, 377);
            btnResetPassword.Name = "btnResetPassword";
            btnResetPassword.Size = new Size(85, 45);
            btnResetPassword.TabIndex = 15;
            btnResetPassword.Text = "Reset Password";
            btnResetPassword.UseVisualStyleBackColor = true;
            btnResetPassword.Click += btnResetPassword_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.DarkRed;
            btnExit.Font = new Font("SF Mono", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(906, 451);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 41);
            btnExit.TabIndex = 16;
            btnExit.Text = "EXIT";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "Active", "Inactive" });
            cmbStatus.Location = new Point(179, 281);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(115, 23);
            cmbStatus.TabIndex = 18;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("SF Pro Display", 12F, FontStyle.Bold);
            label7.Location = new Point(37, 281);
            label7.Name = "label7";
            label7.Size = new Size(57, 19);
            label7.TabIndex = 17;
            label7.Text = "Status";
            // 
            // btnUnlockUser
            // 
            btnUnlockUser.Font = new Font("SF Mono", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUnlockUser.Location = new Point(502, 377);
            btnUnlockUser.Name = "btnUnlockUser";
            btnUnlockUser.Size = new Size(85, 45);
            btnUnlockUser.TabIndex = 19;
            btnUnlockUser.Text = "Unlock\r\nUser";
            btnUnlockUser.UseVisualStyleBackColor = true;
            btnUnlockUser.Click += btnUnlockUser_Click;
            // 
            // ManageUsersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(993, 504);
            Controls.Add(btnUnlockUser);
            Controls.Add(cmbStatus);
            Controls.Add(label7);
            Controls.Add(btnExit);
            Controls.Add(btnResetPassword);
            Controls.Add(btnDeleteUser);
            Controls.Add(btnUpdateUser);
            Controls.Add(btnAddUser);
            Controls.Add(txtPassword);
            Controls.Add(cmbRole);
            Controls.Add(txtEmail);
            Controls.Add(txtUsername);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dgvUsers);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ManageUsersForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Manage Users";
            Load += ManageUsersForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dgvUsers;
        private Label label2;
        private Label label3;
        private Label label5;
        private Label label6;
        private TextBox txtUsername;
        private TextBox txtEmail;
        private ComboBox cmbRole;
        private TextBox txtPassword;
        private Button btnAddUser;
        private Button btnUpdateUser;
        private Button btnDeleteUser;
        private Button btnResetPassword;
        private Button btnExit;
        private ComboBox cmbStatus;
        private Label label7;
        private Button btnUnlockUser;
    }
}