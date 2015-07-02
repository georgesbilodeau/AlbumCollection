using System.Threading.Tasks;
using AlbumCollection.Domain;

namespace AlbumCollection.Services.Repo {
    public interface IAlbumRepo {
        Task<Album> LoadAsync(string id);
    }
}