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
    internal class ProductRepository : Repository, IRepository<Product, int, Product>
    {
        public async Task<Product> Create(Product obj)
        {
            await db.Products.AddAsync(obj);
            if(await db.SaveChangesAsync()>0) return obj;
            return null;
        }


        public async Task<bool> Delete(int id)
        {
            var product = await Read(id);
            if (product == null)
            {
                return false;
            }
            db.Products.Remove(product);
            await db.SaveChangesAsync();
            return true;
        }

        public async Task<List<Product>> Read()
        {
            return await db.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product> Read(int id)
        {
            return await db.Products.FindAsync(id);
        }

        public async Task<Product> Update(Product obj)
        {
            db.Products.Update(obj);
            await db.SaveChangesAsync();
            return obj;
        }
    }
}
