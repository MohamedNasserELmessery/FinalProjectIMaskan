using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using GradutionProject.Areas.Identity.Data;

namespace GradutionProject.Models
{
    public class Comments
    {
        [Key]
        public int CommentId { get; set; }
        [Required(ErrorMessage ="You can't leave this field empty")]
        [DataType(DataType.MultilineText)]
        public string CommentBody { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime CommentDate { get; set; }
        public string UserId { get; set; }
        [ForeignKey("Posts")]
        public int? PostId { get; set; }
        public Post Posts { get; set; }
        public ApplicationUser User { get; set; }


    }
}
