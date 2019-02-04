using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.DTOs
{
	public class CustomerDto
	{
		public int Id { get; set; }

		[Required]
		[StringLength(255, ErrorMessage = "Name cannot be more than 255 characters.")]
		public string Name { get; set; }

		[Display(Name = "Subscribed To Newsletter")]
		public bool IsSubscribedToNewsletter { get; set; }

		// Navigation property
		public MembershipTypeDto MembershipType { get; set; }

		// Foreign Key
		public byte MembershipTypeId { get; set; }

		[Display(Name = "Date of Birth")]
		public DateTime? BirthDate { get; set; }
	}
}