using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookHaven.Forms
{
    public partial class RestockBooksForm : Form
    {
        private string _bookTitle;
        private int _currentStock;
        private string _supplierName;

        public RestockBooksForm(string bookTitle, int currentStock, string supplierName)
        {
            InitializeComponent();
            _bookTitle = bookTitle;
            _currentStock = currentStock;
            _supplierName = supplierName;
            LoadBookDetails();
        }

        // Load selected book details into labels
        private void LoadBookDetails()
        {
            lblBookTitle.Text = _bookTitle;
            lblCurrentStock.Text = _currentStock.ToString();
            lblSupplierName.Text = _supplierName;
        }

        private void RestockBooksForm_Load(object sender, EventArgs e)
        {

        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtRestockQuantity.Text, out int restockQuantity) || restockQuantity <= 0)
            {
                MessageBox.Show("Please enter a valid restock quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Simulate sending an email to the supplier
            MessageBox.Show($"Restock order placed for '{_bookTitle}'.\n\nAn email has been sent to supplier '{_supplierName}'.",
                "Restock Request Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close(); // Close form after placing order
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
