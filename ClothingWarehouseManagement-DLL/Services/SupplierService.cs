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
    public class SupplierService
    {
        private SupplierRepository _repository = new SupplierRepository();
        public List<Supplier> GetListSuppliers()
        {
            return _repository.GetListSuppliers();
        }

        public void AddSupplier(Supplier supplier)
        {
            _repository.AddSupplier(supplier);
        }

        public void UpdateSupplier(Supplier supplier)
        {
            _repository.UpdateSupplier(supplier);
        }

        public void DeleteSupplier(Supplier supplier, List<ImportReceipt> importReceipts)
        {
            _repository.DeleteSupplier(supplier, importReceipts);
        }

    }
}
