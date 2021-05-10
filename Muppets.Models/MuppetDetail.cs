using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muppets.Models
{
    public class MuppetDetail
    {
        public int MuppetId { get; set; }
        public string MuppetName { get; set; }
        public string Origin { get; set; }
        public DateTime MuppetBirthdate { get; set; }
        public string PerformerName { get; set; }
        public List<string> MoviesAppearedIn { get; set; } = new List<string>();

    }
}
