// <copyright file="CustomersController.cs" company="PK Codes">
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
    /// This is the customers controller.
    /// </summary>
    [Route("api/Customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly MusicStoreDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomersController"/> class.
        /// </summary>
        /// <param name="context">The music database context being injected.</param>
        public CustomersController(MusicStoreDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// This method gets all the customers from the database.
        /// </summary>
        /// <returns>A unit of execution that contains the type of <see cref="ActionResult"/>.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await this.context.Customers.ToListAsync().ConfigureAwait(false);
        }
    }
}