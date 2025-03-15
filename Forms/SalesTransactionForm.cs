using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookHaven.Business;
using BookHaven.Business.Interfaces;
using BookHaven.Business.Services;
using BookHaven.Data.Models;
using BookHaven.Data.Repository;

namespace BookHaven.Forms
{
    public partial class SalesTransactionForm : Form
    {
        private readonly ISalesService _salesService;
        private readonly ICustomerService _customerService;
        private readonly IBookService _bookService;
        private List<SalesDetailsModel> _cart;
        private decimal totalAmount = 0;

        public SalesTransactionForm()
        {
            InitializeComponent();

            _salesService = new SalesService(new SalesTransactionRepository(), new BookRepository());
            _customerService = new CustomerService(new CustomerRepository());
            _bookService = new BookService(new BookRepository());

            _cart = new List<SalesDetailsModel>();

            LoadCustomers();
            LoadBooks();
            InitializeCartGrid();
            LoadTransactions();

            txtDiscount.Leave += txtDiscount_Leave;
            txtDiscount.KeyPress += txtDiscount_KeyPress;
        }

        private void SalesTransactionForm_Load(object sender, EventArgs e)
        {

        }

        // Load customers into dropdown
        private void LoadCustomers()
        {
            var customers = _customerService.GetAllCustomers();
            cmbCustomers.DataSource = customers;
            cmbCustomers.DisplayMember = "Name";
            cmbCustomers.ValueMember = "CustomerID";
        }

        // Load books into dropdown
        private void LoadBooks()
        {
            var books = _bookService.GetAllBooks();
            cmbBooks.DataSource = books;
            cmbBooks.DisplayMember = "Title";
            cmbBooks.ValueMember = "BookID";
        }

