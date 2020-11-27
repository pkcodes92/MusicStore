// <copyright file="MusicStoreDbContext.cs" company="PK Codes">
// Copyright (c) PK Codes. All rights reserved.
// </copyright>

namespace MusicStore
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using MusicStore.Models;

    /// <summary>
    /// This class will setup the database context and also the necessary tables.
    /// </summary>
    public class MusicStoreDbContext : DbContext
    {
        /// <summary>
        /// Gets or sets the albums.
        /// </summary>
        public DbSet<Album> Albums { get; set; }

        /// <summary>
        /// Gets or sets the employees.
        /// </summary>
        public DbSet<Employee> Employees { get; set; }

        /// <summary>
        /// Gets or sets the genres.
        /// </summary>
        public DbSet<Genre> Genres { get; set; }

        /// <summary>
        /// Gets or sets the playlists.
        /// </summary>
        public DbSet<Playlist> Playlists { get; set; }

        /// <summary>
        /// Gets or sets the tracks in a playlist.
        /// </summary>
        public DbSet<PlaylistTrack> PlaylistTracks { get; set; }

        /// <summary>
        /// Gets or sets the tracks.
        /// </summary>
        public DbSet<Track> Tracks { get; set; }

        /// <summary>
        /// Gets or sets the invoices.
        /// </summary>
        public DbSet<Invoice> Invoices { get; set; }

        /// <summary>
        /// Gets or sets the invoice items.
        /// </summary>
        public DbSet<InvoiceItem> InvoiceItems { get; set; }

        /// <summary>
        /// Gets or sets the media types.
        /// </summary>
        public DbSet<MediaType> MediaTypes { get; set; }

        /// <summary>
        /// Gets or sets the customers.
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Gets or sets the artists.
        /// </summary>
        public DbSet<Artist> Artists { get; set; }

        /// <summary>
        /// This method configures the SQLite database.
        /// </summary>
        /// <param name="optionsBuilder">The DB Context options.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=Music.db");
        }

        /// <summary>
        /// This will seed the database initially.
        /// </summary>
        /// <param name="modelBuilder">The model builder to see the database with data.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder is null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            modelBuilder.Entity<Album>().HasData(
                new Album
                {
                    AlbumId = 1,
                    ArtistId = 1,
                    Title = "Hybrid Theory",
                },
                new Album
                {
                    AlbumId = 2,
                    ArtistId = 1,
                    Title = "Metora",
                });

            modelBuilder.Entity<Artist>().HasData(
                new Artist
                {
                    ArtistId = 1,
                    Name = "Linkin Park",
                });
        }
    }
}