using MusicLibrary.api.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicLibrary.Data.Entities
{
    public class Album : IAuditable
    {
        public Album()
        {
            Track = new HashSet<Track>();
        }

        public int AlbumId { get; set; }
        public string Title { get; set; }
        public int ArtistId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Artist Artist { get; set; }
        public ICollection<Track> Track { get; set; }
    }
}
