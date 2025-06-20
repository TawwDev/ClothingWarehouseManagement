﻿using System;
using System.Collections.Generic;

namespace ClothingWarehouseManagement_DAL.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public int CategoryId { get; set; }

    public int Quantity { get; set; }

    public string Size { get; set; } = null!;

    public string? Color { get; set; }

    public string? Material { get; set; }

    public double Price { get; set; }

    public string? Brand { get; set; }

    public int? Status { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<ExportReceiptDetail> ExportReceiptDetails { get; set; } = new List<ExportReceiptDetail>();

    public virtual ICollection<ImportReceiptDetail> ImportReceiptDetails { get; set; } = new List<ImportReceiptDetail>();

    public Product(int productId, string? productName, int categoryId, int quantity, string size, string? color, string? material, double price, string? brand, int? status)
    {
        ProductId = productId;
        ProductName = productName;
        CategoryId = categoryId;
        Quantity = quantity;
        Size = size;
        Color = color;
        Material = material;
        Price = price;
        Brand = brand;
        Status = status;
    }

    public Product(string? productName, int categoryId, int quantity, string size, string? color, string? material, double price, string? brand, int? status)
    {
        ProductName = productName;
        CategoryId = categoryId;
        Quantity = quantity;
        Size = size;
        Color = color;
        Material = material;
        Price = price;
        Brand = brand;
        Status = status;
    }
}
