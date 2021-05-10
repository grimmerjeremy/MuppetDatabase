using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muppets.Models
{
    public class PerformerCreate
    {
        [Required]
        public string PerformerName { get; set; }
        [Required]
        public DateTime PerformerBirthdate { get; set; }
    }
}
