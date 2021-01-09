// <copyright file="ArtistsController.cs" company="PK Codes">
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
    /// This is the controller for the artists.
    /// </summary>
    [Route("api/Artists")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly MusicStoreDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArtistsController"/> class.
        /// </summary>
        /// <param name="context">SQLite Database context.</param>
        public ArtistsController(MusicStoreDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// GET: api/Artists which will gets all of the artists.
        /// </summary>
        /// <returns>A unit of execution that contains the type of <see cref="ActionResult"/> that contains the list of all the artists.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artist>>> GetArtists()
        {
            return await this.context.Artists.ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// This method returns an artist by the ID.
        /// </summary>
        /// <param name="id">The ID of the artist, and integer.</param>
        /// <returns>A task that returns the artist.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetArtist(int id)
        {
            var artist = await this.context.Artists.FindAsync(id).ConfigureAwait(false);

            if (artist == null)
            {
                return this.NotFound();
            }

            return artist;
        }

        /// <summary>
        /// This method will update an artist by the ID.
        /// </summary>
        /// <param name="id">The ID of the artist to update.</param>
        /// <param name="artist">The artist information to update.</param>
        /// <returns>A unit of execution that contains the final result of the operation.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtist(int id, Artist artist)
        {
            if (artist is null)
            {
                throw new ArgumentNullException(nameof(artist));
            }

            if (id != artist.ArtistId)
            {
                return this.BadRequest();
            }

            this.context.Entry(artist).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.ArtistExists(id))
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
        /// This method will insert a new artist into the database.
        /// </summary>
        /// <param name="artist">The artist information to add.</param>
        /// <returns>A unit of execution that contains the artist.</returns>
        [HttpPost]
        public async Task<ActionResult<Artist>> PostArtist(Artist artist)
        {
            if (artist is null)
            {
                throw new ArgumentNullException(nameof(artist));
            }

            this.context.Artists.Add(artist);
            await this.context.SaveChangesAsync().ConfigureAwait(false);

            return this.CreatedAtAction("GetArtist", new { id = artist.ArtistId }, artist);
        }

        /// <summary>
        /// This method will delete an artist by ID.
        /// </summary>
        /// <param name="id">The ID of the artist to delete.</param>
        /// <returns>A unit of execution that will contain a result of the operation.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtist(int id)
        {
            var artist = await this.context.Artists.FindAsync(id).ConfigureAwait(false);
            if (artist == null)
            {
                return this.NotFound();
            }

            this.context.Artists.Remove(artist);
            await this.context.SaveChangesAsync().ConfigureAwait(false);

            return this.NoContent();
        }

        private bool ArtistExists(int id)
        {
            return this.context.Artists.Any(e => e.ArtistId == id);
        }
    }
}