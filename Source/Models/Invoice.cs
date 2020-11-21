// <copyright file="Invoice.cs" company="PK Codes">
// Copyright (c) PK Codes. All rights reserved.
// </copyright>

namespace MusicStore.Models
{
    using System;

    /// <summary>
    /// This class models an invoice.
    /// </summary>
    public class Invoice
    {
        /// <summary>
        /// Gets or sets the invoice ID.
        /// </summary>
        public int InvoiceId { get; set; }

        /// <summary>
        /// Gets or sets the customer ID.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the invoice date.
        /// </summary>
        public DateTime InvoiceDate { get; set; }

        /// <summary>
        /// Gets or sets the billing address.
        /// </summary>
        public string BillingAddress { get; set; }

        /// <summary>
        /// Gets or sets the billing city.
        /// </summary>
        public string BillingCity { get; set; }

        /// <summary>
        /// Gets or sets the billing state.
        /// </summary>
        public string BillingState { get; set; }

        /// <summary>
        /// Gets or sets the billing country.
        /// </summary>
        public string BillingCountry { get; set; }

        /// <summary>
        /// Gets or sets the postal code.
        /// </summary>
        public string BillingPostalCode { get; set; }

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        public string Total { get; set; }
    }
}