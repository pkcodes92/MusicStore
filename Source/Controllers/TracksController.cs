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

    [Route("api/Tracks")]
    [ApiController]
    public class TracksController : ControllerBase
    {
        private readonly MusicStoreDbContext context;

        public TracksController(MusicStoreDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Track>>> GetTracks()
        {
            return await this.context.Tracks.ToListAsync().ConfigureAwait(false);
        }
    }
}