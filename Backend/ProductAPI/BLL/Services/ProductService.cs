using AutoMapper;
using BLL.DTOs;
using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProductService
    {
        private readonly IRepository<Product, int, Product> _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IRepository<Product, int, Product> productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductDTO>> GetAllProductsAsync()
        {
            var products = await _productRepository.Read();
            return _mapper.Map<List<ProductDTO>>(products);
        }

        public async Task<ProductDTO> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.Read(id);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> CreateProductAsync(ProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            var createdProduct = await _productRepository.Create(product);
            return _mapper.Map<ProductDTO>(createdProduct);
        }

        public async Task<ProductDTO> UpdateProductAsync(ProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            var updatedProduct = await _productRepository.Update(product);
            return _mapper.Map<ProductDTO>(updatedProduct);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            return await _productRepository.Delete(id);
        }
    }
}
