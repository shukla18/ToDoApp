using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.DataAccessLayer;
using ToDo.Core.Models;

namespace ToDo.Core.Services
{
    public class CategoryService : IService<Category>
    {
        private readonly IRepository<Category> _repository;

        public CategoryService(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<Category> AddAsync(Category entity)
        {
            return await _repository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IList<Category>> GetAllAsync()
        {
            var records = await _repository.GetAllAsync();

            return records.ToList();
        }

        public async Task<Category> GetAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<int> GetCountAsync()
        {
            return await _repository.CountAsync();
        }

        public async Task UpdateAsync(Category entity)
        {
            await _repository.UpdateAsync(entity);
        }
    }
}
