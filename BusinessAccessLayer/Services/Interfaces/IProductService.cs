using BusinessAccessLayer.DTOs;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Services.Interfaces
{
    public interface IProductService
    {
        Task<ProductDTO> AddProduct(ProductDTO productDTO);
        Task<ProductDTO> GetProductById(int productId);
        Task<ProductDTO> UpdateProduct(ProductDTO productDTO);
        Task DeleteProduct(int productId);
        Task<List<ProductDTO>> GetAllProducts();
        Task<List<ProductDTO>> GetProductsByCategory(int categoryId);
    }
}
