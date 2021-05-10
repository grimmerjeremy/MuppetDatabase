using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muppets.Models
{
    public class PerformerUpdate
    {
        public int PerformerId { get; set; }
        public string PerformerName { get; set; }
        public DateTime PerformerBirthdate { get; set; }
    }
}
