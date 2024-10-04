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

		[Display(Name ="First Name*")]
		[Required(ErrorMessage ="First Name is Required")]
        public string? FirstName { get; set; }

		[Display(Name = "Last Name*")]
		[Required(ErrorMessage = "Last Name is Required")]
		public string? LastName { get; set; }

		[Display(Name = "Company Name*")]
		[Required(ErrorMessage = "Company Name is Required")]
		public string? CompanyName { get; set; }

		[Display(Name = "Phone*")]
		[Required(ErrorMessage = "Phone Number is Required")]
		[Range(1000000000,9999999999,ErrorMessage ="Phone Number is Not valid")]
		public long Phone { get; set; }

		[Key]
		[Display(Name = "Email*")]
		[Required(ErrorMessage = "Email is Required")]
		[EmailAddress(ErrorMessage ="Inalid Email Address")]
		public string? Email { get; set; }

		[Display(Name = "Password*")]
		[Required(ErrorMessage = "Password is Required")]
		[MinLength(8,ErrorMessage ="Password should be Atleast 8 Characters")]
		public string? Password { get; set; }

		[Display(Name = "Password Again*")]
		[Required(ErrorMessage = "Password Again is Required")]
		[Compare("Password",ErrorMessage ="Password Again does not Matches with Password")]
		public string? PasswordAgain { get; set; }

		[Display(Name = "Time Zone*")]
		[Required(ErrorMessage = "Time Zone is Required")]
		public string? TimeZone { get; set; }

		[Display(Name = "Street Address 1*")]
		[Required(ErrorMessage = "Street Address 1 is Required")]
		public string? StreetAddress1 { get; set; }

		[Display(Name = "Street Address 2*")]
		[Required(ErrorMessage = "Street Address 2 is Required")]
		public string? StreetAddress2 { get; set; }

		[Display(Name = "City*")]
		[Required(ErrorMessage = "City is Required")]
		public string? City { get; set; }

		[Display(Name = "State*")]
		[Required(ErrorMessage = "State is Required")]
		public string? State { get; set; }

		[Display(Name = "Zip*")]
		[Required(ErrorMessage = "Zip is Required")]
		public string? Zip { get; set; }
	}
}
