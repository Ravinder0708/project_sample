using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Vidly.Models
{
	public class Movie
	{
		public int Id { get; set; }

		[Required]
		[StringLength(255)]
		public string Name { get; set; }

		[Required]
		[Display(Name = "Release Date")]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime? ReleaseDate { get; set; }

		[Required]
		[Display(Name = "Date Added")]
		public DateTime? DateAdded { get; set; }

		[Required]
		[Display(Name = "Number In Stock")]
		[Range(1,20)]
		public int NumberInStock { get; set; }

		public Genre genre { get; set; }

		[Display(Name ="Genre")]
		[Required]
		public int GenreId { get; set; }

		public byte NumberAvailable { get; set; }
	}

}