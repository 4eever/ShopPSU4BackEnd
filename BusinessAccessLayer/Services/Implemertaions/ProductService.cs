using AutoMapper;
using BusinessAccessLayer.DTOs;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessAccessLayer.Services.Interfaces;
using DataAccessLayer.Repositories.Interfaces;

namespace BusinessAccessLayer.Services.Implemertaions
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDTO> AddProduct(ProductDTO productDTO)
        {
            var productEntity = _mapper.Map<ProductDTO, Product>(productDTO);
            await _productRepository.AddProduct(productEntity);

            var product = await _productRepository.GetProductByName(productEntity.ProductName);
            var productDTOResult = _mapper.Map<Product, ProductDTO>(product);

            return productDTOResult;
        }

        public async Task<List<ProductDTO>> GetAllProducts()
        {
            var products = await _productRepository.GetAllProducts();

            var productsDTO = (from p in products
                               select _mapper.Map<Product, ProductDTO>(p)
                               ).ToList();

            return productsDTO;
        }

        public async Task<ProductDTO> GetProductById(int productId)
        {
            var product = await _productRepository.GetProductById(productId);

            if (product == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            var productDTO = _mapper.Map<Product, ProductDTO>(product);

            return productDTO;
        }

        public async Task DeleteProduct(int productId)
        {
            var product = await _productRepository.GetProductById(productId);

            if (product == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            await _productRepository.DeleteProduct(productId);
        }

        public async Task<ProductDTO> UpdateProduct(ProductDTO productDTO)
        {
            var productEntity = _mapper.Map<ProductDTO, Product>(productDTO);

            var productCheck = await _productRepository.GetProductById(productEntity.ProductId);

            if (productCheck == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            await _productRepository.UpdateProduct(productEntity);

            var product = await _productRepository.GetProductByName(productEntity.ProductName);
            var productDTOResult = _mapper.Map<Product, ProductDTO>(product);

            return productDTOResult;
        }

        public async Task<List<ProductDTO>> GetProductsByCategory(int categoryId)
        {
            var products = await _productRepository.GetProductsByCategory(categoryId);

            var productsDTO = (from p in products
                               select _mapper.Map<Product, ProductDTO>(p)
                               ).ToList();

            return productsDTO;
        }
    }
}
