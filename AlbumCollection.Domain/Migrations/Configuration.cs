namespace AlbumCollection.Domain.Migrations {
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;

    internal sealed class Configuration : DbMigrationsConfiguration<AlbumContext> {
        public Configuration() {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AlbumContext context) {
            AddVholSelfTitled(context);
            AddKenModeVenerable(context);
        }

        private void AddVholSelfTitled(AlbumContext context) {
            var artist = new Artist("2a4b8aa8-6659-4712-8e17-8e1e6a299348", "Vhöl");
            var album = new Album("e6bc2763-c64f-44bd-9c5a-73322de6518e", "Vhöl", artist, 2013);
            var coverArt = new AlbumArt("cover", AlbumArtType.Cover, "/Static/AlbumArt/V/vhöl_self-titled_cover.jpg", album);

            artist.Albums.Add(album);
            album.AlbumArt.Add(coverArt);

            context.Artists.AddOrUpdate(artist);
            context.Albums.AddOrUpdate(album);
            context.AlbumArt.AddOrUpdate(coverArt);
        }

        private void AddKenModeVenerable(AlbumContext context) {
            var artist = new Artist("68c1feca-ff4f-4df4-a829-9c495a26c69c", "KEN mode");
            var album = new Album("3fc9567d-3428-4d3c-8ccc-d7a4f95ae819", "Venerable", artist, 2011);

            artist.Albums.Add(album);

            context.Artists.AddOrUpdate(artist);
            context.Albums.AddOrUpdate(album);
        }

    }
}