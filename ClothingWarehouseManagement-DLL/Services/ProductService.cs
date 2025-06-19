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
    public class ProductService
    {
        private ProductRepository _repositories = new ProductRepository();
       
        public Product? GetProductById(int productId)
        {
            return _repositories.GetProductById(productId);
        }
        public List<Product> GetListProduct()
        {
            return _repositories.GetListProduct();
        }
        public List<Category> GetListCategory()
        {
            return _repositories.GetListCategory();
        }
        public List<Product> GetListProductByCategoryId(int categoryId)
        {
            return _repositories.GetListProductByCategoryId(categoryId);
        }

        public void CreateProduct(Product product)
        {
            _repositories.CreateProduct(product);
        }
        public void UpdateProduct(Product product)
        {
            _repositories.UpdateProduct(product);
        }
        public void DeleteProduct(int productId)
        {
            _repositories.DeleteProduct(productId);
        }

        public List<Product> SearchProducts(string keyWord)
        {
            return _repositories.GetListProduct().Where(p => p.ProductName.ToLower().Contains(keyWord.ToLower())).ToList();
        }
    }
}
