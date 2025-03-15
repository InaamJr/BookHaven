using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookHaven.Business;
using BookHaven.Business.Interfaces;
using BookHaven.Business.Services;
using BookHaven.Data.Models;

namespace BookHaven.Forms
{
    public partial class ManageUsersForm : Form
    {
        private readonly IUserService _userService;

        public ManageUsersForm(IUserService userService)
        {
            InitializeComponent();
            _userService = userService;
            LoadUsers();
        }

        // Load Users into DataGridView
        private void LoadUsers()
        {
            dgvUsers.DataSource = _userService.GetAllUsers();
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.Refresh();
        }

        private void ManageUsersForm_Load(object sender, EventArgs e)
        {
            if (Session.LoggedInUserRole != "Admin") // Ensure only Admins can access
            {
                MessageBox.Show("Access Denied: Only Admins can manage users!", "Security Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close(); // Close the form immediately
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||  // Password Required!
                cmbRole.SelectedItem == null ||
                cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all fields, including password!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newUser = new UserModel
            {
                UserID = Guid.NewGuid(),
                Username = txtUsername.Text.Trim(),
                PasswordHash = _userService.HashPassword(txtPassword.Text),  // Store hashed password!
                Email = txtEmail.Text.Trim(),
                Role = cmbRole.SelectedItem.ToString(),
                CreatedDate = DateTime.Now,
                IsActive = cmbStatus.SelectedItem.ToString()
            };

            _userService.AddUser(newUser);
            MessageBox.Show("User added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadUsers();  // Refresh DataGridView
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to update!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedUser = (UserModel)dgvUsers.SelectedRows[0].DataBoundItem;
            selectedUser.Username = txtUsername.Text.Trim();
            selectedUser.Email = txtEmail.Text.Trim();
            selectedUser.Role = cmbRole.SelectedItem.ToString();
            selectedUser.IsActive = cmbStatus.SelectedItem.ToString();

            _userService.UpdateUser(selectedUser);
            MessageBox.Show("User updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadUsers();  // Refresh DataGridView
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to delete!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedUser = (UserModel)dgvUsers.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show($"Are you sure you want to delete {selectedUser.Username}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _userService.DeleteUser(selectedUser.UserID);
                MessageBox.Show("User deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUsers();  // Refresh DataGridView
            }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to reset password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedUser = (UserModel)dgvUsers.SelectedRows[0].DataBoundItem;

            // Ask user to enter a new password
            string newPassword = Microsoft.VisualBasic.Interaction.InputBox("Enter new password:", "Reset Password", "");
            if (string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show("Password reset cancelled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _userService.ResetPassword(selectedUser.UserID, newPassword);
            MessageBox.Show($"Password reset successfully for {selectedUser.Username}!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                var selectedUser = (UserModel)dgvUsers.SelectedRows[0].DataBoundItem;
                txtUsername.Text = selectedUser.Username;
                txtEmail.Text = selectedUser.Email;
                cmbRole.SelectedItem = selectedUser.Role;
                cmbStatus.SelectedItem = selectedUser.IsActive;
                txtPassword.Text = "";  // Keep password blank for security reasons
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUnlockUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a user to unlock!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedUser = (UserModel)dgvUsers.SelectedRows[0].DataBoundItem;

            if (!selectedUser.IsLocked)
            {
                MessageBox.Show("User is not locked!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _userService.UnlockUser(selectedUser.UserID);
            MessageBox.Show($"User {selectedUser.Username} has been unlocked!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadUsers();
        }
    }
}
