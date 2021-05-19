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
        [Display(Name = "Enter that Muppet's Name")]
        public string MuppetName { get; set; }
        [Display(Name = "What is the species of this muppet?")]
        public string Origin { get; set; }
        [Required]
        [Display(Name = "When did this muppet make its first appearance?")]
        public DateTime MuppetBirthdate { get; set; }
        [Display(Name = "Select a performer for this muppet.")]
        public int PerformerId { get; set; }
        [Display(Name = "Copy an image URL for this muppet here.")]
        public string Image { get; set; }
    }
}
