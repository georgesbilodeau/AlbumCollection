﻿using System;
using System.Xml.Serialization;

namespace Hqub.MusicBrainz.API.Entities {
    [XmlRoot("cover-art-archive", Namespace = "http://musicbrainz.org/ns/mmd-2.0#")]
    public class CoverArtArchive {
        /// <summary>
        /// Gets or sets a value indicating whether artwork is available or not.
        /// </summary>
        [XmlElement("artwork")]
        public bool Artwork { get; set; }

        /// <summary>
        /// Gets or sets the count.
        /// </summary>
        [XmlElement("count")]
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a front crover is available or not.
        /// </summary>
        [XmlElement("front")]
        public bool Front { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a back crover is available or not.
        /// </summary>
        [XmlElement("back")]
        public bool Back { get; set; }

        public static Uri GetCoverArtUri(string releaseId, AlbumArtFormat format) {
            string url = string.Format("http://coverartarchive.org/release/{0}/{1}", releaseId, FormatToFileName(format));
            return new Uri(url, UriKind.RelativeOrAbsolute);
        }

        private static string FormatToFileName(AlbumArtFormat format) {
            switch (format) {
                case (AlbumArtFormat.Front500):
                    return "front-500.jpg";
                case (AlbumArtFormat.Default):
                default:
                    return string.Empty;
            }
        }
    }

    public enum AlbumArtFormat {
        Default,
        Front500
    }
}
