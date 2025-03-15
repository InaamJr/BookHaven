using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Data.Models
{
    public class BookModel
    {
        public Guid BookID { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public required string Genre { get; set; }
        public required string ISBN { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public Guid? SupplierID { get; set; }
        public string SupplierName { get; set; }
        public Guid UserID { get; set; }

    }
}
