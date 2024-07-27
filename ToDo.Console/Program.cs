using System;
using System.Diagnostics;
using ToDo.Core.DataAccessLayer;
using ToDo.Core.Models;
namespace ToDo.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("hello World!!!");
            System.Console.ReadLine();
            IRepository<Category> repository = new CategoryRepository(new SqLiteDbContext());
            ToDo.Core.Services.CategoryService categoryService = new Core.Services.CategoryService(repository);

        }
    }
}
