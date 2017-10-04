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
    [Migration("20171003120132_Add_FaqCategory")]
    partial class Add_FaqCategory
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

                    b.Property<string>("CancellationText");

                    b.Property<string>("Continent");

                    b.Property<string>("Country");

                    b.Property<string>("Description");

                    b.Property<string>("Location");

                    b.Property<int>("MaxPersons");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<string>("PricesText");

                    b.Property<bool>("Recommended");

                    b.Property<int?>("Rooms");

                    b.Property<string>("RulesText");

                    b.Property<string>("ServicesText");

                    b.Property<string>("SpaceText");

                    b.HasKey("Id");

                    b.ToTable("Accommodations");
                });

            modelBuilder.Entity("HomeMyDay.Models.Booking", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("AccommodationId");

                    b.Property<DateTime>("DepartureDate");

                    b.Property<bool>("InsuranceCancellationAllRisk");

                    b.Property<bool>("InsuranceCancellationBasic");

                    b.Property<bool>("InsuranceExplore");

                    b.Property<bool>("InsuranceService");

                    b.Property<int>("InsuranceType");

                    b.Property<DateTime>("ReturnDate");

                    b.Property<bool>("TransferFromAirport");

                    b.Property<bool>("TransferToAirport");

                    b.HasKey("Id");

                    b.HasIndex("AccommodationId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("HomeMyDay.Models.BookingPerson", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Baggage");

                    b.Property<DateTime?>("BirthDate")
                        .IsRequired();

                    b.Property<long?>("BookingId");

                    b.Property<bool>("BookingOwner");

                    b.Property<long>("CountryId");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<int>("HouseNumber");

                    b.Property<string>("HouseNumberSuffix");

                    b.Property<string>("Initials")
                        .IsRequired();

                    b.Property<string>("Insertion");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<long>("NationalityId");

                    b.Property<string>("PhoneNumber")
                        .IsRequired();

                    b.Property<string>("PostalCode")
                        .IsRequired();

                    b.Property<string>("Salutation")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.HasIndex("CountryId");

                    b.HasIndex("NationalityId");

                    b.ToTable("BookingPerson");
                });

            modelBuilder.Entity("HomeMyDay.Models.Country", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CountryCode");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Countries");
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

                    b.Property<string>("Email")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAlternateKey("Email")
                        .HasName("Alt_Email");

                    b.ToTable("Newspapers");
                });

            modelBuilder.Entity("HomeMyDay.Models.Review", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("AccommodationId");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Name");

                    b.Property<string>("Text");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("AccommodationId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("HomeMyDay.Models.Vacancy", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AboutFunction");

                    b.Property<string>("AboutVacancy");

                    b.Property<string>("City");

                    b.Property<string>("Company");

                    b.Property<string>("JobRequirements");

                    b.Property<string>("JobTitle");

                    b.Property<string>("WeOffer");

                    b.HasKey("Id");

                    b.ToTable("Vacancies");
                });

            modelBuilder.Entity("HomeMyDay.Models.Booking", b =>
                {
                    b.HasOne("HomeMyDay.Models.Accommodation", "Accommodation")
                        .WithMany()
                        .HasForeignKey("AccommodationId");
                });

            modelBuilder.Entity("HomeMyDay.Models.BookingPerson", b =>
                {
                    b.HasOne("HomeMyDay.Models.Booking")
                        .WithMany("Persons")
                        .HasForeignKey("BookingId");

                    b.HasOne("HomeMyDay.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HomeMyDay.Models.Country", "Nationality")
                        .WithMany()
                        .HasForeignKey("NationalityId")
                        .OnDelete(DeleteBehavior.Cascade);
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

            modelBuilder.Entity("HomeMyDay.Models.Review", b =>
                {
                    b.HasOne("HomeMyDay.Models.Accommodation", "Accommodation")
                        .WithMany()
                        .HasForeignKey("AccommodationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
