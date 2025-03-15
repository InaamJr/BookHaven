using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Data.Models
{
    public class SalesTransactionModel
    {
        public int TransactionID { get; set; }  // Primary Key
        public Guid CustomerID { get; set; }  // Foreign Key - Customer making the purchase
        public DateTime TransactionDate { get; set; } = DateTime.Now;  // Default to current date/time
        public decimal TotalAmount { get; set; }  // Total transaction cost
        public decimal Discount { get; set; } = 0;  // Any applied discount
        public decimal FinalAmount { get; set; }
        public string PaymentMethod { get; set; }  // Cash, Card, Online Payment
        public Guid UserID { get; set; }  // Foreign Key - Staff member who processed the sale
    }
}
