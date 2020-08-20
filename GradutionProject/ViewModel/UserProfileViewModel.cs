using GradutionProject.Areas.Identity.Data;
using GradutionProject.Data;
using GradutionProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GradutionProject.ViewModel
{
    public class UserProfileViewModel
    {
        public ApplicationUser  _user { get; set; }
        public List<Post> _Posts { get; set; }
    }
}
