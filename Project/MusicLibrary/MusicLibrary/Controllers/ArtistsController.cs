using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicLibrary.Api.Services;
using Microsoft.EntityFrameworkCore;
using MusicLibrary.Data;
using MusicLibrary.Data.Entities;

namespace MusicLibrary.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArtistsController : ControllerBase
    {
        private readonly ILogger<ArtistsController> _logger;
        private readonly ApiDbContext context;
        private readonly INotificationService notificationService;

        public ArtistsController(ApiDbContext context, INotificationService notificationService, ILogger<ArtistsController> logger)
        {
            this.context = context;
            this.notificationService = notificationService;
            _logger = logger;
        }

        // GET: api/artists
        [HttpGet]

        public IEnumerable<Artist> GetArtist()
        {
            return this.context.Artist;
        }

        // GET: api/artists/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetArtist(int id)
        {
            var artist = await this.context.Artist.FindAsync(id);

            if (artist == null)
            {
                return this.NotFound();
            }

            return artist;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtist(int id, Artist artist)
        {
            if (id < 0)
            {
                throw new ArgumentException("negative id");
            }

            this.context.Entry(artist).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.ArtistExists(id))
                {
                    return this.NotFound();
                }

                throw;
            }

            return this.NoContent();
        }

        // POST: api/hotels
        [HttpPost]
        public async Task<ActionResult<Artist>> PostArtists(Artist artist)
        {
            this.context.Artist.Add(artist);
            await this.context.SaveChangesAsync();

            this.notificationService.Notify($"artist with id {artist.Id} was created!");
            return this.CreatedAtAction("GetArtist", new { id = artist.Id }, artist);
        }

        // DELETE: api/hotels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Artist>> DeleteArtist(int id)
        {
            var artistDel = await this.context.Artist.FindAsync(id);

            if (artistDel == null)
            {
                return this.NotFound();
            }

            this.context.Artist.Remove(artistDel);
            await this.context.SaveChangesAsync();

            return artistDel;
        }


        private bool ArtistExists(long id)
        {
            return this.context.Artist.Any(e => e.Id == id);
        }

    }
}
