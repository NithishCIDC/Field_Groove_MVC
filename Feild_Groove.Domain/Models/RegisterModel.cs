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
		[Display(Name ="First Name")]
        public string? FirstName { get; set; }

		[Display(Name = "Last Name")]
		public string? LastName { get; set; }

		[Display(Name = "Company Name")]
		public string? CompanyName { get; set; }

		[Display(Name = "Phone")]
		public string? Phone { get; set; }

		[Display(Name = "Email")]
		public string? Email { get; set; }

		[Display(Name = "Password")]
		public string? Password { get; set; }

		[Display(Name = "Password Again")]
		public string? PasswordAgain { get; set; }

		[Display(Name = "Time Zone")]
		public string? TimeZone { get; set; }
	}
}
