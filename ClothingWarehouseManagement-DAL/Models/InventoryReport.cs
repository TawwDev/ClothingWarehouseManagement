using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingWarehouseManagement_DAL.Models
{
    public class InventoryReport
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public int BeginInventory { get; set; }

        public int In { get; set; }

        public int Out { get; set; }

        public int EndInventory { get; set; }
    }
}
