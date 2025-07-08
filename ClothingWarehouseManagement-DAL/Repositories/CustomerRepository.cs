using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothingWarehouseManagement_DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ClothingWarehouseManagement_DAL.Repositories
{
    public class CustomerRepository
    {
        private ClothingWarehouseManagementContext _context = new ClothingWarehouseManagementContext();

        public List<Customer> GetListCustomers()
        {
            return _context.Customers.ToList();
        }

        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }

        public void DeleteCustomer(Customer customer)
        {
            var exportReceipts = _context.ExportReceipts.Include(x => x.ExportReceiptDetails).Where(x => x.CustomerId == customer.CustomerId).ToList();
            Customer c = _context.Customers.FirstOrDefault(c => c.CustomerId == customer.CustomerId);
            if(exportReceipts != null)
            {
                foreach (var item in exportReceipts)
                {
                    item.ExportReceiptDetails.Clear();
                }
                _context.ExportReceipts.RemoveRange(exportReceipts);
            }
            _context.Remove(customer);
            _context.SaveChanges();
        }
    }
}
