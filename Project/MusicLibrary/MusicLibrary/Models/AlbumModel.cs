using MusicLibrary.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicLibrary.api.Models
{
    public class AlbumModel
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public int ArtistId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Artist Artist { get; set; }
    }
}
