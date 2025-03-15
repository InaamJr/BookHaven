using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHaven.Data.Models;

namespace BookHaven.Business.Interfaces
{
    public interface ISalesService
    {
        int ProcessSalesTransaction(SalesTransactionModel transaction, List<SalesDetailsModel> salesDetails);
        List<SalesTransactionModel> GetAllSalesTransactions();
        List<SalesDetailsModel> GetSalesDetails(int transactionID);
    }
}
