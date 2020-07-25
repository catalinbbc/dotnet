using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicLibrary.api.Extensions;
using MusicLibrary.api.Models;
using MusicLibrary.Data;
using MusicLibrary.Data.Entities;

namespace MusicLibrary.api.Controllers
{
    [Route("api/artists/{artisId}/albums")]
    [ApiController]
    public class AlbumArtistController : ControllerBase
    {
        private readonly ApiDbContext context;

        public AlbumArtistController(ApiDbContext context)
        {
            this.context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AlbumModel>> Get(int artistId, int id)
        {
            // different persistence model that requires artist id + album id 

            if (id < 0)
            {
                throw new AccessViolationException("Negative id exception");
            }

            var entity = await this.context.Album.FindAsync(id);

            if (entity == null)
            {
                return this.NotFound();
            }

            return entity.MapAsModel();
        }

        [HttpPost]
        public async Task<ActionResult<AlbumModel>> Post(int artistId, CreateAlbumRequestModel2 model)
        {
            var artist = await this.context.Artist.FindAsync(artistId);

            if (artist == null)
            {
                return this.NotFound();
            }

            var entity = model.MapAsNewEntity(artist);

            this.context.Album.Add(entity);
            await this.context.SaveChangesAsync();

            return this.CreatedAtAction("Get", new { artistId = artistId, Title = entity.Title }, entity.MapAsModel());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int artistId, int id, UpdateAlbumRequestModel model)
        {
            var album = await this.context.Album.FindAsync(id);

            if (album == null)
            {
                return this.NotFound();
            }

            album.UpdateWith(model);

            this.context.Album.Update(album);
            await this.context.SaveChangesAsync();

            return this.NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AlbumModel>> Delete(int artistId, int id)
        {
            var album = await this.context.Album.FindAsync(id);

            if (album == null)
            {
                return this.NotFound();
            }

            this.context.Album.Remove(album);
            await this.context.SaveChangesAsync();

            return album.MapAsModel();
        }
    }
}
