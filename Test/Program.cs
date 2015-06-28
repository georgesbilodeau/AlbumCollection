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
                //ShowAlbumWithTracks("88189444-133e-42ab-a250-ea60b2b4b0fd");
                //SearchArtists("KEN mode");
                ShowArtist("68c1feca-ff4f-4df4-a829-9c495a26c69c");
                //TestRepo("e6bc2763-c64f-44bd-9c5a-73322de6518e");
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            } finally {
                Console.Read();
            }
        }

        private static async void ShowAlbumWithTracks(string id) {
            var album = await Release.GetAsync(id, "recordings");
            Console.WriteLine("release: " + album.Title);
            Console.WriteLine("----------------");

            Medium medium = album.MediumList.Items.First();
            foreach (Track track in medium.Tracks.Items)
                Console.WriteLine(@"{0}. {1} ({2:%m\:ss})", track.Position, track.Recording.Title, TimeSpan.FromMilliseconds(track.Length));
        }

        private static async void SearchArtists(string name) {
            ArtistList artistList = await Artist.SearchAsync(name);
            foreach (var artist in artistList.Items)
                Console.WriteLine("match: {0} ({1})", artist.Name, artist.Id);
        }

        private static async void ShowArtist(string id) {
            var artist = await Artist.GetAsync(id);
            
            ReleaseList albums = await Release.BrowseAsync("artist", id);
            
            Console.WriteLine("artist: {0} ({1})", artist.Name, artist.Id);
            foreach (Release album in albums.Items) {
                Console.WriteLine("release: {0} ({1})", album.Title, album.Id);
                Console.WriteLine("----------------");

                await ShowTracks(album.Id);

                Console.WriteLine();
            }
        }

        private static async Task<RecordingList> ShowTracks(string releaseId) {
            RecordingList tracks = await Recording.BrowseAsync("release", releaseId);
            foreach (Recording track in tracks.Items)
                Console.WriteLine(@"{0} ({1:%m\:ss})", track.Title, TimeSpan.FromMilliseconds(track.Length));
            return tracks;
        }

        private static async void TestRepo(string releaseId) {
            var albumRepo = new AlbumRepo();
            Release release = await albumRepo.LoadAsync("e6bc2763-c64f-44bd-9c5a-73322de6518e");
            Console.WriteLine("release: " + release.Title);
        }
    }
}
