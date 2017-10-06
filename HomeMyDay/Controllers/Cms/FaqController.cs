﻿using System.Threading.Tasks;
using HomeMyDay.Database.Identity;
using HomeMyDay.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HomeMyDay.Models;

namespace HomeMyDay.Controllers.Cms
{
	[Area("CMS")]
	//[Authorize(Policy = IdentityPolicies.Administrator)]
	public class FaqController : Controller
	{
		private readonly IFaqRepository _faqRepository;

		public FaqController(IFaqRepository repository)
		{
			_faqRepository = repository;
		}

		[HttpGet]
		public async Task<IActionResult> Index(int? page, int? pageSize)
		{
			var paginatedResult = await _faqRepository.List(page ?? 1, pageSize ?? 5);
			return View(paginatedResult);
		}

		[HttpGet]
		public IActionResult Edit()
		{
			return View(_faqRepository.GetCategoriesAndQuestions.);
		}

		[HttpPost]
		public IActionResult Edit(FaqCategory cat)
		{
			if (ModelState.IsValid)
			{
				_faqRepository.SaveFaqCategory(cat);
				return View();
			}
			else
			{
				ModelState.AddModelError(string.Empty, "Error, something went wrong while editing");
				return View();
			}
		}

		public IActionResult Add() => View("Edit", new FaqCategory());

		[HttpPost]
		public IActionResult Delete(long id)
		{
			FaqCategory deletedCat = _faqRepository.DeleteFaqCategory(id);
			if (deletedCat != null)
			{
				TempData["message"] = $"{deletedCat.CategoryName} was deleted";
			}
			return RedirectToAction("Index");
		}

	}
}
