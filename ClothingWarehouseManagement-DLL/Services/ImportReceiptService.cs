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

        public int GetLastImportId()
        {
            return _repository.GetLastImportId();
        }

        public List<ImportReceiptDetail> GetImportReceiptDetails(int receptId)
        {
            return _repository.GetImportReceiptDetails(receptId);
        }
    }
}
