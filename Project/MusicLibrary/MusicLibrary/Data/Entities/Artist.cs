using System.Collections.Generic;

namespace MusicLibrary.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    public class Artist
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string City { get; set; }

        public int NrAlbums { get; set; }

        public ICollection<Album> Album { get; set; }

    }
}
