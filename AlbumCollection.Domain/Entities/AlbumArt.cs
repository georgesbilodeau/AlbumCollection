using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlbumCollection.Domain {
    [Table("AlbumArt")]
    public class AlbumArt {
        [Key]
        public int Id { get; set; }

        [Required]
        public Album Album { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public AlbumArtType Type { get; set; }

        [Required]
        public string Path { get; set; }
    }

    public enum AlbumArtType {
        Cover,
        Media,
        Misc
    }
}