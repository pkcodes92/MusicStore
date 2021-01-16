// <copyright file="TracksController.cs" company="PK Codes">
// Copyright (c) PK Codes. All rights reserved.
// </copyright>

namespace MusicStore.Controllers
{
    using System.Collections.Generic;
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
    }
}