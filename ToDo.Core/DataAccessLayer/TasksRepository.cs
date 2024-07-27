using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.Models;

namespace ToDo.Core.DataAccessLayer
{
    internal class TasksRepository : IRepository<MyTask>
    {
        private readonly ToDo.Core.DataAccessLayer.SqLiteDbContext _dbContext;
        public TasksRepository(SqLiteDbContext sqLiteDbContext) {
        
            _dbContext = sqLiteDbContext;
        }
        public async Task<MyTask> AddAsync(MyTask entity)
        {
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<int> CountAsync()
        {
            return await _dbContext.Tasks.CountAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<MyTask>> GetAllAsync()
        {
            return await _dbContext.Tasks.ToListAsync();
        }

        public async Task<MyTask> GetByIdAsync(int id)
        {
            return await _dbContext.Tasks.FindAsync(id);
        }

        public async Task<MyTask> GetByCategoryIdAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(MyTask entity)
        {
            throw new NotImplementedException();
        }
    }
}
