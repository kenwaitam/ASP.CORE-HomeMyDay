﻿using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HomeMyDay.Database
{
	public class AppIdentityDbContextFactory : IDesignTimeDbContextFactory<AppIdentityDbContext>
    {
	    public AppIdentityDbContext CreateDbContext(string[] args)
	    {
		    var config = new ConfigurationBuilder()
			    .SetBasePath(Directory.GetCurrentDirectory())
			    .AddJsonFile("appsettings.json")
			    .Build();

			var optionsBuilder = new DbContextOptionsBuilder<AppIdentityDbContext>();
		    optionsBuilder.UseSqlServer(config.GetConnectionString("IdentityConnection"));

			return new AppIdentityDbContext(optionsBuilder.Options);
	    }
    }
} 