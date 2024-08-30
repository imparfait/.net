using System;
using _03_entityCodeFirst.classes;
using Microsoft.EntityFrameworkCore;
namespace _03_entityCodeFirst
{
    public class MusicAppContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Playlist> Playlists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

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
            modelBuilder.Entity<Album>()
                .HasOne(a => a.Artist)
                .WithMany(a => a.Albums)
                .HasForeignKey(a => a.ArtistId);

            modelBuilder.Entity<Track>()
                .HasOne(t => t.Album)
                .WithMany(a => a.Tracks)
                .HasForeignKey(t => t.AlbumId);
        }
    }
}