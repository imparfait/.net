using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_entityCodeFirst.classes
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string Name { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public ICollection<Track> Tracks { get; set; }
    }
}
