﻿using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace carShop
{
    public class CarContext : DbContext
    {
        public CarContext() : base() { }
        public CarContext(DbContextOptions options) : base(options) { }
        public DbSet<Car> Cars { get; set; }
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
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Car>().HasKey(c => c.Id);
            modelBuilder.Entity<Car>()
                .Property(c => c.Model)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Car>()
                .Property(c => c.Color)
                .IsRequired()
                .HasMaxLength(20); 
            modelBuilder.Entity<Car>()
                .Property(c => c.BodyType)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Car>()
               .Property(c => c.Year)
               .IsRequired();

            modelBuilder.Entity<Car>().HasData(new Car[]
            {
            new Car() {Id=1, Model = "Tesla Model S", Color = "Black", Year = 2022, BodyType = "Sedan" },
            new Car() {Id=2, Model = "Ford Mustang", Color = "Red", Year = 1967, BodyType = "Coupe"},
            });
        }
    }
}