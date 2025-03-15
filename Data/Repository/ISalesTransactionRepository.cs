using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHaven.Data.Models;

namespace BookHaven.Data.Repository
{
    public interface ISalesTransactionRepository
    {
        int CreateSalesTransaction(SalesTransactionModel transaction, List<SalesDetailsModel> salesDetails);
        List<SalesTransactionModel> GetAllSalesTransactions();
        List<SalesDetailsModel> GetSalesDetails(int transactionID);
    }
}
