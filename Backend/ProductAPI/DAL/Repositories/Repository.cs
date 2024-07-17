using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Repositories
{
    internal class Repository
    {
        internal ApplicationDbContext db;
        internal Repository()
        {
            db = new ApplicationDbContext();
        }
    }
}
