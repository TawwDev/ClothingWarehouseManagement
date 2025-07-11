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
    public class ExportReceiptService
    {
        private ExportReceiptRepository _repository = new();
        public List<ExportReceipt> GetListExportReceipt()
        {
            return _repository.GetListExportReceipt();
        }
        public void AddExportRecept(ExportReceipt er)
        {
            _repository.AddExportRecept(er);
        }

        public int GetLastExportId()
        {
            return _repository.GetLastExportId();
        }

        public List<ExportReceiptDetail> GetExportReceiptDetails(int receptId)
        {
            return _repository.GetExportReceiptDetails(receptId);
        }


        public List<SalesReport> GetSalesReport()
        {
            return _repository.GetSalesReport();
        }
    }
}
