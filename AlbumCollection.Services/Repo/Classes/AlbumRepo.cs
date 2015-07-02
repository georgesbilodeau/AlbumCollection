using System.Threading.Tasks;
using AlbumCollection.Domain;
using System.Data.Entity;

namespace AlbumCollection.Services.Repo {
    public class AlbumRepo : IAlbumRepo {
        private AlbumContext db;

        public AlbumRepo(AlbumContext db) {
            this.db = db;
        }

        #region IAlbumRepo Members

        public async Task<Album> LoadAsync(string id) {
            return await this.db.Albums
                .Include(a => a.Artist)
                .Include(a => a.AlbumArt)
                .FirstOrDefaultAsync(a => a.MbId == id);
        }

        #endregion

    }
}