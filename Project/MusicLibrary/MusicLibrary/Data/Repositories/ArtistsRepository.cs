using Microsoft.EntityFrameworkCore.Internal;
using MusicLibrary.Data;
using MusicLibrary.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicLibrary.api.Data.Repositories
{
    public class ArtistsRepository : BaseRepository<Artist>
    {
        public ArtistsRepository(ApiDbContext context)
            : base(context)
        {
            
        }

        internal bool Exists(long id)
        {
            return this.context.Artist.Any(a => a.Id == id);
        }
    }
}
