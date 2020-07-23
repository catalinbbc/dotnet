using Microsoft.EntityFrameworkCore.Internal;
using MusicLibrary.Data;
using MusicLibrary.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace MusicLibrary.api.Data.Repositories
{
    public class AlbumsRepository
    {
        private readonly ApiDbContext context;

        public AlbumsRepository(ApiDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Album>> GetAllAsync()
        {           
            return await this.context.Album.ToListAsync();
            
        }

        public async Task<Album> GetAsync(int id)
        {
            return await this.context.Album.FindAsync(id);
        }

        public async Task UpdateAsync(Album album)
        {
            this.context.Entry(album).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await this.context.SaveChangesAsync();
        }

        public async Task AddAsync(Album album)
        {
            this.context.Album.Add(album);
            await this.context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Album album)
        {
            this.context.Remove(album);
            await this.context.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return this.context.Album.Any(album => album.AlbumId == id);
        }
    }
}
