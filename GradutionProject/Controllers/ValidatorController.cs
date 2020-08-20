using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GradutionProject.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GradutionProject.Models;
using System.Collections.Immutable;
using GradutionProject.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MVC_Facebook.Controllers
{
    public class InputModel
    {
        [Required]
        [Remote(action: "IsEmailInUse", controller: "Validator", ErrorMessage = "This Email Is Available")]
        [RegularExpression(@"^[a-zA-Z][a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.(com)$", ErrorMessage = "Invalid Email format")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [MaxLength(15)]
        [Display(Name = "First Name")]
        public string Fname { get; set; }
        [Required]
        [MaxLength(15)]
        [Display(Name = "Last Name")]
        public string Lname { get; set; }

        //[Required]
        //[Display(Name = "User Name")]
        //public string UserName { get; set; }
        [Required]
        [Phone]
        //[Remote(action: "CheckUserPhoneNumber", controller: "Validator", ErrorMessage = "This Phone Number Is Available")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ValidatorController : Controller
    {
        private readonly ApplicationDbContext _context;
        private Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> _userManager;
        private Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> _roleManager;
        [BindProperty]
        public InputModel Input { get; set; }

        public ValidatorController(ApplicationDbContext context,
            Microsoft.AspNetCore.Identity.UserManager<GradutionProject.Areas.Identity.Data.ApplicationUser> userManager,
            Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        //[AcceptVerbs("GET", "POST")]
        //public ActionResult CheckUserPhoneNumber(string PhoneNumber, string id)
        //{
            
        //    ApplicationUser userId =_context.Users.FirstOrDefault(a => a.PhoneNumber == PhoneNumber);
        //    if (userId == null || userId.Id == id)
        //    {
        //        return Json(true);
        //    }
        //    return Json($"This Number {PhoneNumber} is already in use.");
        //}
        [AcceptVerbs("GET", "POST")]
        public async Task <IActionResult> IsEmailInUse(InputModel Input)
        {
            var data = Input.Email;
            var user = await _userManager.FindByEmailAsync(Input.Email);
            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"This Email is already in use.");
            }
        }
        [AcceptVerbs("GET", "POST")]
        public IActionResult IsFirstNameInUse(InputModel Input)
        {
            var data = Input.Fname;
            var user = _context.Users.FirstOrDefault(e => e.Fname == Input.Fname);
            //var user = await _userManager.FindByEmailAsync(Input.Email);
            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"This Name is already in use.");
            }
        }
        [AcceptVerbs("GET", "POST")]
        public IActionResult IsLastNameInUse(InputModel Input)
        {
            var data = Input.Lname;
            var user = _context.Users.FirstOrDefault(e => e.Lname == Input.Lname);
            //var user = await _userManager.FindByEmailAsync(Input.Email);
            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"This Name is already in use.");
            }
        }
        [AcceptVerbs("GET", "POST")]
        public IActionResult IsPhoneNumberInUse(InputModel Input)
        {
            var data = Input.PhoneNumber;
            var user = _context.Users.FirstOrDefault(e => e.PhoneNumber == Input.PhoneNumber);
            //var user = await _userManager.FindByEmailAsync(Input.Email);
            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"This Phone Number is already in use.");
            }
        }
    }
}