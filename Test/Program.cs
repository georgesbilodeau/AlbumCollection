using System;
using System.Linq;
using System.Threading.Tasks;
using AlbumCollection.Services.Repo;
using Hqub.MusicBrainz.API.Entities;
using Hqub.MusicBrainz.API.Entities.Collections;

namespace Test {
    class Program {
        static void Main(string[] args) {
            try {
                //ShowAlbum("e6bc2763-c64f-44bd-9c5a-73322de6518e");
                //SearchArtists("Vhol");
                //ShowArtist("2a4b8aa8-6659-4712-8e17-8e1e6a299348");
                TestRepo("e6bc2763-c64f-44bd-9c5a-73322de6518e");
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            } finally {
                Console.Read();
            }
        }

        private static async void ShowAlbum(string id) {
            var album = await Release.GetAsync(id);
            Console.WriteLine("release: " + album.Title);
        }

        private static async void SearchArtists(string name) {
            ArtistList artistList = await Artist.SearchAsync(name);
            foreach (var artist in artistList.Items)
                Console.WriteLine("match: {0} ({1})", artist.Name, artist.Id);
        }

        private static async void ShowArtist(string id) {
            var artist = await Artist.GetAsync(id);
            
            ReleaseList albums = await Release.BrowseAsync("artist", id);
            
            Console.WriteLine("artist: " + artist.Name);
            foreach (Release album in albums.Items) {
                Console.WriteLine("release: " + album.Title);
                Console.WriteLine("----------------");

                RecordingList tracks = await Recording.BrowseAsync("release", album.Id);
                foreach (Recording track in tracks.Items)
                    Console.WriteLine(@"{0} ({1:%m\:ss})", track.Title, TimeSpan.FromMilliseconds(track.Length));

                Console.WriteLine();
            }
        }

        private static async void TestRepo(string releaseId) {
            var albumRepo = new AlbumRepo();
            Release release = await albumRepo.LoadAsync("e6bc2763-c64f-44bd-9c5a-73322de6518e");
            Console.WriteLine("release: " + release.Title);
        }
    }
}
