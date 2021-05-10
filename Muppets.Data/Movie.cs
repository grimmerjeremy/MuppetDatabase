using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muppets.Data
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        [Required]
        public string MovieName { get; set; }
        [Required]
        public DateTime DateReleased { get; set; }

        public List<Muppet> MuppetsInMovie { get; set; }
        public List<Performer> PerformersInMovie { get; set; }
    }
}
