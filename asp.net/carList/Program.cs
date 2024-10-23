using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using carShop;
using Microsoft.EntityFrameworkCore;

namespace carList
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();

            string connString = builder.Configuration.GetConnectionString("LocalDb")!;
            builder.Services.AddDbContext<CarContext>(opt => 
            opt.UseSqlServer(connString, sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, 
                    maxRetryDelay: TimeSpan.FromSeconds(10),
                    errorNumbersToAdd: null); 

            }));

			builder.Services.AddScoped<ICarService, CarService>();
			var app = builder.Build();

           
          // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
