using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;
using System.ComponentModel.DataAnnotations;

namespace Vidly.ViewModels
{
	public class CustomerFormViewModel
	{
		public Customer customerProp { get; set; }
		public IEnumerable<MembershipType> membershipTypeProp { get; set; }
		public string Title
		{
			get
			{
				if (customerProp != null && customerProp.Id != 0)
					return "Edit Customer";
				return "New Customer";
			}
		}
	}
}