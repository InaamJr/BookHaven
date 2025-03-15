using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHaven.Business.Interfaces;
using BookHaven.Data.Models;
using BookHaven.Data.Repository;

namespace BookHaven.Business.Services
{
    public class SalesService : ISalesService
    {
        private readonly ISalesTransactionRepository _salesRepository;
        private readonly IBookRepository _bookRepository;

        // Constructor - Inject Dependencies
        public SalesService(ISalesTransactionRepository salesRepository, IBookRepository bookRepository)
        {
            _salesRepository = salesRepository;
            _bookRepository = bookRepository;
        }

        // Process Sales Transaction
        public int ProcessSalesTransaction(SalesTransactionModel transaction, List<SalesDetailsModel> salesDetails)
        {
            // Check Stock Availability before Proceeding
            foreach (var item in salesDetails)
            {
                var book = _bookRepository.GetBookByName(item.BookTitle);  // Fetch book by title
                if (book == null)
                {
                    throw new Exception($"Book '{item.BookTitle}' not found.");
                }
                if (book.StockQuantity < item.Quantity)
                {
                    throw new Exception($"Not enough stock for book: {book.Title}");
                }
            }

            // Proceed with the Sale
            return _salesRepository.CreateSalesTransaction(transaction, salesDetails);
        }

        // Retrieve All Sales Transactions
        public List<SalesTransactionModel> GetAllSalesTransactions()
        {
            return _salesRepository.GetAllSalesTransactions();
        }

        // Retrieve Sales Details for a Specific Transaction
        public List<SalesDetailsModel> GetSalesDetails(int transactionID)
        {
            return _salesRepository.GetSalesDetails(transactionID);
        }
    }
}
