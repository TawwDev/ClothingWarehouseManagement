using System;
using System.Collections.Generic;

namespace ClothingWarehouseManagement_DAL.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public double ProfitMargin { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
