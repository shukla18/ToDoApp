using Microsoft.EntityFrameworkCore;
using ToDo.Blazor.WebApp.Client.Pages;
using ToDo.Blazor.WebApp.Components;
using ToDo.Core.DataAccessLayer;
using ToDo.Core.Models;
using ToDo.Core.Services;

namespace ToDo.Blazor.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveWebAssemblyComponents();

            builder.Services.AddScoped<IService<Category>, CategoryService>();
            builder.Services.AddScoped<IRepository<Category>, CategoryRepository>();

            builder.Services.AddDbContext<SqLiteDbContext>(options =>
            {
                options.UseSqlite("Data Source=DB/todo.db");
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveWebAssemblyRenderMode()
                .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

            app.Run();
        }
    }
}
