using _03_entityCodeFirst.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_entityCodeFirst
{
    public class PlaylistService
    {
        private readonly MusicAppContext context;
        public PlaylistService(MusicAppContext context)
        {
            this.context = context;
        }
        public void CreatePlaylist(string name, string category, List<int> trackIds)
        {
            List<Track> tracks = context.Tracks.Where(t => trackIds.Contains(t.TrackId)).ToList();

            Playlist playlist = new Playlist
            {
                Name = name,
                Category = category,
                Tracks = tracks
            };

            context.Playlists.Add(playlist);
            context.SaveChanges();
        }
        public void AddTracksToPlaylist(int playlistId, List<int> trackIds)
        {
            Playlist playlist = context.Playlists.Include(p => p.Tracks).FirstOrDefault(p => p.PlaylistId == playlistId);
            if (playlist != null)
            {
                List<Track> tracks = context.Tracks.Where(t => trackIds.Contains(t.TrackId)).ToList();
                playlist.Tracks.AddRange(tracks);
                context.SaveChanges();
            }
        }
    }
}
