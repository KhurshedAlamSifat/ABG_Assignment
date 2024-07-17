using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IRepository<Type, ID, RET>
    {
        Task<RET> Create(Type obj);
        Task<List<Type>> Read();
        Task<Type> Read(ID id);
        Task<RET> Update(Type obj);
        Task<bool> Delete(ID id);
    }
}
