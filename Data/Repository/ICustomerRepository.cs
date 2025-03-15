using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHaven.Data.Models;

namespace BookHaven.Data.Repository
{
    public interface ICustomerRepository
    {
        void AddCustomer(CustomerModel customer);
        void UpdateCustomer(CustomerModel customer);
        void DeleteCustomer(Guid customerID);
        List<CustomerModel> GetAllCustomers();
        CustomerModel GetCustomerById(Guid customerID);
    }
}
