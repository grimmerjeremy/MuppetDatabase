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
        [Display(Name = "Muppet Identification Number:")]
        public int MuppetId { get; set; }
        [Display(Name = "Muppet's Name:")]
        public string MuppetName { get; set; }
        [Display(Name = "First appearance date:")]
        public DateTime MuppetBirthdate { get; set; }
    }
}
