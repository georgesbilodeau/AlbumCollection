using AlbumCollection.Domain;
using AlbumCollection.Services.Repo;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace AlbumCollection.Tests {
    [TestFixture]
    public class RepoTests {
        private IAlbumRepo albumRepo;

        [TestFixtureSetUp]
        public void SetUpRepos() {
            var db = new AlbumContext();
            this.albumRepo = new AlbumRepo(db);
        }

        [Test]
        public async void AlbumIncludesOtherEntities() {
            // arrange
            string mbAlbumId = "e6bc2763-c64f-44bd-9c5a-73322de6518e"; // vhöl - self-titled

            // act
            Album album = await this.albumRepo.LoadAsync(mbAlbumId);

            // assert
            Assert.That(album.Artist, Is.Not.Null);
            Assert.That(album.Artist.Name, Is.Not.Empty);
            Assert.That(album.CoverArt, Is.Not.Null);
            Assert.That(album.CoverArt.Path, Is.Not.Empty);
        }
    }
}
