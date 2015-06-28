using System.Data.Entity;

namespace AlbumCollection.Domain {
    public class AlbumContext : DbContext {
        public AlbumContext() : base("EFDbContext") { }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
    }
}