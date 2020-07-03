using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicLibrary.Data;
using MusicLibrary.Data.Entities;
using Umbraco.Core.Services;

namespace MusicLibrary.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArtistController : ControllerBase
    {
        private readonly ILogger<ArtistController> _logger;
        private readonly ApiDbContext context;
        private readonly INotificationService notificationService;

        public ArtistController(ApiDbContext context, INotificationService notificationService, ILogger<ArtistController> logger)
        {
            this.context = context;
            this.notificationService = notificationService;
            _logger = logger;
        }

        // GET: api/artists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artist>>> GetArtist()
        {
            return await this.context.Artists.ToListAsync();
        }

        // GET: api/artists/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetArtist(int id)
        {
            var artist = await this.context.Artists.FindAsync(id);

            if (artist == null)
            {
                return this.NotFound();
            }

            return artist;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtists(int id, Artist artist)
        {
            if (id < 0)
            {
                throw new ArgumentException("negative id");
            }

            this.context.Entry(artist).State = EntityState.Modified;

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
            this.context.Artists.Add(artist);
            await this.context.SaveChangesAsync();

            this.notificationService.Notify($"artist with id {artist.Id} was created!");
            return this.CreatedAtAction("GetArtist", new { id = artist.Id }, artist;
        }

        // DELETE: api/hotels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Artist>> DeleteArtist(int id)
        {
            var todoItem = await this.context.Artists.FindAsync(id);

            if (todoItem == null)
            {
                return this.NotFound();
            }

            this.context.Artists.Remove(todoItem);
            await this.context.SaveChangesAsync();

            return todoItem;
        }


        private bool ArtistExists(long id)
        {
            return this.context.Artists.Any(e => e.Id == id);
        }

    }
}
