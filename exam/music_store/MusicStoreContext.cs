using Microsoft.EntityFrameworkCore;
using music_store.classes;

namespace music_store
{
    public class MusicStoreContext : DbContext
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
                .WithMany(c => c.Sales)
                .HasForeignKey(s => s.CustomerId);

            modelBuilder.Entity<Sale>()
                .HasOne(s => s.VinylRecord)
                .WithMany(v => v.Sales)
                .HasForeignKey(s => s.VinylRecordId);

            modelBuilder.Entity<Sale>()
                .HasOne(s => s.Promotion)
                .WithOne(p => p.Sale)
                .HasForeignKey<Sale>(s => s.PromotionId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Customer)
                .WithMany(c => c.Reservations)
                .HasForeignKey(r => r.CustomerId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.VinylRecord)
                .WithMany(v => v.Reservations)
                .HasForeignKey(r => r.VinylRecordId);
        }
    }
}
