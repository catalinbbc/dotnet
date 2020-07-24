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

        public ILogger<AlbumsController> logger { get; private set; }

        public AlbumsController(AlbumsRepository albumsRepository, INotificationService notificationService, IMemoryCache memoryCache)
        {
            this.albumsRepository = albumsRepository;
            this.notificationService = notificationService;
            _logger = logger;
            this.memoryCache = memoryCache;
        }

        // GET: api/Albums
        [HttpGet]
        public async Task<IEnumerable<Album>> GetAlbums()
        {
            var albums = await this.albumsRepository.GetAllAsync();
            return (IEnumerable<Album>)Ok(albums);

            //return await this.albumsRepository.GetAllAsync();
        }

        // GET: api/Albums/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAlbum([FromRoute] int id)
        {
            var album = await this.albumsRepository.GetAsync(id);

            if (album == null)
            {
                return NotFound();
            }

            return Ok(album);
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

            return Ok(album);
        }

    }
}
