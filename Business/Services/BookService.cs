using BookHaven.Business.Interfaces;
using BookHaven.Data.Models;
using BookHaven.Data.Repository;
using System;
using System.Collections.Generic;

namespace BookHaven.Business.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public void AddBook(BookModel book) 
        {
            if (Session.LoggedInUserRole != "Admin")
                throw new UnauthorizedAccessException("Only Admins can add books.");

            _bookRepository.AddBook(book);
        } 

        public List<BookModel> GetAllBooks() => _bookRepository.GetAllBooks();
        public void UpdateBook(BookModel book) => _bookRepository.UpdateBook(book);
        public void DeleteBook(Guid bookID) => _bookRepository.DeleteBook(bookID);

        public List<BookModel> GetLowStockBooks()
        {
            return _bookRepository.GetLowStockBooks();
        }

        public BookModel GetBookById(Guid bookId)
        {
            return _bookRepository.GetBookById(bookId);
        }

        public BookModel GetBookByName(string title)
        {
            return _bookRepository.GetBookByName(title);
        }
    }
}
