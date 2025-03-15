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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void AddCustomer(CustomerModel customer)
        {
            _customerRepository.AddCustomer(customer);
        }

        public List<CustomerModel> GetAllCustomers()
        {
            return _customerRepository.GetAllCustomers();
        }

        public void UpdateCustomer(CustomerModel customer)
        {
            _customerRepository.UpdateCustomer(customer);
        }

        public void DeleteCustomer(Guid customerID)
        {
            _customerRepository.DeleteCustomer(customerID);
        }
    }
}
