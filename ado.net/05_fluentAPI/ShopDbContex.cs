using _05_fluentAPI.classes;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

public class ShopDbContext : DbContext
{
    public DbSet<Position> Positions { get; set; }
    public DbSet<Worker> Workers { get; set; }
    public DbSet<Shop> Shops { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=computer\sqlexpress;
                                      Initial Catalog=MusicAppDb;
                                      Integrated Security=True;
                                      Connect Timeout=2;
                                      Encrypt=False;
                                      Trust Server Certificate=False;
                                      Application Intent=ReadWrite;
                                      Multi Subnet Failover=False");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Position>()
            .HasMany(p => p.Workers)
            .WithOne(w => w.Position)
            .HasForeignKey(w => w.PositionId);

        modelBuilder.Entity<Worker>()
            .HasOne(w => w.Position)
            .WithMany(p => p.Workers)
            .HasForeignKey(w => w.PositionId);

        modelBuilder.Entity<Worker>()
            .HasOne(w => w.Shop)
            .WithMany(s => s.Workers)
            .HasForeignKey(w => w.ShopId);

        modelBuilder.Entity<Shop>()
            .HasOne(s => s.City)
            .WithMany(c => c.Shops)
            .HasForeignKey(s => s.CityId);

        modelBuilder.Entity<City>()
            .HasOne(c => c.Country)
            .WithMany(c => c.Cities)
            .HasForeignKey(c => c.CountryId);

        modelBuilder.Entity<Category>()
            .HasMany(c => c.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId);

        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId);
    }
}