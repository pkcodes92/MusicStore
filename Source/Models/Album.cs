// <copyright file="Album.cs" company="PK Codes">
// Copyright (c) PK Codes. All rights reserved.
// </copyright>

namespace MusicStore.Models
{
    /// <summary>
    /// This class models an album.
    /// </summary>
    public class Album
    {
        /// <summary>
        /// Gets or sets the album ID.
        /// </summary>
        public int AlbumId { get; set; }

        /// <summary>
        /// Gets or sets the title of the album.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the artist ID.
        /// </summary>
        public int ArtistId { get; set; }
    }
}