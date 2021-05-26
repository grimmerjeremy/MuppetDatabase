using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muppets.Models
{
    public class MuppetUpdate
    {
        [Display(Name = "Muppet Identification Number:")]
        public int MuppetId { get; set; }
        [Display(Name = "Muppet's Name:")]
        public string MuppetName { get; set; }
        [Display(Name = "Muppet's Species:")]
        public string Origin { get; set; }
        [Display(Name = "Select the Muppet's Performer:")]
        public int PerformerId { get; set; }
        [Display(Name = "First appearance date:")]
        public DateTime MuppetBirthdate { get; set; }
        [Display(Name = "Image URL:")]
        public string Image { get; set; }
    }
}
