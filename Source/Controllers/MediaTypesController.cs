// <copyright file="MediaTypesController.cs" company="PK Codes">
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
    }
}
