using System;
using System.Collections.Generic;

namespace ClothingWarehouseManagement_DAL.Models;

public partial class Product
{
    public Product()
    {
    }

    public Product(string productName, int category, int quantity, string material, double price, string brand, int status)
    {
        ProductName = productName;
        CategoryId = category;
        Quantity = quantity;
        Material = material;
        Price = price;
        Brand = brand;
        Status = status;
    }

    public Product(int category, int productId, string? productName, int categoryId, int quantity, string? material, double price, string? brand, int? status)
    {
        CategoryId = category;
        ProductId = productId;
        ProductName = productName;
        CategoryId = categoryId;
        Quantity = quantity;
        Material = material;
        Price = price;
        Brand = brand;
        Status = status;
    }

    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public int CategoryId { get; set; }

    public int Quantity { get; set; }

    public double BasePrice { get; set; }

    public double Price { get; set; }

    public string? Material { get; set; }

    public string? Brand { get; set; }

    public int? Status { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<ExportReceiptDetail> ExportReceiptDetails { get; set; } = new List<ExportReceiptDetail>();

    public virtual ICollection<ImportReceiptDetail> ImportReceiptDetails { get; set; } = new List<ImportReceiptDetail>();

}
