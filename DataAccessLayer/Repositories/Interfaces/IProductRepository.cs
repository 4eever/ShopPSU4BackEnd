using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task AddProduct(Product product);
        Task<Product> GetProductById(int productId);
        Task UpdateProduct(Product product);
        Task DeleteProduct(int productId);
        Task<List<Product>> GetAllProducts();
        Task<List<Product>> GetProductsByCategory(int categoryId);
        Task<Product> GetProductByName(string productName);
    }
}
