using System;
using System.ComponentModel.DataAnnotations;

namespace AlbumCollection.Domain {
    public class Album {
        [Key]
        [Required]
        public string MbId { get; set; }

        [Required]
        public string Name { get; set; }

        public int Year { get; set; }

        public Artist Artist { get; set; }
    }
}