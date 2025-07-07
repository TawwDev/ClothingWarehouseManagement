using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothingWarehouseManagement_DAL.Models;
using ClothingWarehouseManagement_DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ClothingWarehouseManagement_DLL.Services
{
    public class CustomerService
    {
        private CustomerRepository _repository = new CustomerRepository();

        public List<Customer> GetListCustomers()
        {
            return _repository.GetListCustomers();
        }

        public void AddCustomer(Customer customer)
        {
            _repository.AddCustomer(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            _repository.UpdateCustomer(customer);
        }

        public void DeleteCustomer(Customer customer)
        {
            _repository.DeleteCustomer(customer);
        }
        public List<Customer> SearchCustomer(string keyWord)
        {
            return _repository.GetListCustomers().Where(c => c.CustomerName.ToLower().Contains(keyWord.ToLower())).ToList();
        }
    }
}
