using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingWarehouseManagement_DAL.Models
{
    public class SalesReport
    {
        public DateOnly Date { get; set; }
        public double Capital { get; set; }
        public double Revenue { get; set; }
        public double Profit { get; set; }
    }
}
