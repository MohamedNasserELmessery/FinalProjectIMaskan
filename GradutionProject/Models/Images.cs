using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using GradutionProject.Areas.Identity.Data;

namespace GradutionProject.Models
{
    public class Images
    {
        [Key]
        public int ImgId { get; set; }
        public string ImgPath { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        //[ForeignKey("Posts")]
        public int? PostId { get; set; }
        //[ForeignKey("Region")]
        public int? RegionId { get; set; }
        public Region Region { get; set; }
        public Post Posts { get; set; }
        public ApplicationUser User { get; set; }
    }
}
