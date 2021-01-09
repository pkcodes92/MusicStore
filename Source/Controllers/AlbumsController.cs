// <copyright file="AlbumsController.cs" company="PK Codes">
// Copyright (c) PK Codes. All rights reserved.
// </copyright>

namespace MusicStore.Controllers
{
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

        // GET: api/Albums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Album>>> GetAlbums()
        {
            return await this.context.Albums.ToListAsync().ConfigureAwait(false);
        }

        // GET: api/Albums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Album>> GetAlbum(int id)
        {
            var album = await this.context.Albums.FindAsync(id);

            if (album == null)
            {
                return this.NotFound();
            }

            return album;
        }

        // PUT: api/Albums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlbum(int id, Album album)
        {
            if (id != album.AlbumId)
            {
                return this.BadRequest();
            }

            this.context.Entry(album).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync();
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

        // POST: api/Albums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Album>> PostAlbum([FromBody] Album album)
        {
            this.context.Albums.Add(album);
            await this.context.SaveChangesAsync();

            return this.CreatedAtAction("GetAlbum", new { id = album.AlbumId }, album);
        }

        // DELETE: api/Albums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlbum(int id)
        {
            var album = await this.context.Albums.FindAsync(id);
            if (album == null)
            {
                return this.NotFound();
            }

            this.context.Albums.Remove(album);
            await this.context.SaveChangesAsync();

            return this.NoContent();
        }

        private bool AlbumExists(int id)
        {
            return this.context.Albums.Any(e => e.AlbumId == id);
        }
    }
}