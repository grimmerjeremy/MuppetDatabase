using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muppets.Data
{
    public class Performer
    {
        [Key]
        public int PerformerId { get; set; }
        [Required]
        public string PerformerName { get; set; }
        [Required]
        public DateTime PerformerBirthDate { get; set; }
        
        public List<Muppet> MuppetsPerformed { get; set; }
        public List<Movie> MoviesPerformedIn { get; set; }
    }
}
