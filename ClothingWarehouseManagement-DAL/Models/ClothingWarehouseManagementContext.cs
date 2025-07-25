﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ClothingWarehouseManagement_DAL.Models;

public partial class ClothingWarehouseManagementContext : DbContext
{
    public ClothingWarehouseManagementContext()
    {
    }

    public ClothingWarehouseManagementContext(DbContextOptions<ClothingWarehouseManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<ExportReceipt> ExportReceipts { get; set; }

    public virtual DbSet<ExportReceiptDetail> ExportReceiptDetails { get; set; }

    public virtual DbSet<ImportReceipt> ImportReceipts { get; set; }

    public virtual DbSet<ImportReceiptDetail> ImportReceiptDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(config.GetConnectionString("DB"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.UserName).HasName("PK__Account__66DCF95DD5609BCE");

            entity.ToTable("Account");

            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("userName");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .HasColumnName("fullName");
            entity.Property(e => e.Password)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Role).HasColumnName("role");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__23CAF1F8639D1EBA");

            entity.ToTable("Category");

            entity.HasIndex(e => e.CategoryName, "UQ__Category__37077ABDF6BDD6E2").IsUnique();

            entity.Property(e => e.CategoryId).HasColumnName("categoryID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .HasColumnName("categoryName");
            entity.Property(e => e.ProfitMargin)
                .HasDefaultValue(0.5)
                .HasColumnName("profitMargin");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__B611CB9D3A0D3B0E");

            entity.ToTable("Customer");

            entity.HasIndex(e => e.Email, "UQ__Customer__AB6E6164231D0282").IsUnique();

            entity.HasIndex(e => e.Phone, "UQ__Customer__B43B145F587EC495").IsUnique();

            entity.Property(e => e.CustomerId).HasColumnName("customerID");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(100)
                .HasColumnName("customerName");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Status)
                .HasDefaultValue(1)
                .HasColumnName("status");
        });

        modelBuilder.Entity<ExportReceipt>(entity =>
        {
            entity.HasKey(e => e.ReceiptId).HasName("PK__ExportRe__CAA7E898855C48B5");

            entity.ToTable("ExportReceipt");

            entity.Property(e => e.ReceiptId).HasColumnName("receiptID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("createdBy");
            entity.Property(e => e.CustomerId).HasColumnName("customerID");
            entity.Property(e => e.TotalAmount).HasColumnName("totalAmount");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ExportReceipts)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ExportRec__creat__5165187F");

            entity.HasOne(d => d.Customer).WithMany(p => p.ExportReceipts)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__ExportRec__custo__52593CB8");
        });

        modelBuilder.Entity<ExportReceiptDetail>(entity =>
        {
            entity.HasKey(e => new { e.ReceiptId, e.ProductId }).HasName("PK__ExportRe__7876E58C64437E97");

            entity.ToTable("ExportReceiptDetail");

            entity.Property(e => e.ReceiptId).HasColumnName("receiptID");
            entity.Property(e => e.ProductId).HasColumnName("productID");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.UnitPrice).HasColumnName("unitPrice");

            entity.HasOne(d => d.Product).WithMany(p => p.ExportReceiptDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ExportRec__produ__59FA5E80");

            entity.HasOne(d => d.Receipt).WithMany(p => p.ExportReceiptDetails)
                .HasForeignKey(d => d.ReceiptId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ExportRec__recei__59063A47");
        });

        modelBuilder.Entity<ImportReceipt>(entity =>
        {
            entity.HasKey(e => e.ReceiptId).HasName("PK__ImportRe__CAA7E8986422F9A9");

            entity.ToTable("ImportReceipt");

            entity.Property(e => e.ReceiptId).HasColumnName("receiptID");
            entity.Property(e => e.CreatedAt).HasColumnName("createdAt");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("createdBy");
            entity.Property(e => e.SupplierId).HasColumnName("supplierID");
            entity.Property(e => e.TotalAmount).HasColumnName("totalAmount");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ImportReceipts)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__ImportRec__creat__4BAC3F29");

            entity.HasOne(d => d.Supplier).WithMany(p => p.ImportReceipts)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK__ImportRec__suppl__4CA06362");
        });

        modelBuilder.Entity<ImportReceiptDetail>(entity =>
        {
            entity.HasKey(e => new { e.ReceiptId, e.ProductId }).HasName("PK__ImportRe__7876E58CEF9ADFDD");

            entity.ToTable("ImportReceiptDetail");

            entity.Property(e => e.ReceiptId).HasColumnName("receiptID");
            entity.Property(e => e.ProductId).HasColumnName("productID");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.UnitPrice).HasColumnName("unitPrice");

            entity.HasOne(d => d.Product).WithMany(p => p.ImportReceiptDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ImportRec__produ__5629CD9C");

            entity.HasOne(d => d.Receipt).WithMany(p => p.ImportReceiptDetails)
                .HasForeignKey(d => d.ReceiptId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ImportRec__recei__5535A963");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__2D10D14A542CDE33");

            entity.ToTable("Product");

            entity.Property(e => e.ProductId).HasColumnName("productID");
            entity.Property(e => e.BasePrice).HasColumnName("basePrice");
            entity.Property(e => e.Brand)
                .HasMaxLength(50)
                .HasColumnName("brand");
            entity.Property(e => e.CategoryId).HasColumnName("categoryID");
            entity.Property(e => e.Material)
                .HasMaxLength(50)
                .HasColumnName("material");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.ProductName)
                .HasMaxLength(100)
                .HasColumnName("productName");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Status).HasColumnName("status");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Product_Category");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("PK__Supplier__DB8E62CDEA596184");

            entity.ToTable("Supplier");

            entity.HasIndex(e => e.Email, "UQ__Supplier__AB6E6164F6B690E2").IsUnique();

            entity.Property(e => e.SupplierId).HasColumnName("supplierID");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.SupplierName)
                .HasMaxLength(100)
                .HasColumnName("supplierName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
