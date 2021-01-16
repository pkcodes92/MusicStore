// <copyright file="CustomersController.cs" company="PK Codes">
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

        /// <summary>
        /// This method will get a customer by their ID.
        /// </summary>
        /// <param name="id">The ID of the customer.</param>
        /// <returns>A unit of execution that contains a type of <see cref="ActionResult"/>.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var artist = await this.context.Customers.FindAsync(id).ConfigureAwait(false);

            if (artist == null)
            {
                return this.NotFound();
            }

            return artist;
        }

        /// <summary>
        /// This method will update a customer by the ID.
        /// </summary>
        /// <param name="id">The customer ID.</param>
        /// <param name="customer">The customer information to update.</param>
        /// <returns>A unit of execution that contains the type of <see cref="IActionResult"/>.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (customer is null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            if (id != customer.CustomerId)
            {
                return this.BadRequest();
            }

            this.context.Entry(customer).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.CustomerExists(id))
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

        private bool CustomerExists(int id)
        {
            return this.context.Customers.Any(e => e.CustomerId == id);
        }
    }
}