
namespace MusicLibrary.Data
{
    using Entities;
    using Microsoft.EntityFrameworkCore;
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Artist> Artists { get; set; }
        public object Artist { get; internal set; }
    }
}

