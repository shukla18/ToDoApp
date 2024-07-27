using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Schema;
using ToDo.Core.Models;

namespace ToDo.Core.DataAccessLayer
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly SqLiteDbContext _dbContext; // Replace with your database context

        public CategoryRepository(SqLiteDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Category> AddAsync(Category entity)
        {
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<int> CountAsync()
        {
            return await _dbContext.Categories.CountAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var record = await _dbContext.Categories.FindAsync(id);
            if (record != null)
            {
                _dbContext.Categories.Remove(record);
                await _dbContext.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Retrieves a list of all categories.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var record = await _dbContext.Categories.FindAsync(id);
            if (record != null)
                return record;
            else
                return new Category();
        }

        public async Task UpdateAsync(Category entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
