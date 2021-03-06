﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeMyDay.Core.Models;
using HomeMyDay.Core.Repository;
using HomeMyDay.Web.Base.ViewModels;

namespace HomeMyDay.Web.Base.Managers.Implementation
{
	public class AccommodationManager : IAccommodationManager
    {
	    private readonly IAccommodationRepository _accommodationRepository;
	    private readonly IReviewRepository _reviewRepository;

	    public AccommodationManager(IAccommodationRepository accommodationRepository, IReviewRepository reviewRepository)
	    {
		    _accommodationRepository = accommodationRepository;
		    _reviewRepository = reviewRepository;	
	    }


	    public Task<PaginatedList<Accommodation>> GetAccommodationPaginatedList(int? page, int? pageSize)
	    {
		    return _accommodationRepository.List(page ?? 1, pageSize ?? 5);
	    }

	    public IEnumerable<Accommodation> GetAccommodations()
	    {
		    return _accommodationRepository.Accommodations;
	    }

	    public Task Delete(long id)
	    {
		    return _accommodationRepository.Delete(id);
	    }

	    public Accommodation GetAccommodation(long id)
	    {
		    if (id <= 0)
		    {
				return new Accommodation();
		    }
		    return _accommodationRepository.GetAccommodation(id);
	    }

	    public AccommodationViewModel GetAccommodationViewModel(long id)
	    {	  
		    var accommodation = _accommodationRepository.GetAccommodation(id);
		    var reviews = _reviewRepository.GetAccomodationReviews(id);

		    return AccommodationViewModel.FromAccommodation(accommodation, reviews.Where(x => x.Approved).ToList());
		}														

		public IEnumerable<Accommodation> GetRecommendedAccommodations()
		{
			return _accommodationRepository.GetRecommendedAccommodations();
		}

	    public Task Save(Accommodation accommodation)
	    {
		    return _accommodationRepository.Save(accommodation);
	    }

	    public IEnumerable<Accommodation> Search(string location, DateTime departure, DateTime returnDate, int amountOfGuests)
	    {
		    return _accommodationRepository.Search(location, departure, returnDate, amountOfGuests);
	    }
    }
}
