using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicLibrary.api.Models
{
    public class ArtistModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string City { get; set; }

        public int NrAlbums { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
