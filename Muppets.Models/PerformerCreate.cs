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
        [Display(Name = "Enter a new Performer!")]
        public string PerformerName { get; set; }
        [Required]
        [Display(Name ="Enter the Performer's Birthdate.")]
        public DateTime PerformerBirthdate { get; set; }
        [Display(Name ="Copy an URL to the image of the performer.")]
        public string PerformerImage { get; set; }
    }
}
