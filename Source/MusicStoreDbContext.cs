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
        }
    }
}