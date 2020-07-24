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
using MusicLibrary.api.Data.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Memory;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using Microsoft.AspNetCore.Http;
using MusicLibrary.api.Extensions;

namespace MusicLibrary.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ArtistsController : ControllerBase
    {
        private readonly ILogger<ArtistsController> _logger;
        private readonly ArtistsRepository artistsRepository;
        private readonly INotificationService notificationService;
        private readonly IMemoryCache memoryCache;


        public ArtistsController(ArtistsRepository artistsRepository, INotificationService notificationService, ILogger<ArtistsController> logger, IMemoryCache memoryCache)
        {
            this.artistsRepository = artistsRepository;
            this.notificationService = notificationService;
            _logger = logger;
            this.memoryCache = memoryCache;
        }

        // GET: api/artists
        [HttpGet]

        public async Task<IEnumerable<Artist>> GetArtists()
        {

            var artists = await this.artistsRepository.GetAllAsync();
            return (IEnumerable<Artist>)Ok(artists);

            //return await this.artistsRepository.GetAllAsync();
        }

        // GET: api/artists/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetArtist(int id)
        {
            var artist = await this.artistsRepository.GetAsync(id);

            if (artist == null)
            {
                return this.NotFound();
            }

            return artist;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtist(int id, [FromBody] Artist artist, [FromHeader(Name = "if-match")][Required] string eTag, CancellationToken cancellationToken)

        {
            if (!ArtistExists(id))
            {
                return NotFound();
            }

            if (eTag != artist.GetEtag())
            {
                return StatusCode(StatusCodes.Status412PreconditionFailed, "Invalid Etag value");
            }


            await this.artistsRepository.UpdateAsync(artist);


            return this.NoContent();
        }

        // POST: api/hotels
        [HttpPost]
        public async Task<ActionResult<Artist>> PostArtists(Artist artist)
        {

            await this.artistsRepository.AddAsync(artist);

            this.notificationService.Notify($"artist with id {artist.Id} was created!");
            return this.CreatedAtAction("GetArtist", new { id = artist.Id }, artist);
        }

        // DELETE: api/hotels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Artist>> DeleteArtist(int id)
        {
            var artist = await this.artistsRepository.GetAsync(id);
            if (artist == null)
            {
                return this.NotFound();            
            }

            await this.artistsRepository.DeleteAsync(artist);

            return artist;
        }


        private bool ArtistExists(long id)
        {
            return this.artistsRepository.Exists(id);
        }

    }
}
