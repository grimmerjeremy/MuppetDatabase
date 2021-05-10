using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muppets.Models
{
    public class PerformerDetail
    {
        public int PerformerId { get; set; }
        public string PerformerName { get; set; }
        public DateTime PerformerBirthdate { get; set; }
        public List<string> MuppetsPerformedByPerformer { get; set; } = new List<string>();
        public List<string> MoviesPerformedIn { get; set; } = new List<string>();
    }
}
