using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Core.Services
{
    public interface IService<T> where T : class
    {
        Task<T> AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(int id);

        Task<T> GetAsync(int id);

        Task<IList<T>> GetAllAsync();

        Task<int> GetCountAsync();
    }
}
