// <copyright file="PlaylistsController.cs" company="PK Codes">
// Copyright (c) PK Codes. All rights reserved.
// </copyright>

namespace MusicStore.Controllers
{
    using Microsoft.AspNetCore.Mvc;

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
    }
}