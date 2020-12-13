﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicStore;

namespace MusicStore.Migrations
{
    [DbContext(typeof(MusicStoreDbContext))]
    partial class MusicStoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("MusicStore.Models.Album", b =>
                {
                    b.Property<int>("AlbumId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ArtistId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("AlbumId");

                    b.ToTable("Albums");

                    b.HasData(
                        new
                        {
                            AlbumId = 1,
                            ArtistId = 1,
                            Title = "Hybrid Theory"
                        },
                        new
                        {
                            AlbumId = 2,
                            ArtistId = 1,
                            Title = "Metora"
                        });
                });

            modelBuilder.Entity("MusicStore.Models.Artist", b =>
                {
                    b.Property<int>("ArtistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("ArtistId");

                    b.ToTable("Artists");

                    b.HasData(
                        new
                        {
                            ArtistId = 1,
                            Name = "Linkin Park"
                        });
                });

            modelBuilder.Entity("MusicStore.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("Company")
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Fax")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.Property<string>("PostalCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .HasColumnType("TEXT");

                    b.Property<int?>("SupportRepId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("MusicStore.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Fax")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.Property<string>("PostalCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("ReportsTo")
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("MusicStore.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("MusicStore.Models.Invoice", b =>
                {
                    b.Property<int>("InvoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BillingAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("BillingCity")
                        .HasColumnType("TEXT");

                    b.Property<string>("BillingCountry")
                        .HasColumnType("TEXT");

                    b.Property<string>("BillingPostalCode")
                        .HasColumnType("TEXT");

                    b.Property<string>("BillingState")
                        .HasColumnType("TEXT");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Total")
                        .HasColumnType("TEXT");

                    b.HasKey("InvoiceId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("MusicStore.Models.InvoiceItem", b =>
                {
                    b.Property<int>("InvoiceId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("InvoiceLineId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TrackId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UnitPrice")
                        .HasColumnType("TEXT");

                    b.ToTable("InvoiceItems");
                });

            modelBuilder.Entity("MusicStore.Models.MediaType", b =>
                {
                    b.Property<int>("MediaTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("MediaTypeId");

                    b.ToTable("MediaTypes");
                });

            modelBuilder.Entity("MusicStore.Models.Playlist", b =>
                {
                    b.Property<int>("PlaylistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("PlaylistId");

                    b.ToTable("Playlists");
                });

            modelBuilder.Entity("MusicStore.Models.PlaylistTrack", b =>
                {
                    b.Property<int>("PlaylistId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TrackId")
                        .HasColumnType("INTEGER");

                    b.ToTable("PlaylistTracks");
                });

            modelBuilder.Entity("MusicStore.Models.Track", b =>
                {
                    b.Property<int>("TrackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AlbumId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Bytes")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Composer")
                        .HasColumnType("TEXT");

                    b.Property<int>("GenreId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MediaTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Milliseconds")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("UnitPrice")
                        .HasColumnType("TEXT");

                    b.HasKey("TrackId");

                    b.ToTable("Tracks");
                });
#pragma warning restore 612, 618
        }
    }
}