using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Data.Models
{
    public class SalesTransactionReportModel
    {
        public int TransactionID { get; set; }  // Sales Transaction ID
        public DateTime TransactionDate { get; set; }  // Date of Sale
        public decimal TotalAmount { get; set; }  // Total Sales Amount
        public string PaymentMethod { get; set; }  // Payment Type (Cash, Card, Online)
        public Guid UserID { get; set; }  // Staff ID who processed the sale
    }
}
