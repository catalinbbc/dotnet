using MusicLibrary.api.Models;
using MusicLibrary.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicLibrary.api.Extensions
{
    public static class AlbumExtensions
    {
        public static Album MapAsNewEntity(this CreateAlbumRequestModel model, Artist artist)
        {
            return new Album
            {
                Title = model.Title,
                Artist = artist
            };
        }

        public static Album MapAsNewEntity(this CreateAlbumRequestModel2 model, Artist artist)
        {
            return new Album
            {
                Title = model.Title,
                Artist = artist
            };
        }

        public static AlbumModel MapAsModel(this Album model)
        {
            return new AlbumModel
            {
                Title = model.Title,
                AlbumId = model.AlbumId
            };
        }

        public static void UpdateWith(this Album album, UpdateAlbumRequestModel model)
        {
            album.Title = model.Title;
        }

    }
}
