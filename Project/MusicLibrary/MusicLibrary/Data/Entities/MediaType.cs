using System;
using System.Collections.Generic;

namespace MusicLibrary.Data.Entities
{
    public class MediaType
    {
        public MediaType()
        {
            Track = new HashSet<Track>();
        }

        public int MediaTypeId { get; set; }
        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public ICollection<Track> Track { get; set; }
    }
}