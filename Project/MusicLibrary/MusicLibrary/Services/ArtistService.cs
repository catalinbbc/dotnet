using MusicLibrary.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicLibrary.api.Services
{
    public class ArtistService : IArtistService
    {
        public Artist Get(Guid id)
        {
            throw new NotImplementedException();
        }

        Artist IArtistService.Create(Artist newArtist)
        {
            throw new NotImplementedException();
        }


        List<Artist> IArtistService.GetList()
        {
            throw new NotImplementedException();
        }

        Task<int> IArtistService.Update(Artist artist)
        {
            throw new NotImplementedException();
        }
    }
}
