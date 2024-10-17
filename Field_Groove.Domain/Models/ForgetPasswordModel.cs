using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Field_Groove.Domain.Models
{
    public class ForgetPasswordModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
    }
}
