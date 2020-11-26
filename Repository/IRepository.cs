using DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepository<T> where T : class
    {
        Task Insert(T t);
        Task Update(T t);
        Task Delete(String id);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetAllById(String id);
    }
}
