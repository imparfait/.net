using carShop.Configuration;
using carShop.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace carShop
{
    public class CarContext : IdentityDbContext<User>
	{
        public CarContext() : base() { }
        public CarContext(DbContextOptions<CarContext> options) : base(options) { }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfiguration(new CarConfiguration());
			modelBuilder.Entity<Order>()
	            .Property(o => o.Total)
	            .HasPrecision(18, 2);
			//modelBuilder.Entity<Car>().HasData(new Car[]
			//         {
			//         new Car() {Id=1, Model = "Tesla Model S", Color = "Black", Year = 2022, BodyType = "Sedan" },
			//         new Car() {Id=2, Model = "Ford Mustang", Color = "Red", Year = 1967, BodyType = "Coupe"},
			//         });
			//modelBuilder.Entity<Cart>().HasData(new Cart() { Id = 1, Cars = null });
		}
    }
}

//
//Toyota Camry
//Blue
//2021
//Sedan
//https://dealer-content.s3.amazonaws.com/images/models/toyota/2021/camry/colors/blueprint.png