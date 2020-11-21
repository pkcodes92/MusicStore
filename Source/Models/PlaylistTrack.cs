// <copyright file="PlaylistTrack.cs" company="PK Codes">
// Copyright (c) PK Codes. All rights reserved.
// </copyright>

namespace MusicStore.Models
{
    /// <summary>
    /// This class models a playlist track.
    /// </summary>
    public class PlaylistTrack
    {
        /// <summary>
        /// Gets or sets the playlist ID.
        /// </summary>
        public int PlaylistId { get; set; }

        /// <summary>
        /// Gets or sets the track ID.
        /// </summary>
        public int TrackId { get; set; }
    }
}