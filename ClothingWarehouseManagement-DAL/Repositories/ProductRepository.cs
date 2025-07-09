using System;
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
        private ClothingWarehouseManagementContext _context = new ClothingWarehouseManagementContext();
        
        public Product? GetProductById(int productId)
        {
            //List: dung Find(productId)
            return _context.Products.FirstOrDefault(p => p.ProductId == productId);
        }
        public List<Product> GetListProduct()
        {
            return _context.Products.Include(x => x.Category).ToList();
        }
        public List<Category> GetListCategory()
        {
            return _context.Categories.ToList();
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

        public void UpdateQuantityProduct(int productId, int quantity)
        {
            var p = _context.Products.Where(x => x.ProductId == productId).FirstOrDefault();
            p.Quantity += quantity;
            _context.Products.Update(p);
            _context.SaveChanges();
        }
    }
}
