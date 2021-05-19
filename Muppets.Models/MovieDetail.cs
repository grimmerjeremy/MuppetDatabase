using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muppets.Models
{
    public class MovieDetail
    {
        [Display(Name = "Identification Number of Movie/Show:")]
        public int MovieId { get; set; }
        [Display(Name = "Name of Movie/Show:")]
        public string MovieName { get; set; }
        [Display(Name = "Original release/air date:")]
        public DateTime DateReleased { get; set; }
        [Display(Name = "Image for the Movie/Show")]
        public string MovieImage { get; set; }

        [Display(Name = "Muppets that appear in this movie/Show:")]
        public List<string> MuppetsInMovie { get; set; } = new List<string>();
        [Display(Name = "Performers that appeared in this movie/Show:")]
        public List<string> PerformersInMovie { get; set; } = new List<string>();
    }
}
