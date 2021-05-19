using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muppets.Models
{
    public class MovieUpdate
    {
        [Display(Name = "Identification Number of Movie/Show:")]
        public int MovieId { get; set; }
        [Display(Name = "Name of Movie/Show:")]
        public string MovieName { get; set; }
        [Display(Name = "Original release/air date:")]
        public DateTime DateReleased { get; set; }
        [Display(Name = "Copy a link to an image for the Movie/Show")]
        public string MovieImage { get; set; }


    }
}
