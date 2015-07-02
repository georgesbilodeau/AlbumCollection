using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AlbumCollection.Domain {
    public class Album {

        #region Constructors

        public Album() {
            AlbumArt = new List<AlbumArt>();
        }

        #endregion

        #region Properties

        [Key]
        [Required]
        public string MbId { get; set; }

        [Required]
        public string Name { get; set; }

        public int Year { get; set; }

        [Required]
        public Artist Artist { get; set; }

        public IList<AlbumArt> AlbumArt { get; set; }

        public AlbumArt CoverArt {
            get {
                return AlbumArt.FirstOrDefault(art => art.Type == AlbumArtType.Cover);
            }
        }

        #endregion

        #region Methods

        public override string ToString() {
            return string.Format("Album: {0} ({1})", Name, MbId);
        }

        #endregion

    }
}