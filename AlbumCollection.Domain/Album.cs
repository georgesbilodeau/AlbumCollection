using System.ComponentModel.DataAnnotations;

namespace AlbumCollection.Domain {
    public class Album {
        [Required]
        public int Id { get; set; } // TODO: MusicBrainz probably wants GUID

        

    }
}
