using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleMiddleware.Services
{
    public interface ICrud<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(string id);
        Task Insert(T obj);
        Task Update(T obj);
        Task Delete(T obj);
    }
}
