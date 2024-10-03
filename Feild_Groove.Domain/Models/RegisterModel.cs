using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feild_Groove.Domain.Models
{
    public class RegisterModel
    {
		[Key]
		public int Id { get; set; }

		[Display(Name ="First Name*")]
        public string? FirstName { get; set; }

		[Display(Name = "Last Name*")]
		public string? LastName { get; set; }

		[Display(Name = "Company Name*")]
		public string? CompanyName { get; set; }

		[Display(Name = "Phone*")]
		public long Phone { get; set; }

		[Display(Name = "Email*")]
		public string? Email { get; set; }

		[Display(Name = "Password*")]
		public string? Password { get; set; }

		[Display(Name = "Password Again*")]
		public string? PasswordAgain { get; set; }

		[Display(Name = "Time Zone*")]
		public string? TimeZone { get; set; }

		[Display(Name = "Street Address 1*")]
		public string? StreetAddress1 { get; set; }

		[Display(Name = "Street Address 2")]
		public string? StreetAddress2 { get; set; }

		[Display(Name = "City*")]
		public string? City { get; set; }

		[Display(Name = "State*")]
		public string? State { get; set; }

		[Display(Name = "Zip*")]
		public string? Zip { get; set; }
		

	}
}
