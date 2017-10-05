﻿using System.Linq;
using HomeMyDay.Extensions;
using HomeMyDay.Repository;
using HomeMyDay.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HomeMyDay.Controllers
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