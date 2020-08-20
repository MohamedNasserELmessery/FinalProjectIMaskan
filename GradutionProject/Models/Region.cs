using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GradutionProject.Models
{
    public class Region
    {
        [Key]
        public int RegionId { get; set; }
        [Display(Name ="Region")]
        [Required]
        public string RegionName { get; set; }
        //[ForeignKey("City")]
        public int? CityId { get; set; }
        public City City { get; set; }
        public Images Image { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
