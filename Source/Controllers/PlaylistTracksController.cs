﻿// <copyright file="PlaylistTracksController.cs" company="PK Codes">
// Copyright (c) PK Codes. All rights reserved.
// </copyright>

namespace MusicStore.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using MusicStore.Models;

    /// <summary>
    /// This is the playlist tracks controller.
    /// </summary>
    [Route("api/PlaylistTracks")]
    [ApiController]
    public class PlaylistTracksController : ControllerBase
    {
        private readonly MusicStoreDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlaylistTracksController"/> class.
        /// </summary>
        /// <param name="context">The database context being injected.</param>
        public PlaylistTracksController(MusicStoreDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// This method will return all of the playlist tracks in the database.
        /// </summary>
        /// <returns>A unit of execution that contains a type of <see cref="ActionResult"/>.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlaylistTrack>>> GetPlaylistTracks()
        {
            return await this.context.PlaylistTracks.ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// This method will get a playlist track that is stored in the database.
        /// </summary>
        /// <param name="id">The playlist track ID.</param>
        /// <returns>A unit of execution that contains a type of <see cref="ActionResult"/>.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<PlaylistTrack>> GetPlaylistTrack(int id)
        {
            var playlistTrack = await this.context.PlaylistTracks.FindAsync(id).ConfigureAwait(false);

            if (playlistTrack == null)
            {
                return this.NotFound();
            }

            return playlistTrack;
        }
    }
}