namespace AlbumCollection.Domain.Migrations {
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<AlbumContext> {
        public Configuration() {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AlbumContext context) {
            AddVholSelfTitled(context);
            AddKenModeVenerable(context);
        }

        private void AddVholSelfTitled(AlbumContext context) {
            var vhol = new Artist {
                MbId = "2a4b8aa8-6659-4712-8e17-8e1e6a299348",
                Name = "Vhöl"
            };

            var vholSelfTitled = new Album {
                MbId = "e6bc2763-c64f-44bd-9c5a-73322de6518e",
                Name = "Vhöl",
                Artist = vhol,
                Year = 2013
            };

            var vholSelfTitledAlbumArt = new AlbumArt {
                Album = vholSelfTitled,
                Name = "cover",
                Type = AlbumArtType.Cover,
                Path = "/Static/V/vhol_self-titled.jpg"
            };

            vhol.Albums.Add(vholSelfTitled);
            vholSelfTitled.AlbumArt.Add(vholSelfTitledAlbumArt);

            context.Artists.AddOrUpdate(vhol);
            context.Albums.AddOrUpdate(vholSelfTitled);
            context.AlbumArt.AddOrUpdate(vholSelfTitledAlbumArt);
        }

        private void AddKenModeVenerable(AlbumContext context) {
            var kenMode = new Artist {
                MbId = "68c1feca-ff4f-4df4-a829-9c495a26c69c",
                Name = "KEN mode"
            };

            var kenModeVenerable = new Album {
                MbId = "3fc9567d-3428-4d3c-8ccc-d7a4f95ae819",
                Name = "Venerable",
                Artist = kenMode,
                Year = 2011
            };

            kenMode.Albums.Add(kenModeVenerable);

            context.Artists.AddOrUpdate(kenMode);
            context.Albums.AddOrUpdate(kenModeVenerable);
        }
    }
}