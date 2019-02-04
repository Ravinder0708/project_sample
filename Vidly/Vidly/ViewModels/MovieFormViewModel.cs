using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
	public class MovieFormViewModel
	{
		public IEnumerable<Genre> genreProp { get; set; }
		public Movie movieProp { get; set; }
		public string Title
		 {
			 get
			 {
				 if (movieProp != null && movieProp.Id != 0)
					 return "Edit Movie";
 
				  return "New Movie";
			 }
		 }
	}
}