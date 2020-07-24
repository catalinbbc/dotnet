using System;
using System.Collections.Generic;
using System.Text;

namespace MusicLibrary.Domain
{
    class AlbumCreateDto
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public int ArtistId { get; set; }
    }
}
    