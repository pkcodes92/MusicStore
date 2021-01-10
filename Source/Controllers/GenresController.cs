// <copyright file="GenresController.cs" company="PK Codes">
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
    using MusicStore;
    using MusicStore.Models;

    /// <summary>
    /// This is the controller for all the genres.
    /// </summary>
    [Route("api/Genres")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly MusicStoreDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenresController"/> class.
        /// </summary>
        /// <param name="context">The database context class being injected.</param>
        public GenresController(MusicStoreDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// This method will return all of the genres that are listed in the database.
        /// </summary>
        /// <returns>A unit of execution that contains the type of <see cref="ActionResult{Genre}"/> which contains a list of the genres.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>> GetGenres()
        {
            return await this.context.Genres.ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// This method will get the genre by the ID.
        /// </summary>
        /// <param name="id">The ID of the genre.</param>
        /// <returns>A unit of execution that contains the type of <see cref="ActionResult{Genre}"/>.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Genre>> GetGenre(int id)
        {
            var genre = await this.context.Genres.FindAsync(id).ConfigureAwait(false);

            if (genre == null)
            {
                return this.NotFound();
            }

            return genre;
        }

        /// <summary>
        /// This method will update the genre based on the ID.
        /// </summary>
        /// <param name="id">The ID of the genre.</param>
        /// <param name="genre">The information of the genre to update.</param>
        /// <returns>A unit of execution that contains the type of <see cref="IActionResult"/>.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenre(int id, Genre genre)
        {
            if (genre is null)
            {
                throw new ArgumentNullException(nameof(genre));
            }

            if (id != genre.GenreId)
            {
                return this.BadRequest();
            }

            this.context.Entry(genre).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.GenreExists(id))
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
        /// This method will add a new genre to the database.
        /// </summary>
        /// <param name="genre">The genre to add.</param>
        /// <returns>A unit of execution that contains a type of <see cref="ActionResult{Genre}"/>.</returns>
        [HttpPost]
        public async Task<ActionResult<Genre>> PostGenre(Genre genre)
        {
            if (genre is null)
            {
                throw new ArgumentNullException(nameof(genre));
            }

            this.context.Genres.Add(genre);
            await this.context.SaveChangesAsync().ConfigureAwait(false);

            return this.CreatedAtAction("GetGenre", new { id = genre.GenreId }, genre);
        }

        /// <summary>
        /// This method will delete a genre from the database based on an ID.
        /// </summary>
        /// <param name="id">The ID of the genre to delete.</param>
        /// <returns>A unit of execution that contains <see cref="IActionResult"/>.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            var genre = await this.context.Genres.FindAsync(id).ConfigureAwait(false);
            if (genre == null)
            {
                return this.NotFound();
            }

            this.context.Genres.Remove(genre);
            await this.context.SaveChangesAsync().ConfigureAwait(false);

            return this.NoContent();
        }

        private bool GenreExists(int id)
        {
            return this.context.Genres.Any(e => e.GenreId == id);
        }
    }
}