using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlbumCollection.Domain {
    [Table("AlbumArt")]
    public class AlbumArt {

        #region Constructors

        public AlbumArt() { }

        public AlbumArt(string name, AlbumArtType type, string path, Album album) {
            Name = name;
            Type = type;
            Path = path;
            Album = album;
        }

        #endregion

        #region Properties

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public AlbumArtType Type { get; set; }

        [Required]
        public string Path { get; set; }

        [Required]
        public Album Album { get; set; }

        #endregion

    }

    public enum AlbumArtType {
        Cover,
        Media,
        Misc
    }
}