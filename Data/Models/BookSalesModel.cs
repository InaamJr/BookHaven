using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHaven.Data.Models
{
    public class BookSalesModel
    {
        public Guid BookID { get; set; }
        public string BookTitle { get; set; }
        public int SalesCount { get; set; }
    }
}
