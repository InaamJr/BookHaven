using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Data.Models
{
    public class OrderDetailsModel
    {
        public int OrderDetailsID { get; set; }
        public int OrderID { get; set; }  // Foreign Key to Order
        public Guid BookID { get; set; }  // Book being ordered
        public string BookTitle { get; set; }  // Displayed in UI
        public int Quantity { get; set; }
        public decimal PricePerUnit { get; set; }
        public decimal SubTotal { get; set; }
    }
}
