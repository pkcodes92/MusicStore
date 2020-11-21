// <copyright file="Track.cs" company="PK Codes">
// Copyright (c) PK Codes. All rights reserved.
// </copyright>

namespace MusicStore.Models
{
    /// <summary>
    /// This class models a track.
    /// </summary>
    public class Track
    {
        /// <summary>
        /// Gets or sets the track ID.
        /// </summary>
        public int TrackId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the album ID.
        /// </summary>
        public int AlbumId { get; set; }

        /// <summary>
        /// Gets or sets the media type ID.
        /// </summary>
        public int MediaTypeId { get; set; }

        /// <summary>
        /// Gets or sets the genre ID.
        /// </summary>
        public int GenreId { get; set; }

        /// <summary>
        /// Gets or sets the composer.
        /// </summary>
        public string Composer { get; set; }

        /// <summary>
        /// Gets or sets the duration of the song in milliseconds.
        /// </summary>
        public int Milliseconds { get; set; }

        /// <summary>
        /// Gets or sets the size of the song (file size).
        /// </summary>
        public int Bytes { get; set; }

        /// <summary>
        /// Gets or sets the price of the song.
        /// </summary>
        public string UnitPrice { get; set; }
    }
}