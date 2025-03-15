using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookHaven.Business.Interfaces;
using BookHaven.Business.Services;
using BookHaven.Data.Models;
using BookHaven.Data.Repository;

namespace BookHaven.Forms
{
    public partial class BusinessSettingsForm : Form
    {
        private readonly IBusinessSettingsService _settingsService;
        private BusinessSettingsModel _currentSettings;

        public BusinessSettingsForm()
        {
            InitializeComponent();
            _settingsService = new BusinessSettingsService(new BusinessSettingsRepository());
            LoadBusinessSettings();
        }

        private void LoadBusinessSettings()
        {
            _currentSettings = _settingsService.GetBusinessSettings();

            if (_currentSettings != null)
            {
                txtBusinessName.Text = _currentSettings.BusinessName;
                txtEmail.Text = _currentSettings.Email;
                txtPhone.Text = _currentSettings.Phone;
                txtAddress.Text = _currentSettings.Address;
            }
        }

        private void BusinessSettingsForm_Load(object sender, EventArgs e)
        {


        }

        private void btnSaveBusinessDetails_Click(object sender, EventArgs e)
        {
            if (_currentSettings == null)
            {
                MessageBox.Show("Error: No business settings found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _currentSettings.BusinessName = txtBusinessName.Text.Trim();
            _currentSettings.Email = txtEmail.Text.Trim();
            _currentSettings.Phone = txtPhone.Text.Trim();
            _currentSettings.Address = txtAddress.Text.Trim();

            _settingsService.UpdateBusinessSettings(_currentSettings);
            MessageBox.Show("Business settings updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
