using Microsoft.EntityFrameworkCore;
using ToDo.Core.Models;

namespace ToDo.Core.DataAccessLayer
{
    public class SqLiteDbContext : DbContext
    {
        public SqLiteDbContext(DbContextOptions<SqLiteDbContext> options): base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<MyTask> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=your_database.db");
            }
        }
    }
}
