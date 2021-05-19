using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muppets.Models
{
    public class MovieCreate
    {
        [Required]
        public string MovieName { get; set; }
        [Required]
        public DateTime DateReleased { get; set; }
        public string MovieImage { get; set; }

    }
}
