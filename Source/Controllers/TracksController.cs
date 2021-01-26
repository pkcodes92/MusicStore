// <copyright file="TracksController.cs" company="PK Codes">
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
    /// This class is for performing crud operations on music tracks.
    /// </summary>
    [Route("api/Tracks")]
    [ApiController]
    public class TracksController : ControllerBase
    {
        private readonly MusicStoreDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="TracksController"/> class.
        /// </summary>
        /// <param name="context">The music database context.</param>
        public TracksController(MusicStoreDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// This method gets all the tracks from the database.
        /// </summary>
        /// <returns>A unit of execution that contains the type of <see cref="ActionResult"/>.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Track>>> GetTracks()
        {
            return await this.context.Tracks.ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// This method will return a track based on the ID.
        /// </summary>
        /// <param name="id">The ID of the track.</param>
        /// <returns>A <see cref="Task{ActionResult}"/> representing the result of the asynchronous operation.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Track>> GetTrack(int id)
        {
            var track = await this.context.Tracks.FindAsync(id).ConfigureAwait(false);

            if (track == null)
            {
                return this.NotFound();
            }

            return track;
        }

        /// <summary>
        /// This method will update the track information.
        /// </summary>
        /// <param name="id">The track ID.</param>
        /// <param name="track">The track information to update.</param>
        /// <returns>A unit of execution that will contain a type of <see cref="IActionResult"/>.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrack(int id, Track track)
        {
            if (track is null)
            {
                throw new ArgumentNullException(nameof(track));
            }

            if (id != track.TrackId)
            {
                return this.BadRequest();
            }

            this.context.Entry(track).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.TrackExists(id))
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
        /// This method will add a new track to the database.
        /// </summary>
        /// <param name="track">The track to add.</param>
        /// <returns>A unit of execution that contains a type of <see cref="ActionResult"/>.</returns>
        [HttpPost]
        public async Task<ActionResult<Track>> PostTrack(Track track)
        {
            if (track is null)
            {
                throw new ArgumentNullException(nameof(track));
            }

            this.context.Tracks.Add(track);
            await this.context.SaveChangesAsync().ConfigureAwait(false);

            return this.CreatedAtAction("GetTrack", new { id = track.TrackId }, track);
        }

        /// <summary>
        /// This method removes a track from the database.
        /// </summary>
        /// <param name="id">The ID of the track to remove.</param>
        /// <returns>A unit of execution that contains a type of <see cref="IActionResult"/>.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrack(int id)
        {
            var track = await this.context.Tracks.FindAsync(id).ConfigureAwait(false);

            if (track == null)
            {
                return this.NotFound();
            }

            this.context.Tracks.Remove(track);
            await this.context.SaveChangesAsync().ConfigureAwait(false);

            return this.NoContent();
        }

        private bool TrackExists(int id)
        {
            return this.context.Tracks.Any(e => e.TrackId == id);
        }
    }
}