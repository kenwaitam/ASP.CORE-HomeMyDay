﻿using System.Linq;
using HomeMyDay.Web.Home.Extensions;
using HomeMyDay.Core.Repository;
using HomeMyDay.Web.Home.ViewModels;
using Microsoft.AspNetCore.Mvc;
using HomeMyDay.Core.Models;

namespace HomeMyDay.Web.Home.Controllers
{
	public class ReviewController : Controller
	{
		private readonly IReviewRepository _repository;

		public ReviewController(IReviewRepository repo)
		{
			_repository = repo;
		}

		public ViewResult Index()
		{
			return View(_repository.Reviews.Select(ReviewViewModel.FromReview).Where(x => x.Approved));
		}

		[HttpPost]
		public IActionResult AddReview(ReviewViewModel reviewViewModel)
		{
			if (_repository.AddReview(reviewViewModel.AccommodationId, reviewViewModel.Title,
				reviewViewModel.Name, reviewViewModel.Text))
			{
				TempData["Succeeded"] = true;
				return RedirectToAction(nameof(AccommodationController.Detail), nameof(AccommodationController).TrimControllerName(), new { id = reviewViewModel.AccommodationId });
			}

			TempData["Succeeded"] = false;
			return RedirectToAction(nameof(AccommodationController.Detail), nameof(AccommodationController).TrimControllerName());
		}
	}
}