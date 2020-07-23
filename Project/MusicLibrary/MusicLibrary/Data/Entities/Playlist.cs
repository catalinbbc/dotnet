﻿using System.Collections.Generic;

namespace MusicLibrary.Data.Entities
{
    public class Playlist
    {
        public Playlist()
        {
            PlaylistTrack = new HashSet<PlaylistTrack>();
        }

        public int PlaylistId { get; set; }
        public string Name { get; set; }

        public ICollection<PlaylistTrack> PlaylistTrack { get; set; }
    }
}