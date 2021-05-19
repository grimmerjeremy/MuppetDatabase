using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muppets.Models
{
    public class MovieDetail
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public DateTime DateReleased { get; set; }
        public string MovieImage { get; set; }

        public List<string> MuppetsInMovie { get; set; } = new List<string>();
        public List<string> PerformersInMovie { get; set; } = new List<string>();
    }
}
