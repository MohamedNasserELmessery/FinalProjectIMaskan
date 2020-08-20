using GradutionProject.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GradutionProject.Models
{
    public class Like
    {
        [Key]
        public int LikeId { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime LikeDate { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        [ForeignKey("Posts")]
        public int? PostId { get; set; }
        public Post Posts { get; set; }
        public ApplicationUser User { get; set; }



    }

}
