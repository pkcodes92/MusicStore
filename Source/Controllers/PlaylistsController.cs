// <copyright file="PlaylistsController.cs" company="PK Codes">
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
    /// This is the controller for the playlists.
    /// </summary>
    [Route("api/Playlists")]
    [ApiController]
    public class PlaylistsController : ControllerBase
    {
        private readonly MusicStoreDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlaylistsController"/> class.
        /// </summary>
        /// <param name="context">This is the database context.</param>
        public PlaylistsController(MusicStoreDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// This method gets all the playlists from the database.
        /// </summary>
        /// <returns>A unit of execution that contains the type of <see cref="ActionResult"/>.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Playlist>>> GetPlaylists()
        {
            return await this.context.Playlists.ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// This method gets the playlist based on the ID.
        /// </summary>
        /// <param name="id">The ID of the playlist to get.</param>
        /// <returns>A unit of execution that contains a type of <see cref="ActionResult"/>.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Playlist>> GetPlaylist(int id)
        {
            var playlist = await this.context.Playlists.FindAsync(id).ConfigureAwait(false);

            if (playlist == null)
            {
                return this.NotFound();
            }

            return playlist;
        }

        /// <summary>
        /// This method will add a new playlist to the database.
        /// </summary>
        /// <param name="playlist">The playlist to add.</param>
        /// <returns>A unit of execution that contains a type of <see cref="ActionResult"/>.</returns>
        [HttpPost]
        public async Task<ActionResult<Playlist>> PostPlaylist(Playlist playlist)
        {
            if (playlist is null)
            {
                throw new ArgumentNullException(nameof(playlist));
            }

            this.context.Playlists.Add(playlist);
            await this.context.SaveChangesAsync().ConfigureAwait(false);

            return this.CreatedAtAction("GetPlaylist", new { id = playlist.PlaylistId }, playlist);
        }

        /// <summary>
        /// This method will update the playlist information.
        /// </summary>
        /// <param name="id">The playlist ID.</param>
        /// <param name="playlist">The playlist information to update.</param>
        /// <returns>A unit of execution that will contain a type of <see cref="IActionResult"/>.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlaylist(int id, Playlist playlist)
        {
            if (playlist is null)
            {
                throw new ArgumentNullException(nameof(playlist));
            }

            if (id != playlist.PlaylistId)
            {
                return this.BadRequest();
            }

            this.context.Entry(playlist).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.PlaylistExists(id))
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
        /// This method would delete a playlist from the database.
        /// </summary>
        /// <param name="id">The id of the playlist to delete.</param>
        /// <returns>A unit of execution that contains a type of <see cref="IActionResult"/>.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlaylist(int id)
        {
            var playlist = await this.context.Playlists.FindAsync(id).ConfigureAwait(false);
            if (playlist == null)
            {
                return this.NotFound();
            }

            this.context.Playlists.Remove(playlist);
            await this.context.SaveChangesAsync().ConfigureAwait(false);

            return this.NoContent();
        }

        private bool PlaylistExists(int id)
        {
            return this.context.Playlists.Any(e => e.PlaylistId == id);
        }
    }
}