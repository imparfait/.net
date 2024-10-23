using carShop.Configuration;
using carShop.Entities;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace carShop
{
    public class CarContext : DbContext
    {
        public CarContext() : base() { }
        public CarContext(DbContextOptions options) : base(options) { }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Cart> Carts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer(@"Data Source=computer\sqlexpress;
            //                          Initial Catalog=MusicStoreDb;
            //                          Integrated Security=True;
            //                          Connect Timeout=2;
            //                          Encrypt=False;
            //                          Trust Server Certificate=True;
            //                          Application Intent=ReadWrite;
            //                          Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.ApplyConfiguration(new CarConfiguration());
            //modelBuilder.Entity<Car>().HasData(new Car[]
            //         {
            //         new Car() {Id=1, Model = "Tesla Model S", Color = "Black", Year = 2022, BodyType = "Sedan" },
            //         new Car() {Id=2, Model = "Ford Mustang", Color = "Red", Year = 1967, BodyType = "Coupe"},
            //         });
            //modelBuilder.Entity<Cart>().HasData(new Cart() { Id = 1, Cars = null });
        }
    }
}