using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHaven.Data.Models;

namespace BookHaven.Data.Repository
{
    public interface IBookRepository
    {
        void AddBook(BookModel book);
        List<BookModel> GetAllBooks();
        BookModel GetBookById(Guid bookId);
        BookModel GetBookByISBN(string isbn);
        BookModel GetBookByName(string title);
        void UpdateBook(BookModel book);
        void DeleteBook(Guid bookID);
        List<BookModel> GetLowStockBooks();
    }
}
