// <copyright file="AlbumsController.cs" company="PK Codes">
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
    /// This is the controller for the albums.
    /// </summary>
    [Route("api/Albums")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly MusicStoreDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="AlbumsController"/> class.
        /// </summary>
        /// <param name="context">The database context being injected.</param>
        public AlbumsController(MusicStoreDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// This method returns all of the albums in the database.
        /// </summary>
        /// <returns>A unit of execution that contains a type of <see cref="ActionResult"/> which contains the list of albums.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Album>>> GetAlbums()
        {
            return await this.context.Albums.ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// This method gets an album based upon the ID.
        /// </summary>
        /// <param name="id">The album ID to retrieve.</param>
        /// <returns>A unit of execution that contains a type of <see cref="ActionResult"/> that contains the album being returned.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Album>> GetAlbum(int id)
        {
            var album = await this.context.Albums.FindAsync(id).ConfigureAwait(false);

            if (album == null)
            {
                return this.NotFound();
            }

            return album;
        }

        /// <summary>
        /// Updates an album given an album ID, and then using the album information.
        /// </summary>
        /// <param name="id">The album ID to look up for updating.</param>
        /// <param name="album">The album information to update.</param>
        /// <returns>A unit of execution that contains a type of <see cref="IActionResult"/> that contains an indication that the updating is successful.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlbum(int id, Album album)
        {
            if (album is null)
            {
                throw new ArgumentNullException(nameof(album));
            }

            if (id != album.AlbumId)
            {
                return this.BadRequest();
            }

            this.context.Entry(album).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.AlbumExists(id))
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
        /// This method will add a new album to the database.
        /// </summary>
        /// <param name="album">The album to add.</param>
        /// <returns>A unit of execution that contains a type of <see cref="ActionResult"/> which will contain an album that is newly added.</returns>
        [HttpPost]
        public async Task<ActionResult<Album>> PostAlbum([FromBody] Album album)
        {
            if (album is null)
            {
                throw new ArgumentNullException(nameof(album));
            }

            this.context.Albums.Add(album);
            await this.context.SaveChangesAsync().ConfigureAwait(false);

            return this.CreatedAtAction("GetAlbum", new { id = album.AlbumId }, album);
        }

        /// <summary>
        /// This method will delete an album from the database.
        /// </summary>
        /// <param name="id">The ID of the album to remove.</param>
        /// <returns>A unit of execution that contains type of <see cref="IActionResult"/> which signals when the album is successfully deleted.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlbum(int id)
        {
            var album = await this.context.Albums.FindAsync(id).ConfigureAwait(false);
            if (album == null)
            {
                return this.NotFound();
            }

            this.context.Albums.Remove(album);
            await this.context.SaveChangesAsync().ConfigureAwait(false);

            return this.NoContent();
        }

        private bool AlbumExists(int id)
        {
            return this.context.Albums.Any(e => e.AlbumId == id);
        }
    }
}