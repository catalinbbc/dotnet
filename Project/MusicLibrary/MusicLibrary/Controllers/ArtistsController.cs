﻿using System;
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
using MusicLibrary.api.Services;

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
        private MemoryCacheEntryOptions cacheEntryOptions;
        private IArtistService service;

        public ArtistsController(ArtistsRepository artistsRepository, INotificationService notificationService, ILogger<ArtistsController> logger, IMemoryCache memoryCache)
        {
            this.artistsRepository = artistsRepository;
            this.notificationService = notificationService;
            _logger = logger;
            this.memoryCache = memoryCache;


            this.cacheEntryOptions = new MemoryCacheEntryOptions();

            // set AbsoluteExpiration
            //options.AbsoluteExpiration = DateTime.Now.AddMinutes(1);

            // set SlidingExpiration 
            this.cacheEntryOptions.SlidingExpiration = TimeSpan.FromMinutes(10);
        }

        public ArtistsController(IArtistService service)
        {
            this.service = service;
        }

        // GET: api/artists
        [HttpGet]

        public async Task<IEnumerable<Artist>> GetArtists()
        {
            var key = $"_artists_all";
            if (this.memoryCache.TryGetValue(key, out List<Artist> artists))
            {
                this._logger.LogInformation("ArtistController-GetArtists all cache hit");
                return (IEnumerable<Artist>)Ok(artists);
            }
            else
            {
                var artistsNonC = await this.artistsRepository.GetAllAsync();
                this.memoryCache.Set(key, artistsNonC, this.cacheEntryOptions);

                return (IEnumerable<Artist>)Ok(artistsNonC);

            }

            //return await this.artistsRepository.GetAllAsync();
        }

        // GET: api/artists/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetArtist(int id)
        {

            var key = $"_artist_{id}";
            
            if (this.memoryCache.TryGetValue(key, out Artist artist))
            {
                this._logger.LogInformation("ArtistController-GetArtists all cache hit");
                return artist;
            }
            else
            {
                var artistNonCache = await this.artistsRepository.GetAsync(id);
                if (artist == null)
                {
                    return this.NotFound();
                }
                this.memoryCache.Set(key, artistNonCache, this.cacheEntryOptions);
                return artistNonCache;
            }
            
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
            //invalidate cache 
            var key = $"_artist_{id}";
            this.memoryCache.Remove(key);

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
            //invalidate cache 
            var key = $"_artist_{id}";
            this.memoryCache.Remove(key);

            return artist;
        }


        private bool ArtistExists(long id)
        {
            return this.artistsRepository.Exists(id);
        }

    }
}
