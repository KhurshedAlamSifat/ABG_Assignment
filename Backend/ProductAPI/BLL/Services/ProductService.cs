using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Interfaces;
using DAL.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProductService
    {
        private readonly IRepository<Product, int, Product> _repository;
        private readonly IMapper _mapper;

        public ProductService(IRepository<Product, int, Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ProductDTO>> GetAllProductsAsync()
        {
            var data = await _repository.Read();
            var mapped = _mapper.Map<List<ProductDTO>>(data);
            return mapped;
        }

        public async Task<ProductDTO> GetProductByIdAsync(int id)
        {
            var data = await _repository.Read(id);
            var mapped = _mapper.Map<ProductDTO>(data);
            return mapped;
        }

        public async Task<ProductDTO> CreateProductAsync(ProductDTO product)
        {
            var entity = _mapper.Map<Product>(product);
            await _repository.Create(entity);
            return product;
        }

        public async Task<ProductDTO> UpdateProductAsync(ProductDTO product)
        {
            var entity = _mapper.Map<Product>(product);
            await _repository.Update(entity);
            return product;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            return await _repository.Delete(id);
        }
    }
}
