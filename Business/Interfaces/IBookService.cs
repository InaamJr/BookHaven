using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHaven.Data.Models;

namespace BookHaven.Business.Interfaces
{
    public interface IBookService
    {
        List<BookModel> GetAllBooks();
        BookModel GetBookById(Guid bookId);
        BookModel GetBookByName(string title);
        List<BookModel> GetLowStockBooks(); 
    }
}
