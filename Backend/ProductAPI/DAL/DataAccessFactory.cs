using DAL.Interfaces;
using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepository<Product, int, Product> ProductData(ApplicationDbContext dbContext)
        {
            return new ProductRepository(dbContext);
        }
    }
}
