using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothingWarehouseManagement_DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ClothingWarehouseManagement_DAL.Repositories
{
    public class ExportReceiptRepository
    {
        private ClothingWarehouseManagementContext _context = new();

        public List<ExportReceipt> GetListExportReceipt()
        {
            return _context.ExportReceipts.Include(x => x.CreatedByNavigation).Include(x => x.Customer).Include(x => x.ExportReceiptDetails).ToList();
        }
        public void AddExportRecept(ExportReceipt er)
        {
            foreach (var detail in er.ExportReceiptDetails)
            {
                if (detail.Product != null)
                {
                    detail.Product = null;
                }
            }
            _context.ExportReceipts.Add(er);
            _context.SaveChanges();
        }

        public int GetLastExportId()
        {
            return _context.ExportReceipts.OrderByDescending(x => x.ReceiptId).Select(x => x.ReceiptId).FirstOrDefault();
        }

        public List<ExportReceiptDetail> GetExportReceiptDetails(int receptId)
        {
            return _context.ExportReceiptDetails.Include(x => x.Product).Where(x => x.ReceiptId == receptId).ToList();
        }
    }
}
