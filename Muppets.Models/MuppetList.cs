using Muppets.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muppets.Models
{
    public class MuppetList
    {
        public int MuppetId { get; set; }
        public string MuppetName { get; set; }
        public string Origin { get; set; }
        public DateTime MuppetBirthdate { get; set; }
        public Performer PerformerName { get; set; }
    }
}
