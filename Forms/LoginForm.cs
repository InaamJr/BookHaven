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
using BookHaven.Business.Services;
using BookHaven.Data.Models;
using BookHaven.Data.Repository;

namespace BookHaven.Forms
{
    public partial class LoginForm : Form
    {
        private UserService _userService;   

        public LoginForm()
        {
            InitializeComponent();
            _userService = new UserService(new UserRepository());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_userService.AuthenticateUser(username, password))
            {
                UserModel user = _userService.GetUserByUsername(username);

                // Debug: Print role to console
                System.Diagnostics.Debug.WriteLine($"DEBUG: Retrieved Role = {user.Role}");

                // Store user info in session
                Session.LoggedInUserID = user.UserID;
                Session.LoggedInUserRole = user.Role;

                // Debug: Print stored session value
                System.Diagnostics.Debug.WriteLine($"DEBUG: Session.LoggedInUserRole = {Session.LoggedInUserRole}");

                MessageBox.Show($"Login Successful! Welcome, {user.Role}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                new MainForm(user.Role).Show();  // Pass user role to MainForm
            }
            else
            {
                MessageBox.Show("Invalid login credentials.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