        // Initialize Cart Grid
        private void InitializeCartGrid()
        {
            dgvCart.Columns.Clear();
            dgvCart.Columns.Add("BookTitle", "Book Title");
            dgvCart.Columns.Add("Quantity", "Quantity");
            dgvCart.Columns.Add("PricePerUnit", "Price Per Unit");
            dgvCart.Columns.Add("SubTotal", "Subtotal");

            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (cmbBooks.SelectedItem == null)
            {
                MessageBox.Show("Please select a book.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Please enter a valid quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedBook = (BookModel)cmbBooks.SelectedItem;

            // Check stock availability
            if (selectedBook.StockQuantity < quantity)
            {
                MessageBox.Show($"Insufficient stock for {selectedBook.Title}. Available: {selectedBook.StockQuantity}", "Stock Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal subTotal = selectedBook.Price * quantity;

            SalesDetailsModel newItem = new SalesDetailsModel
            {
                BookID = selectedBook.BookID,
                BookTitle = selectedBook.Title,
                Quantity = quantity,
                PricePerUnit = selectedBook.Price,
                SubTotal = subTotal
            };

            _cart.Add(newItem);
            dgvCart.Rows.Add(selectedBook.Title, quantity, selectedBook.Price, subTotal);

            totalAmount += subTotal;
            lblTotalAmount.Text = totalAmount.ToString("C");
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (dgvCart.SelectedRows.Count > 0)
            {
                int rowIndex = dgvCart.SelectedRows[0].Index;
                decimal subTotal = Convert.ToDecimal(dgvCart.Rows[rowIndex].Cells["SubTotal"].Value);

                _cart.RemoveAt(rowIndex);
                dgvCart.Rows.RemoveAt(rowIndex);

                totalAmount -= subTotal;
                lblTotalAmount.Text = totalAmount.ToString("C");
            }
        }

        private void btnProcessPayment_Click(object sender, EventArgs e)
        {
            if (cmbCustomers.SelectedItem == null)
            {
                MessageBox.Show("Please select a customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cmbPaymentMethod.SelectedItem == null)
            {
                MessageBox.Show("Please select a payment method.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_cart.Count == 0)
            {
                MessageBox.Show("Cart is empty. Please add items before proceeding with payment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CustomerModel selectedCustomer = (CustomerModel)cmbCustomers.SelectedItem;

            // Retrieve necessary values
            decimal totalAmount = _cart.Sum(item => item.SubTotal);
            decimal discountPercentage = decimal.TryParse(txtDiscount.Text, out decimal discount) ? discount : 0;
            decimal discountAmount = (totalAmount * discountPercentage) / 100;
            decimal finalAmount = totalAmount - discountAmount;

            // Create Sales Transaction Model
            SalesTransactionModel transaction = new SalesTransactionModel
            {
                CustomerID = (Guid)cmbCustomers.SelectedValue,
                TransactionDate = DateTime.Now,
                TotalAmount = totalAmount,
                Discount = discountPercentage,
                FinalAmount = finalAmount,
                PaymentMethod = cmbPaymentMethod.SelectedItem.ToString(),
                UserID = Session.LoggedInUserID
            };

            // Process the transaction
            int transactionID = _salesService.ProcessSalesTransaction(transaction, _cart);

            if (transactionID > 0)
            {
                MessageBox.Show("Payment processed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTransactions(); // Refresh the recent transactions table
                ClearForm();
            }
            else
            {
                MessageBox.Show("Transaction failed. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Load Transactions into Recent Transactions Grid
        private void LoadTransactions()
        {
            dgvSalesHistory.DataSource = null;
            var transactions = _salesService.GetAllSalesTransactions();

            var formattedTransactions = transactions.Select(t => new
            {
                t.TransactionID,
                t.CustomerID,
                t.TransactionDate,
                t.TotalAmount,
                t.Discount,
                t.FinalAmount,
                t.PaymentMethod,
                t.UserID
            }).ToList();

            dgvSalesHistory.DataSource = formattedTransactions;
        }

        private void btnClearForm_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            cmbCustomers.SelectedIndex = -1;
            cmbBooks.SelectedIndex = -1;
            txtQuantity.Clear();
            txtDiscount.Clear();
            lblTotalAmount.Text = "$0.00";
            _cart.Clear();
            dgvCart.Rows.Clear();
            lblFinalAmount.Text = "$0.00";
            totalAmount = 0;
        }

        private void btnGenerateInvoice_Click(object sender, EventArgs e)
        {
            if (dgvSalesHistory.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a transaction to generate an invoice.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Fetch selected transaction
            int transactionID = Convert.ToInt32(dgvSalesHistory.SelectedRows[0].Cells["TransactionID"].Value);
            var transaction = _salesService.GetAllSalesTransactions().FirstOrDefault(t => t.TransactionID == transactionID);

            if (transaction == null)
            {
                MessageBox.Show("Transaction not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Fetch Sales Details for this transaction
            List<SalesDetailsModel> salesDetails = _salesService.GetSalesDetails(transactionID);
            if (salesDetails.Count == 0)
            {
                MessageBox.Show("No items found for this transaction.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Generate Invoice
            GenerateInvoice(transaction, salesDetails);
        }

        private void GenerateInvoice(SalesTransactionModel transaction, List<SalesDetailsModel> salesDetails)
        {
            StringBuilder invoice = new StringBuilder();
            invoice.AppendLine("===== BOOK HAVEN INVOICE =====");
            invoice.AppendLine($"Transaction ID: {transaction.TransactionID}");
            invoice.AppendLine($"Customer ID: {transaction.CustomerID}");
            invoice.AppendLine($"Date: {transaction.TransactionDate}");
            invoice.AppendLine($"Payment Method: {transaction.PaymentMethod}");
            invoice.AppendLine("----------------------------------------");

            invoice.AppendLine("Book Title:        Quantity:    Unit Price:   Subtotal:");
            invoice.AppendLine("----------------------------------------");

            foreach (var item in salesDetails)
            {
                invoice.AppendLine($"{item.BookTitle.PadRight(15)} {item.Quantity.ToString().PadRight(10)} {item.PricePerUnit.ToString("C").PadRight(10)} {item.SubTotal.ToString("C")}");
            }

            invoice.AppendLine("----------------------------------------");
            invoice.AppendLine($"Total Amount: {transaction.TotalAmount:C}");
            invoice.AppendLine($"Discount: {transaction.Discount:C}");
            invoice.AppendLine($"Final Amount: {transaction.FinalAmount:C}");
            invoice.AppendLine("========================================");

            // Save invoice to file (optional)
            string invoicePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"Invoice_{transaction.TransactionID}.txt");
            File.WriteAllText(invoicePath, invoice.ToString());

            // Show confirmation
            MessageBox.Show($"Invoice generated successfully!\nSaved at: {invoicePath}", "Invoice Generated", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Optionally, open the invoice file
            Process.Start("notepad.exe", invoicePath);
        }


        // Function to calculate final amount with discount
        private void ApplyDiscount()
        {
            if (decimal.TryParse(txtDiscount.Text, out decimal discountPercentage))
            {
                if (discountPercentage < 0 || discountPercentage > 100)
                {
                    MessageBox.Show("Discount must be between 0% and 100%", "Invalid Discount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal totalAmount = _cart.Sum(item => item.SubTotal);
                decimal discountAmount = (totalAmount * discountPercentage) / 100;
                decimal finalAmount = totalAmount - discountAmount;

                lblFinalAmount.Text = finalAmount.ToString("C");
            }
            else
            {
                MessageBox.Show("Please enter a valid discount percentage.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtDiscount_Leave(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtDiscount.Text, out decimal discountPercentage))
            {
                if (discountPercentage >= 0 && discountPercentage <= 100)
                {
                    decimal totalAmount = Convert.ToDecimal(lblTotalAmount.Text.Replace("$", "").Trim());
                    decimal discountAmount = (totalAmount * discountPercentage) / 100;
                    decimal finalAmount = totalAmount - discountAmount;

                    lblFinalAmount.Text = finalAmount.ToString("C");
                    txtDiscount.Text = discountPercentage.ToString("0.##");
                }
                else
                {
                    MessageBox.Show("Please enter a discount between 0 and 100.", "Invalid Discount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiscount.Text = "0";
                }
            }
            else
            {
                MessageBox.Show("Invalid discount value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiscount.Text = "0";
            }
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ApplyDiscount();
                e.Handled = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm(Session.LoggedInUserRole);
            mainForm.Show();
        }

        private void btnCancelTransaction_Click(object sender, EventArgs e)
        {
            // Confirm cancellation
            var confirmResult = MessageBox.Show("Are you sure you want to cancel this transaction?",
                                                "Cancel Transaction",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                // Clear Cart
                _cart.Clear();
                dgvCart.DataSource = null;
                dgvCart.Rows.Clear();

                // Reset Input Fields
                cmbCustomers.SelectedIndex = -1;
                cmbBooks.SelectedIndex = -1;
                txtQuantity.Clear();
                txtDiscount.Clear();
                lblTotalAmount.Text = "$0.00";
                lblFinalAmount.Text = "$0.00";

                //// Enable input fields again (if they were disabled)
                //cmbCustomers.Enabled = true;
                //cmbBooks.Enabled = true;
                //txtQuantity.Enabled = true;
                //txtDiscount.Enabled = true;
                //btnAddToCart.Enabled = true;
                //btnProcessPayment.Enabled = true;

                // Show confirmation
                MessageBox.Show("Transaction has been successfully canceled.", "Transaction Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
