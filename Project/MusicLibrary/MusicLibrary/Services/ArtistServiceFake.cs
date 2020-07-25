using MusicLibrary.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicLibrary.api.Services
{
    public class ArtistServiceFake : IArtistService
    {
        private readonly List<Artist> _artists;

        public ArtistServiceFake()
        {
            _artists = new List<Artist>()
            {
                new Artist() {
                                ArtistId = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200"),
                                Name = "Abba",
                                City="Stockholm",
                                NrAlbums = 32,
                                CreatedAt = DateTime.Now,
                                UpdatedAt = DateTime.Now,
                                Album = null
                                },
                new Artist() {
                                ArtistId = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c201"),
                                Name = "Queen",
                                City="London",
                                NrAlbums = 51,
                                CreatedAt = DateTime.Now,
                                UpdatedAt = DateTime.Now,
                                Album = null
                                },
                new Artist() {
                                ArtistId = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c202"),
                                Name = "Modern Talking",
                                City="Berlin",
                                NrAlbums = 13,
                                CreatedAt = DateTime.Now,
                                UpdatedAt = DateTime.Now,
                                Album = null
                                },

            };
        }


        Artist IArtistService.Create(Artist newArtist)
        {
            newArtist.ArtistId = Guid.NewGuid();             
            _artists.Add(newArtist);
            return newArtist;
        }

        Artist IArtistService.Get(Guid id)
        {
            return _artists.Where(a => a.ArtistId == id)
             .FirstOrDefault();
        }

        List<Artist> IArtistService.GetList()
        {
            return _artists;
        }

        Task<int> IArtistService.Update(Artist artist)
        {
            throw new NotImplementedException();
        }
    }
}
