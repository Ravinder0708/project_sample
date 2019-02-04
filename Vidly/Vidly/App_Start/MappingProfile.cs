using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly.Models;
using Vidly.DTOs;


namespace Vidly.App_Start
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<CustomerDto, Customer>();
			CreateMap<Customer, CustomerDto>();

			CreateMap<MovieDto, Movie>();
			CreateMap<Movie, MovieDto>();
		}
	}
}