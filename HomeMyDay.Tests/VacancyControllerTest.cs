﻿using System;
using HomeMyDay.Core.Repository;
using Xunit;
using HomeMyDay.Infrastructure.Database;
using HomeMyDay.Infrastructure.Repository;
using HomeMyDay.Web.Site.Home.Controllers;
using Microsoft.EntityFrameworkCore;

namespace HomeMyDay.Tests
{
	public class VacancyControllerTest
    {
        [Fact]
        public void TestEmptyVacancies()
        {
            var optionsBuilder = new DbContextOptionsBuilder<HomeMyDayDbContext>();
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            HomeMyDayDbContext context = new HomeMyDayDbContext(optionsBuilder.Options);
            IVacancyRepository repository = new EFVacancyRepository(context);

            VacancyController target = new VacancyController(repository);

            Assert.Empty(repository.Vacancies);
        }
    }
}
