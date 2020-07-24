using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MusicLibrary.Api.Services;
using MusicLibrary.Data;
using MusicLibrary.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;
using MusicLibrary.api.Data.Repositories;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Memory;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using MusicLibrary.api.Extensions;

namespace MusicLibrary.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AlbumsController : ControllerBase
    {

        private readonly ILogger<AlbumsController> _logger;
        private readonly AlbumsRepository albumsRepository;
        private readonly INotificationService notificationService;
        private readonly IMemoryCache memoryCache;
        private MemoryCacheEntryOptions cacheEntryOptions;

        public ILogger<AlbumsController> logger { get; private set; }

        public AlbumsController(AlbumsRepository albumsRepository, INotificationService notificationService, IMemoryCache memoryCache)
        {
            this.albumsRepository = albumsRepository;
            this.notificationService = notificationService;
            _logger = logger;
            this.memoryCache = memoryCache;

            this.cacheEntryOptions = new MemoryCacheEntryOptions();

            // set AbsoluteExpiration
            //options.AbsoluteExpiration = DateTime.Now.AddMinutes(1);

            // set SlidingExpiration 
            this.cacheEntryOptions.SlidingExpiration = TimeSpan.FromMinutes(10);
        }

        // GET: api/Albums
        [HttpGet]
        public async Task<IEnumerable<Album>> GetAlbums()
        {


            var key = $"_albums_all";
            if (this.memoryCache.TryGetValue(key, out List<Album> albums))
            {
                this._logger.LogInformation("AlbumController-GetAlbums all cache hit");
                return (IEnumerable<Album>)Ok(albums);
            }
            else
            {
                var albumsNonCache = await this.albumsRepository.GetAllAsync();
                this.memoryCache.Set(key, albumsNonCache, this.cacheEntryOptions);

                return (IEnumerable<Album>)Ok(albumsNonCache);

            }

            //var albums = await this.albumsRepository.GetAllAsync();
            //return (IEnumerable<Album>)Ok(albums);

            //return await this.albumsRepository.GetAllAsync();
        }

        // GET: api/Albums/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlbum([FromRoute] int id)
        {

            var key = $"_album_{id}";

            if (this.memoryCache.TryGetValue(key, out Album album))
            {
                this._logger.LogInformation($"AlbumController-GetAlbum[id] cache hit");
                return (IActionResult)album;
            }
            else
            {
                var albumNonCache = await this.albumsRepository.GetAsync(id);
                if (albumNonCache == null)
                {
                    return this.NotFound();
                }
                this.memoryCache.Set(key, albumNonCache, this.cacheEntryOptions);
                return Ok(albumNonCache);
            }

            /*
            var album = await this.albumsRepository.GetAsync(id);

            if (album == null)
            {
                return NotFound();
            }

            return Ok(album);
            */
        }

        // PUT: api/Albums/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlbum([FromRoute] int id, [FromBody] Album album, [FromHeader(Name = "if-match")][Required] string eTag, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            if (eTag != album.GetEtag())
            {
                return StatusCode(StatusCodes.Status412PreconditionFailed, "Invalid Etag value");
            }

            if (id != album.AlbumId)
            {
                return BadRequest();
            }

            if (!albumsRepository.Exists(id))
            {
                return NotFound();
            }

            await this.albumsRepository.UpdateAsync(album);
            //invalidate cache 
            var key = $"_album_{id}";
            this.memoryCache.Remove(key);


            return NoContent();
        }

        // POST: api/Albums
        [HttpPost]
        public async Task<IActionResult> PostAlbum([FromBody] Album album)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await this.albumsRepository.AddAsync(album);


            return CreatedAtAction("GetAlbum", new { id = album.AlbumId }, album);
        }

        // DELETE: api/Albums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlbum([FromRoute] int id)
        {
            var album = await this.albumsRepository.GetAsync(id);
            if (album == null)
            {
                return NotFound();
            }

            await this.albumsRepository.RemoveAsync(album);
            //invalidate cache 
            var key = $"_artist_{id}";
            this.memoryCache.Remove(key);
            return Ok(album);
        }

    }
}
