using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muppets.Models
{
    public class MuppetUpdate
    {
        public int MuppetId { get; set; }
        public string MuppetName { get; set; }
        public string Origin { get; set; }
        public int PerformerId { get; set; }
        public string PerformerName { get; set; }
        [Display(Name = "Date first appeared-")]
        public DateTime MuppetBirthdate { get; set; }
    }
}
