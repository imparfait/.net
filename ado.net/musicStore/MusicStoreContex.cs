using Microsoft.EntityFrameworkCore;
using Exam_.classes;

namespace Exam_
{
    public class MusicStoreContex : DbContext
    {
        public DbSet<VinylRecord> VinylRecords { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Promotion> Promotions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=computer\sqlexpress;
                                      Initial Catalog=MusicStoreDb;
                                      Integrated Security=True;
                                      Connect Timeout=2;
                                      Encrypt=False;
                                      Trust Server Certificate=True;
                                      Application Intent=ReadWrite;
                                      Multi Subnet Failover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Sale>()
                .HasOne(s => s.Customer)
                .WithMany()
                .HasForeignKey(s => s.CustomerId);

            modelBuilder.Entity<Sale>()
                .HasOne(s => s.VinylRecord)
                .WithMany()
                .HasForeignKey(s => s.VinylRecordId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Customer)
                .WithMany()
                .HasForeignKey(r => r.CustomerId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.VinylRecord)
                .WithMany()
                .HasForeignKey(r => r.VinylRecordId);
        }
    }
}
