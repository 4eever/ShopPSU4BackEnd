using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public readonly ApplicationContext _db;

        public ProductRepository(ApplicationContext db)
        {
            _db = db;
        }

        public async Task AddProduct(Product product)
        {
            await _db.Products.AddAsync(product);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _db.Products.ToListAsync();
        }

        public async Task<List<Product>> GetProductsByCategory(int categoryId)
        {
            return await _db.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
        }

        public async Task<Product> GetProductById(int productId)
        {
            return await _db.Products.FindAsync(productId);
        }

        public async Task UpdateProduct(Product product)
        {
            var existingProduct = await _db.Products.FindAsync(product.ProductId);
            if (existingProduct != null)
            {
                existingProduct.ProductName = product.ProductName;
                existingProduct.ProductPrice = product.ProductPrice;
                existingProduct.ProductDescription = product.ProductDescription;
                existingProduct.CategoryId = product.CategoryId;
                existingProduct.Category = product.Category;

                _db.Products.Update(existingProduct);

                await _db.SaveChangesAsync();
            }
        }

        public async Task DeleteProduct(int productId)
        {
            var product = await _db.Products.FindAsync(productId);
            if (product != null)
            {
                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
            }
        }

    }
}
