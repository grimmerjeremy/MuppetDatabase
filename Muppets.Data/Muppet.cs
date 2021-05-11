using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muppets.Data
{
    public class Muppet
    {
        [Key]
        public int MuppetId { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "This name is too long.")]
        public string MuppetName { get; set; }
        public string Origin { get; set; }


        [ForeignKey(nameof(PerformerName))]
        public int PerformerId { get; set; }
        public Performer PerformerName { get; set; }


        [ForeignKey(nameof(MovieName))]
        public int MovieId { get; set; }
        public Movie MovieName { get; set; }

        [Required]
        [Display(Name = "Date first appeared-")]
        public DateTime MuppetBirthdate { get; set; }

        public List<Movie> MoviesAppearedIn { get; set; }
    }
}
