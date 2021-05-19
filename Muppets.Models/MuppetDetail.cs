using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muppets.Models
{
    public class MuppetDetail
    {
        [Display(Name = "Muppet Identification Number:")]
        public int MuppetId { get; set; }
        [Display(Name = "Muppet's Name:")]
        public string MuppetName { get; set; }
        [Display(Name = "Muppet's Species:")]
        public string Origin { get; set; }
        [Display(Name = "First appearance date:")]
        public DateTime MuppetBirthdate { get; set; }
        [Display(Name = "Identification Number for the Muppet's Performer:")]
        public int PerformerId { get; set; }
        [Display(Name = "Name for the Muppet's Performer:")]
        public string PerformerName { get; set; }
        [Display(Name = "Movies this muppet has appeared in:")]
        public List<string> MoviesAppearedIn { get; set; } = new List<string>();
        [Display(Name = "Image of this muppet")]
        public string Image { get; set; }
    }
}
