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
        public static async Task<List<ProductDTO>> GetAllProductsAsync()
        {
            var data = await DataAccessFactory.ProductData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Product, ProductDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<ProductDTO>>(data);
            return mapped;
        }

        public static async Task<ProductDTO> GetProductByIdAsync(int id)
        {
            var data = await DataAccessFactory.ProductData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Product, ProductDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<ProductDTO>(data);
            return mapped;
        }
        public static async Task<ProductDTO> CreateProductAsync(ProductDTO product)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<ProductDTO, Product>();
            });
            var mapper = new Mapper(cfg);
            var products = mapper.Map<Product>(product);
            await DataAccessFactory.ProductData().Create(products);
            return product;
            
        }

        public static async Task<ProductDTO> UpdateProductAsync(ProductDTO product)
        {
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<ProductDTO, Product>();
            });
            var mapper = new Mapper(cfg);
            var products = mapper.Map<Product>(product);
            await DataAccessFactory.ProductData().Update(products);
            return product;
        }

        public static async Task<bool> DeleteProductAsync(int id)
        {
            var data = await DataAccessFactory.ProductData().Delete(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Product, ProductDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<bool>(data);
            return mapped;
        }
    }
}
