using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.DTOs;

namespace Vidly.Controllers.Api
{
	public class NewRentalsController : ApiController
	{
		private ApplicationDbContext _dbContext;

		public NewRentalsController()
		{
			_dbContext = new ApplicationDbContext();
		}

		[HttpPost]
		public IHttpActionResult CreateNewRentals(NewRentalDto newRentalDto)
		{
			var customers = _dbContext.Customers.SingleOrDefault(i => i.Id == newRentalDto.CustomerId);
			var moviesList = _dbContext.Movies.Where(i => newRentalDto.MovieIds.Contains(i.Id)).ToList();

			foreach (var movie in moviesList)
			{
				if (movie.NumberAvailable == 0)
					return BadRequest("Movie is not available.");

				movie.NumberAvailable--;

				var rental = new Rental
				{
					Customer = customers,
					Movie = movie,
					DateRented = DateTime.Now
				};

				_dbContext.Rentals.Add(rental);
			}
			_dbContext.SaveChanges();
			return Ok();
		}
	}
}
