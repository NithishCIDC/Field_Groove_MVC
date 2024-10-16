using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Field_Groove.Domain.Models
{
    public class LeadsModel
    {
        [Key]
        public int? Id { get; set; }
        public string? Name { get; set; }

        public string? Status { get; set; }

        public DateTime? Added { get; set; } = DateTime.Now;

        public string? Type { get; set; }

        public long? Contact {  get; set; }

        public string? Action { get; set; }

        public string? Assignee { get; set; }

        public DateTime? BidDate { get; set; } 
    }
}
