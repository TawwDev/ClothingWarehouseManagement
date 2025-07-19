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
    public class InventoryReportService
    {
        private InventoryReportRepository _repository = new();
        public List<InventoryReport> InventoryReports(DateOnly fromDate, DateOnly toDate, string productName)
        {
            if (productName != null)
            {
                return _repository.InventoryReports(fromDate, toDate).Where( x => x.ProductName.Contains(productName)).ToList();
            }
            else
            {
                return _repository.InventoryReports(fromDate, toDate);
            }
        }
    }
}
