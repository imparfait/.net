using _03_entityCodeFirst.classes;

namespace _03_entityCodeFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (MusicAppContext context = new MusicAppContext())
            {
                //context.Database.EnsureDeleted(); 
                context.Database.EnsureCreated();

                PlaylistService playlistService = new PlaylistService(context);

                List<int> trackIds = new List<int> { 1, 2 }; 
                playlistService.CreatePlaylist("New Playlist", "Chill", trackIds);

                playlistService.AddTracksToPlaylist(1, new List<int> { 3 }); 

                Console.WriteLine("Playlist created and tracks added.");
            }
        }
        static void SeedDatabase(MusicAppContext context)
        {
            if (!context.Artists.Any())
            {
                Artist artist1 = new Artist { FirstName = "John", LastName = "Doe", Country = "USA" };
                Artist artist2 = new Artist { FirstName = "Jane", LastName = "Smith", Country = "UK" };

                Album album1 = new Album { Name = "First Album", Artist = artist1, Year = 2021, Genre = "Rock" };
                Album album2 = new Album { Name = "Second Album", Artist = artist2, Year = 2022, Genre = "Pop" };

                Track track1 = new Track { Name = "Track One", Album = album1, Duration = new TimeSpan(0, 3, 30) };
                Track track2 = new Track { Name = "Track Two", Album = album1, Duration = new TimeSpan(0, 4, 0) };
                Track track3 = new Track { Name = "Track Three", Album = album2, Duration = new TimeSpan(0, 5, 15) };

                Playlist playlist = new Playlist
                {
                    Name = "My Playlist",
                    Category = "Favorites",
                    Tracks = new List<Track> { track1, track3 }
                };

                context.Artists.AddRange(new List<Artist> { artist1, artist2 });
                context.Albums.AddRange(new List<Album> { album1, album2 });
                context.Tracks.AddRange(new List<Track> { track1, track2, track3 });
                context.Playlists.Add(playlist);

                context.SaveChanges();
            }
        }
    }
}