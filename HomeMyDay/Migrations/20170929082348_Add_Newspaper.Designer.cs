﻿// <auto-generated />
using HomeMyDay.Database;
using HomeMyDay.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace HomeMyDay.Migrations
{
    [DbContext(typeof(HomeMyDayDbContext))]
    [Migration("20170929082348_Add_Newspaper")]
    partial class Add_Newspaper
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HomeMyDay.Models.Accommodation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Beds");

                    b.Property<string>("Continent");

                    b.Property<string>("Country");

                    b.Property<string>("Description");

                    b.Property<string>("Location");

                    b.Property<int>("MaxPersons");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<bool>("Recommended");

                    b.Property<int?>("Rooms");

                    b.HasKey("Id");

                    b.ToTable("Accommodations");
                });

            modelBuilder.Entity("HomeMyDay.Models.Booking", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("AccommodationId");

                    b.Property<DateTime>("DepartureDate");

                    b.Property<int>("NrPersons");

                    b.Property<DateTime>("ReturnDate");

                    b.HasKey("Id");

                    b.HasIndex("AccommodationId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("HomeMyDay.Models.DateEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("AccommodationId");

                    b.Property<DateTime>("Date");

                    b.HasKey("Id");

                    b.HasIndex("AccommodationId");

                    b.ToTable("DateEntity");
                });

            modelBuilder.Entity("HomeMyDay.Models.MediaObject", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("AccommodationId");

                    b.Property<string>("Description");

                    b.Property<bool>("Primary");

                    b.Property<string>("Title");

                    b.Property<int>("Type");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("AccommodationId");

                    b.ToTable("MediaObjects");
                });

            modelBuilder.Entity("HomeMyDay.Models.Newspaper", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("Newspapers");
                });

            modelBuilder.Entity("HomeMyDay.Models.Booking", b =>
                {
                    b.HasOne("HomeMyDay.Models.Accommodation", "Accommodation")
                        .WithMany()
                        .HasForeignKey("AccommodationId");
                });

            modelBuilder.Entity("HomeMyDay.Models.DateEntity", b =>
                {
                    b.HasOne("HomeMyDay.Models.Accommodation")
                        .WithMany("NotAvailableDates")
                        .HasForeignKey("AccommodationId");
                });

            modelBuilder.Entity("HomeMyDay.Models.MediaObject", b =>
                {
                    b.HasOne("HomeMyDay.Models.Accommodation")
                        .WithMany("MediaObjects")
                        .HasForeignKey("AccommodationId");
                });
#pragma warning restore 612, 618
        }
    }
}
