// <copyright file="InvoicesController.cs" company="PK Codes">
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
    /// This is the controller for the invoices.
    /// </summary>
    [Route("api/Invoices")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly MusicStoreDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoicesController"/> class.
        /// </summary>
        /// <param name="context">The database context being injected.</param>
        public InvoicesController(MusicStoreDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// This method will get the invoices from the database.
        /// </summary>
        /// <returns>A unit of execution that contains a type of <see cref="ActionResult"/>.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Invoice>>> GetInvoices()
        {
            return await this.context.Invoices.ToListAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// This method will retrieve an invoice by the ID.
        /// </summary>
        /// <param name="id">The invoice ID.</param>
        /// <returns>A unit of execution that contains the type of <see cref="ActionResult"/>.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> GetInvoice(int id)
        {
            var invoice = await this.context.Invoices.FindAsync(id).ConfigureAwait(false);

            if (invoice == null)
            {
                return this.NotFound();
            }

            return invoice;
        }

        /// <summary>
        /// This method will add an invoice to the database.
        /// </summary>
        /// <param name="invoice">The invoice to add into the database.</param>
        /// <returns>A unit of execution that contains a type of <see cref="ActionResult{Invoice}"/>.</returns>
        [HttpPost]
        public async Task<ActionResult<Invoice>> PostInvoice(Invoice invoice)
        {
            if (invoice is null)
            {
                throw new ArgumentNullException(nameof(invoice));
            }

            this.context.Invoices.Add(invoice);
            await this.context.SaveChangesAsync().ConfigureAwait(false);

            return this.CreatedAtAction("GetInvoice", new { id = invoice.InvoiceId }, invoice);
        }

        /// <summary>
        /// This method will update an invoice based on the ID and information.
        /// </summary>
        /// <param name="id">The invoice ID.</param>
        /// <param name="invoice">The employee information to update.</param>
        /// <returns>A unit of execution that contains the type of <see cref="IActionResult"/>.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoice(int id, Invoice invoice)
        {
            if (invoice is null)
            {
                throw new ArgumentNullException(nameof(invoice));
            }

            if (id != invoice.InvoiceId)
            {
                return this.BadRequest();
            }

            this.context.Entry(invoice).State = EntityState.Modified;

            try
            {
                await this.context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!this.InvoiceExists(id))
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
        /// This method will delete an employee from the database based on an ID.
        /// </summary>
        /// <param name="id">The ID of the employee to delete.</param>
        /// <returns>A unit of execution that contains <see cref="IActionResult"/>.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            var invoice = await this.context.Invoices.FindAsync(id).ConfigureAwait(false);
            if (invoice == null)
            {
                return this.NotFound();
            }

            this.context.Invoices.Remove(invoice);
            await this.context.SaveChangesAsync().ConfigureAwait(false);

            return this.NoContent();
        }

        private bool InvoiceExists(int id)
        {
            return this.context.Invoices.Any(e => e.InvoiceId == id);
        }
    }
}
