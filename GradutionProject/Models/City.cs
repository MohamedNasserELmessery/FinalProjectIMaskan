using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GradutionProject.Models
{
    public class City
    {
        [Key]
        public int City_id { get; set; }
        [Display(Name ="City")]
        [Required]
        public string City_name { get; set; }
        public ICollection<Region> Regions { get; set; }
        
    }
}
