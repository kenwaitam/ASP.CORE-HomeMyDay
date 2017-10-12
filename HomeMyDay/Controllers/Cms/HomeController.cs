﻿using HomeMyDay.Web.Home.Database.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeMyDay.Web.Home.Controllers.Cms
{
	[Area("CMS")]
	[Authorize(Policy = IdentityPolicies.Administrator)]
	public class HomeController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
	}
}
