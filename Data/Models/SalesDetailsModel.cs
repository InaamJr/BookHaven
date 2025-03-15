using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Data.Models
{
    public class SalesDetailsModel
    {
        public int SalesDetailsID { get; set; }  // Primary Key
        public int TransactionID { get; set; }  // Foreign Key - Sales Transaction
        public Guid BookID { get; set; }  // Foreign Key - Book being purchased
        public string BookTitle { get; set; }
        public int Quantity { get; set; }  // Quantity of books bought
        public decimal PricePerUnit { get; set; }  // Book price per unit
        public decimal SubTotal { get; set; }  // Total for this book (PricePerUnit * Quantity)
    }
}
