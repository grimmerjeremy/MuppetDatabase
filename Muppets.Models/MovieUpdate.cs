using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muppets.Models
{
    public class MovieUpdate
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public DateTime DateReleased { get; set; }
        public string MovieImage { get; set; }


    }
}
