namespace BookHaven.Forms
{
    partial class BusinessSettingsForm
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtBusinessName = new TextBox();
            txtEmail = new TextBox();
            txtPhone = new TextBox();
            txtAddress = new TextBox();
            btnSaveBusinessDetails = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("SF Pro Display", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(26, 28);
            label1.Name = "label1";
            label1.Size = new Size(105, 29);
            label1.TabIndex = 0;
            label1.Text = "Settings";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("SF Pro Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(76, 105);
            label2.Name = "label2";
            label2.Size = new Size(120, 19);
            label2.TabIndex = 1;
            label2.Text = "Business Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("SF Pro Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(76, 152);
            label3.Name = "label3";
            label3.Size = new Size(49, 19);
            label3.TabIndex = 2;
            label3.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("SF Pro Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(76, 200);
            label4.Name = "label4";
            label4.Size = new Size(55, 19);
            label4.TabIndex = 3;
            label4.Text = "Phone";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("SF Pro Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(76, 251);
            label5.Name = "label5";
            label5.Size = new Size(71, 19);
            label5.TabIndex = 4;
            label5.Text = "Address";
            // 
            // txtBusinessName
            // 
            txtBusinessName.Location = new Point(244, 105);
            txtBusinessName.Name = "txtBusinessName";
            txtBusinessName.Size = new Size(127, 23);
            txtBusinessName.TabIndex = 5;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(244, 152);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(127, 23);
            txtEmail.TabIndex = 6;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(244, 200);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(127, 23);
            txtPhone.TabIndex = 7;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(244, 251);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(127, 23);
            txtAddress.TabIndex = 8;
            // 
            // btnSaveBusinessDetails
            // 
            btnSaveBusinessDetails.Font = new Font("SF Mono", 9.75F, FontStyle.Bold);
            btnSaveBusinessDetails.Location = new Point(76, 328);
            btnSaveBusinessDetails.Name = "btnSaveBusinessDetails";
            btnSaveBusinessDetails.Size = new Size(87, 57);
            btnSaveBusinessDetails.TabIndex = 9;
            btnSaveBusinessDetails.Text = "Save Details";
            btnSaveBusinessDetails.UseVisualStyleBackColor = true;
            btnSaveBusinessDetails.Click += btnSaveBusinessDetails_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.DarkRed;
            btnCancel.Font = new Font("SF Mono", 9.75F, FontStyle.Bold);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(445, 398);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(71, 43);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "CANCEL";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // BusinessSettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            ClientSize = new Size(528, 453);
            Controls.Add(btnCancel);
            Controls.Add(btnSaveBusinessDetails);
            Controls.Add(txtAddress);
            Controls.Add(txtPhone);
            Controls.Add(txtEmail);
            Controls.Add(txtBusinessName);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "BusinessSettingsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Business Settings";
            Load += BusinessSettingsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtBusinessName;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private TextBox txtAddress;
        private Button btnSaveBusinessDetails;
        private Button btnCancel;
    }
}