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
    public class ImportReceiptService
    {
        private ImportReceiptRopository _repository = new();
        public List<ImportReceipt> GetListImportRecept()
        {
            return _repository.GetListImportRecept();
        }
        public void AddImportRecept(ImportReceipt ir)
        {
            _repository.AddImportRecept(ir);
        }

        public List<ImportReceipt> GetListSearchImportReceipts(string keyWord, Supplier supplier)
        {
            if (supplier != null && supplier.SupplierId != 0)
            {
                return _repository.GetListImportRecept().Where(x => x.CreatedByNavigation.FullName.Trim().ToLower().Contains(keyWord.Trim().ToLower()) && supplier.SupplierId == x.SupplierId).ToList();
            }
            else
            {
                return _repository.GetListImportRecept().Where(x => x.CreatedByNavigation.FullName.Trim().ToLower().Contains(keyWord.Trim().ToLower())).ToList();
            }
                
        }
    }
}
