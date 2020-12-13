// <copyright file="InvoiceItem.cs" company="PK Codes">
// Copyright (c) PK Codes. All rights reserved.
// </copyright>

namespace MusicStore.Models
{
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// This class models an invoice line item.
    /// </summary>
    [Keyless]
    public class InvoiceItem
    {
        /// <summary>
        /// Gets or sets the invoice line ID.
        /// </summary>
        public int InvoiceLineId { get; set; }

        /// <summary>
        /// Gets or sets the invoice ID.
        /// </summary>
        public int InvoiceId { get; set; }

        /// <summary>
        /// Gets or sets the track ID.
        /// </summary>
        public int TrackId { get; set; }

        /// <summary>
        /// Gets or sets the unit price.
        /// </summary>
        public string UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        public int Quantity { get; set; }
    }
}