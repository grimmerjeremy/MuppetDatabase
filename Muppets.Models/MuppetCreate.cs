using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muppets.Models
{
    public class MuppetCreate
    {
        [Required]
        public string MuppetName { get; set; }
        public string Origin { get; set; }
        public int PerformerId { get; set; }
        [Required]
        [Display(Name = "Date first appeared-")]
        public DateTime MuppetBirthdate { get; set; }

    }
}
