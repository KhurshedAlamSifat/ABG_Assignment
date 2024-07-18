using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ProductRepository : IRepository<Product, int, Product>
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> Create(Product obj)
        {
            await _dbContext.Products.AddAsync(obj);
            await _dbContext.SaveChangesAsync();
            return obj;
        }

        public async Task<bool> Delete(int id)
        {
            var product = await Read(id);
            if (product == null)
                return false;

            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Product>> Read()
        {
            return await _dbContext.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product> Read(int id)
        {
            return await _dbContext.Products.FindAsync(id);
        }

        public async Task<Product> Update(Product obj)
        {
            _dbContext.Products.Update(obj);
            await _dbContext.SaveChangesAsync();
            return obj;
        }
    }
}
