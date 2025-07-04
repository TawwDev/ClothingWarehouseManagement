﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClothingWarehouseManagement_DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ClothingWarehouseManagement_DAL.Repositories
{
    public class ProductRepository
    {
        private CWMContext _context = new CWMContext();
        
        public Product? GetProductById(int productId)
        {
            //List: dung Find(productId)
            return _context.Products.FirstOrDefault(p => p.ProductId == productId);
        }
        public List<Product> GetListProduct()
        {
            var qr = from p in _context.Products
                      .Include(p => p.Category)
                      select p;
            return qr.ToList();
        }
        public List<Category> GetListCategory()
        {
            var qr = from c in _context.Categories
                     select c;
            return qr.ToList();
        }
        public List<Product> GetListProductByCategoryId(int categoryId)
        {
            var qr = from p in _context.Products
                     where p.CategoryId == categoryId
                     select p;
            return qr.ToList();
        }

        public void CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }
        public void DeleteProduct(int productId)
        {
            var p = _context.Products.FirstOrDefault(p => p.ProductId == productId);
            if(p != null)
            {
                _context.Remove(p);
                _context.SaveChanges();
            }
        }
    }
}
