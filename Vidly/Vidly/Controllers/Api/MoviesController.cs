using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
	public class MoviesController : ApiController
	{
		private ApplicationDbContext _dbContext;

		public MoviesController()
		{
			_dbContext = new ApplicationDbContext();
		}

		protected override void Dispose(bool disposing)
		{
			_dbContext.Dispose();
		}

		public IEnumerable<MovieDto> GetMovies(string query = null)
		{
			var moviesQuery = _dbContext.Movies.Include(m => m.genre).Where(m => m.NumberAvailable > 0);

			if (!String.IsNullOrWhiteSpace(query))
				moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));

			return moviesQuery.ToList().Select(Mapper.Map<Movie, MovieDto>);
		}

		/// <summary>
		/// Get all movies
		/// </summary>
		/// <param name="modelMovie"></param>
		/// <returns></returns>
		//[HttpGet]
		//public IHttpActionResult GetAllMovies()
		//{
		//	var movieList = _dbContext.Movies.Include(g => g.genre).ToList().Select(Mapper.Map<Movie, MovieDto>);
		//	return Ok(movieList);
		//}

		/// <summary>
		/// Get particular movie from ID
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet]
		public IHttpActionResult GetMovie(int id)
		{
			var movieList = _dbContext.Movies.Include(g => g.genre).SingleOrDefault(i => i.Id == id);
			if (movieList != null)
			{
				var movieDtO = Mapper.Map<Movie, MovieDto>(movieList);
				return Ok(movieDtO);
			}
			else
			{
				return NotFound();
			}
			
		}

		/// <summary>
		/// Add new movie to DB
		/// </summary>
		/// <param name="modelMovie"></param>
		/// <returns></returns>
		[HttpPost]
		public IHttpActionResult CreateMovie(MovieDto modelMovie)
		{
			if (ModelState.IsValid)
			{
				var moviesObj = Mapper.Map<MovieDto, Movie>(modelMovie);
				_dbContext.Movies.Add(moviesObj);
				_dbContext.SaveChanges();
				return Ok();
			}
			return BadRequest();
		}

		/// <summary>
		/// Update Movie
		/// </summary>
		/// <param name="modelMovie"></param>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpPost]
		public IHttpActionResult UpdateMovie(MovieDto modelMovie,int id)
		{
			if (ModelState.IsValid)
			{
				var movieInDb = _dbContext.Movies.SingleOrDefault(i => i.Id == id);
				if (movieInDb != null)
				{
					//IDE0001 C# Name can be simplified.
					//Mapper.Map<MovieDto, Movie>(modelMovie,movieInDb);
					Mapper.Map(modelMovie, movieInDb);
					_dbContext.SaveChanges();
					return Ok();
				}
				else
				{
					return NotFound();
				}
				
			}
			else
			{
				return BadRequest();
			}
		}

		/// <summary>
		/// Delete movie from DB
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpDelete]
		public IHttpActionResult DeleteMovie(int id)
		{
			var movieInDb = _dbContext.Movies.SingleOrDefault(i => i.Id == id);
			if (movieInDb != null)
			{
				_dbContext.Movies.Remove(movieInDb);
				_dbContext.SaveChanges();
				return Ok();
			}
			else
			{
				return BadRequest();
			}

		}
	}
}
