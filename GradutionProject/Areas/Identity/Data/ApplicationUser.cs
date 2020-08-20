using GradutionProject.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GradutionProject.Areas.Identity.Data
{
    public class ApplicationUser:IdentityUser
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public ICollection<Post> UserPosts { get; set; }
        public ICollection<Comments> Comments { get; set; }
        public Images Image { get; set; }
        //public Like Like { get; set; }
    }
}
