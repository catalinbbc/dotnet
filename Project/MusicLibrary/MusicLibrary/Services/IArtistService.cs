using MusicLibrary.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicLibrary.api.Services
{
    public interface IArtistService
    {
        List<Artist> GetList();
        Task<int> Update(Artist artist);
        Artist Create(Artist newArtist);
        Artist Get(Guid id);
    }
}
