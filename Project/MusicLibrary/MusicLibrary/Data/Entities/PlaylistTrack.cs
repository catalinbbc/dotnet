﻿namespace MusicLibrary.Data.Entities
{
    public class PlaylistTrack
    {
        public int Id { get; set; }
        public int TrackId { get; set; }

        public Playlist Playlist { get; set; }
        public Track Track { get; set; }
    }
}