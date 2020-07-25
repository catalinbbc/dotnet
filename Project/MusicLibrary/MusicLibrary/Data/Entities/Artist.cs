using System.Collections.Generic;

namespace MusicLibrary.Data.Entities
{
    using MusicLibrary.api.Extensions;
    using System;
    using System.ComponentModel.DataAnnotations;
    public class Artist : IAuditable
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string City { get; set; }

        public int NrAlbums { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<Album> Album { get; set; }
        public Guid ArtistId { get; internal set; }
    }
}
