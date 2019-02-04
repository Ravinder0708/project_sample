using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
	public class MoviesController : Controller
	{
		public ApplicationDbContext _dbContext;

		public MoviesController()
		{
			_dbContext = new ApplicationDbContext();
		}
		protected override void Dispose(bool disposing)
		{
			_dbContext.Dispose();
		}

		public ActionResult Index()
		{
			//var movies = GetMovies();
			//return View(movies);
			//return View(GetMovieDetails());Code is commented. Because these is only practice in part 2 in exercise2.
			var getMovies = _dbContext.Movies.Include(c => c.genre).ToList();
			return View(getMovies);
		}

		public ActionResult Display(int id)
		{
			var selectedItem = GetMovieDetails().Where(i => i.Id == id);//This will return IEnumerable list.

			//var customer = GetMovieDetails().SingleOrDefault(c => c.Id == id);//This will return Model.Code is commented. Because these is only practice in part 2 in exercise2.

			var customer = _dbContext.Movies.Include(y => y.genre).SingleOrDefault(c => c.Id == id);

			if (customer == null)
				return HttpNotFound();

			return View(customer);
		}

		/// <summary>
		/// Add New Movie Form
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public ActionResult MovieForm()
		{
			var viewModel = new MovieFormViewModel()
			{
				genreProp = _dbContext.Genres.ToList()
			};
			return View(viewModel);
		}

		/// <summary>
		/// Edit Movie Form
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public ActionResult MovieFormEdit(int id)
		{
			var movie = _dbContext.Movies.Include(x => x.genre).SingleOrDefault(y => y.Id == id);
			if (movie == null)
			{
				return HttpNotFound();
			}
			else
			{
				var viewModel = new MovieFormViewModel()
				{
					movieProp = movie,
					genreProp = _dbContext.Genres.ToList()
				};
				return View("MovieForm", viewModel);
			}
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Save(MovieFormViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				if (viewModel.movieProp.Id == 0)
				{
					viewModel.movieProp.DateAdded = Convert.ToDateTime(DateTime.Now.ToShortDateString());
					_dbContext.Movies.Add(viewModel.movieProp);
				}
				else
				{
					var movieInDb = _dbContext.Movies.SingleOrDefault(x => x.Id == viewModel.movieProp.Id);
					movieInDb.Name = viewModel.movieProp.Name;
					movieInDb.ReleaseDate = viewModel.movieProp.ReleaseDate;
					movieInDb.DateAdded = viewModel.movieProp.DateAdded;
					movieInDb.GenreId = viewModel.movieProp.GenreId;
				}
				_dbContext.SaveChanges();
				return RedirectToAction("Index", "Movies");
			}
			else
			{
				viewModel.genreProp = _dbContext.Genres.ToList();
				return View("MovieForm",viewModel);
			}
		}

		#region UnUsed Code

		private List<Movie> GetMovieDetails()
		{
			var movies = new List<Movie>
			{
				new Movie(){Id=1,Name="Titanic1"},
				new Movie(){Id=2 ,Name="Titanic2"},
			};
			return movies;
		}

		private IEnumerable<Movie> GetMovies()
		{
			return new List<Movie>
			{
				new Movie { Id = 1, Name = "Shrek" },
				new Movie { Id = 2, Name = "Wall-e" }
			};
		}

		public ActionResult Random()
		{
			var movie = new Movie()
			{
				Id = 0,
				Name = "Titanic"
			};

			var customers = new List<Customer>
			{
				new Customer{Name="Customer 1"},
				new Customer{Name="Customer 2"}
			};

			//var viewModel = new RandomMovieViewModel()
			//{
			//	Customers = customers,
			//	Movie = movie
			//};
			List<Movie> loginDetails = new List<Movie>() {new Movie{Name = "Titanic1"},
				new Movie{Name = "Titanic2"}, };

			var moviePrct = new List<Movie>
			{
				new Movie{Name = "Titanic1"},
				new Movie{Name = "Titanic2"},
			};
			var movies = GetMovies();
			return View(moviePrct);
		}
		#endregion

	}
}