using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlbumCollection.Domain {
    public class Artist {

        #region Constructors

        public Artist() {
            Albums = new List<Album>();
        }

        public Artist(string mbId, string name) : this() {
            MbId = mbId;
            Name = name;
        }

        #endregion

        #region Properties

        [Key]
        [Required]
        public string MbId { get; set; }

        [Required]
        public string Name { get; set; }

        public IList<Album> Albums { get; set; }

        #endregion

        #region Methods

        public override string ToString() {
            return string.Format("Artist: {0} ({1})", Name, MbId);
        }

        #endregion

    }
}