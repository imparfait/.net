using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using carList.Services;
using carShop;
using carShop.Entities;
using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using carShop.Interfaces;
using Microsoft.AspNetCore.Identity.UI.Services;
using carList.Areas.Identity.Pages.Account;

namespace carList
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();

            string connString = builder.Configuration.GetConnectionString("RemoteDb")!;
            builder.Services.AddDbContext<CarContext>(opt => opt.UseSqlServer(connString));

            builder.Services.AddIdentity<User, IdentityRole>()
                .AddDefaultTokenProviders()
                .AddDefaultUI()
                .AddEntityFrameworkStores<CarContext>();

            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddScoped<ICarService, CarService>();
            builder.Services.AddScoped<ICartService, CartService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddSingleton<IEmailSender>(new EmailSender(
                smtpServer: "smtp.gmail.com",
                port: 587,
                fromEmail: "supersasha.st@gmail.com",
                password: "uwsq kcqq kltr xzar"
            ));
            builder.Services.AddSession(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            builder.Services.AddHttpContextAccessor();

            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                Seeder.SeedRoles(scope.ServiceProvider).Wait();
                Seeder.SeedAdmin(scope.ServiceProvider).Wait();
            }
            
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

//            app.UseAuthentication();
            app.UseAuthorization();
            app.MapRazorPages();
            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
