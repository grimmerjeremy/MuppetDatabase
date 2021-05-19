using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muppets.Models
{
    public class PerformerUpdate
    {
        [Display(Name ="Performer Identification Number:")]
        public int PerformerId { get; set; }
        [Display(Name = "Performer's Name:")]
        public string PerformerName { get; set; }
        [Display(Name = "Performer's Birthdate:")]
        public DateTime PerformerBirthdate { get; set; }
        [Display(Name = "Image of this performer.")]
        public string PerformerImage { get; set; }
    }
}
