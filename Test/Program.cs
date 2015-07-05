using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AlbumCollection.Domain;
using AlbumCollection.Services.Repo;
using MB = Hqub.MusicBrainz.API.Entities;
using MBColl = Hqub.MusicBrainz.API.Entities.Collections;

namespace Test {
    class Program {
        static void Main(string[] args) {
            try {
                //ShowAlbumWithTracks("88189444-133e-42ab-a250-ea60b2b4b0fd");
                //SearchArtists("KEN mode");
                //ShowArtist("68c1feca-ff4f-4df4-a829-9c495a26c69c");
                //TestRepo("e6bc2763-c64f-44bd-9c5a-73322de6518e");
                TestCoverArt("e6bc2763-c64f-44bd-9c5a-73322de6518e");
                //ImgTest();
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            } finally {
                Console.Read();
            }
        }

        private static async void ShowAlbumWithTracks(string id) {
            var album = await MB.Release.GetAsync(id, "recordings");
            Console.WriteLine("release: " + album.Title);
            Console.WriteLine("----------------");

            MB.Medium medium = album.MediumList.Items.First();
            foreach (MB.Track track in medium.Tracks.Items)
                Console.WriteLine(@"{0}. {1} ({2:%m\:ss})", track.Position, track.Recording.Title, TimeSpan.FromMilliseconds(track.Length));
        }

        private static async void SearchArtists(string name) {
            MBColl.ArtistList artistList = await MB.Artist.SearchAsync(name);
            foreach (var artist in artistList.Items)
                Console.WriteLine("match: {0} ({1})", artist.Name, artist.Id);
        }

        private static async void ShowArtist(string id) {
            var artist = await MB.Artist.GetAsync(id);

            MBColl.ReleaseList albums = await MB.Release.BrowseAsync("artist", id);

            Console.WriteLine("artist: {0} ({1})", artist.Name, artist.Id);
            foreach (MB.Release album in albums.Items) {
                Console.WriteLine("release: {0} ({1})", album.Title, album.Id);
                Console.WriteLine("----------------");

                await ShowTracks(album.Id);

                Console.WriteLine();
            }
        }

        private static async Task<MBColl.RecordingList> ShowTracks(string releaseId) {
            MBColl.RecordingList tracks = await MB.Recording.BrowseAsync("release", releaseId);
            foreach (MB.Recording track in tracks.Items)
                Console.WriteLine(@"{0} ({1:%m\:ss})", track.Title, TimeSpan.FromMilliseconds(track.Length));
            return tracks;
        }

        private static async void TestRepo(string releaseId) {
            var db = new AlbumContext();
            var albumRepo = new AlbumRepo(db);
            Album album = await albumRepo.LoadAsync("e6bc2763-c64f-44bd-9c5a-73322de6518e");
            Console.WriteLine("release: " + album.Name);
        }

        private static async void TestCoverArt(string releaseId) {
            Uri caaUri = MB.CoverArtArchive.GetCoverArtUri(releaseId, MB.AlbumArtFormat.Front500);

            HttpWebRequest rq = WebRequest.CreateHttp(caaUri);

            byte[] content = null;
            using (var rs = (HttpWebResponse)(await rq.GetResponseAsync())) {
                using (Stream stream = rs.GetResponseStream()) {
                    content = new byte[rs.ContentLength <= Int32.MaxValue ? Convert.ToInt32(rs.ContentLength) : Int32.MaxValue];
                    await stream.ReadAsync(content, 0, content.Length);
                }
            }

            using (var fs = new FileStream(@"D:/temp/test.jpg", FileMode.Create))
                await fs.WriteAsync(content, 0, content.Length);
        }

        private static async void ImgTest() {
            string srcPath = @"D:/temp/1318565211062710341.jpg";
            var fsRead = new FileStream(srcPath, FileMode.Open);
            byte[] buff = new byte[fsRead.Length];
            await fsRead.ReadAsync(buff, 0, buff.Length);
            fsRead.Dispose();

            var fsWrite = new FileStream(@"D:/temp/testblah.jpg", FileMode.Create);
            await fsWrite.WriteAsync(buff, 0, buff.Length);
            fsWrite.Dispose();
        }
    }
}
