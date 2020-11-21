// <copyright file="Playlist.cs" company="PK Codes">
// Copyright (c) PK Codes. All rights reserved.
// </copyright>

namespace MusicStore.Models
{
    /// <summary>
    /// This class models a playlist.
    /// </summary>
    public class Playlist
    {
        /// <summary>
        /// Gets or sets the playlist ID.
        /// </summary>
        public int PlaylistId { get; set; }

        /// <summary>
        /// Gets or sets the playlist name.
        /// </summary>
        public string Name { get; set; }
    }
}