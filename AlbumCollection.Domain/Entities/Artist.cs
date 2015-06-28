using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlbumCollection.Domain {
    public class Artist {
        public Artist() {
            Albums = new List<Album>();
        }

        [Key]
        [Required]
        public string MbId { get; set; }

        [Required]
        public string Name { get; set; }

        public IList<Album> Albums { get; set; }
    }
}