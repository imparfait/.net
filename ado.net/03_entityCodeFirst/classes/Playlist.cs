using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_entityCodeFirst.classes
{
    public class Playlist
    {
        public int PlaylistId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public ICollection<Track> Tracks { get; set; }
    }
}
