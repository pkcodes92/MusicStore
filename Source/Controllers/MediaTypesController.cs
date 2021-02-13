// <copyright file="MediaTypesController.cs" company="PK Codes">
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
    /// This is the media types controller.
    /// </summary>
    [Route("api/MediaTypes")]
    [ApiController]
    public class MediaTypesController : ControllerBase
    {
        private readonly MusicStoreDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaTypesController"/> class.
        /// </summary>
        /// <param name="context">This is the database context being injected.</param>
        public MediaTypesController(MusicStoreDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// This method returns all of the media types that are stored in the database.
        /// </summary>
        /// <returns>A unit of execution that contains a type of <see cref="ActionResult"/>.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MediaType>>> GetMediaTypes()
        {
            return await this.context.MediaTypes.ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// This method will get a single media type.
        /// </summary>
        /// <param name="id">The media type ID.</param>
        /// <returns>A unit of execution that contains a type of <see cref="ActionResult"/> which contains a type of <see cref="MediaType"/>.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<MediaType>> GetMediaType(int id)
        {
            var mediaType = await this.context.MediaTypes.FindAsync(id).ConfigureAwait(false);

            if (mediaType == null)
            {
                return this.NotFound();
            }

            return mediaType;
        }
    }
}
