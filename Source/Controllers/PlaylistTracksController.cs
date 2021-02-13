// <copyright file="PlaylistTracksController.cs" company="PK Codes">
// Copyright (c) PK Codes. All rights reserved.
// </copyright>

namespace MusicStore.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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

        /// <summary>
        /// This method will update a playlist track.
        /// </summary>
        /// <param name="id">The playlist id.</param>
        /// <param name="playlistTrack">The playlist track information.</param>
        /// <returns>A unit of execution that contains the type of <see cref="IActionResult"/>.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlaylistTrack(int id, PlaylistTrack playlistTrack)
        {
            if (playlistTrack is null)
            {
                throw new ArgumentNullException(nameof(playlistTrack));
            }

            if (id != playlistTrack.PlaylistId)
            {
                return this.BadRequest();
            }

            this.context.Entry(playlistTrack).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception)
            {
                if (!this.PlaylistTrackExists(id))
                {
                    return this.NotFound();
                }
                else
                {
                    throw;
                }
            }

            return this.NoContent();
        }

        /// <summary>
        /// This method adds a new playlist track to the database.
        /// </summary>
        /// <param name="playlistTrack">The playlist track to add.</param>
        /// <returns>A unit of execution that contains a type of <see cref="ActionResult"/> which contains the type of <see cref="PlaylistTrack"/>.</returns>
        [HttpPost]
        public async Task<ActionResult<PlaylistTrack>> PostPlaylistTrack(PlaylistTrack playlistTrack)
        {
            if (playlistTrack is null)
            {
                throw new ArgumentNullException(nameof(playlistTrack));
            }

            this.context.PlaylistTracks.Add(playlistTrack);
            await this.context.SaveChangesAsync().ConfigureAwait(false);

            return this.CreatedAtAction("GetPlaylistTrack", new { id = playlistTrack.PlaylistId }, playlistTrack);
        }

        private bool PlaylistTrackExists(int id)
        {
            return this.context.PlaylistTracks.Any(e => e.PlaylistId == id);
        }
    }
}