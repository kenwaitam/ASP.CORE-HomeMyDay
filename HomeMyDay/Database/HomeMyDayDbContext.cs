﻿using HomeMyDay.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeMyDay.Database
{
	public class HomeMyDayDbContext : DbContext
	{
		/// <summary>
		/// Required constructor for entity framework. Passes options to parent class constructor.
		/// </summary>
		/// <param name="options">The DB options to pass to the base class.</param>
		public HomeMyDayDbContext(DbContextOptions<HomeMyDayDbContext> options) : base(options)
		{

		}

		/// <summary>
		/// The Bookings that have been saved.
		/// </summary>
		public DbSet<Booking> Bookings { get; set; }
		
		/// <summary>
		/// The Accommodations that have been saved.
		/// </summary>
		public DbSet<Accommodation> Accommodations { get; set; }

		/// <summary>
		/// Gets or sets the media objects.
		/// </summary>
		public DbSet<MediaObject> MediaObjects { get; set; }

        public DbSet<Vacancie> Jobs { get; set; }
    }
}
