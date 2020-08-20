using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GradutionProject.Data;
using GradutionProject.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GradutionProject.Controllers
{
    public class RolesController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;
        public RolesController(RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            _roleManager = roleManager;
            _context = context;
        }
        public IActionResult Index()
        {
            CreateRoleViewModel role = new CreateRoleViewModel() {
                IdentityRole = _context.Roles.ToList()
            };
            return View(role);
        }
        
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel role)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name=role.RoleName
                };
                IdentityResult result = await _roleManager.CreateAsync(identityRole);
                if (result.Succeeded)
                {
                    var Alldata = _context.Roles.ToList();
                    var data = new  CreateRoleViewModel() { IdentityRole = Alldata };
                    return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "ViewAllRole", data) });
                    //return RedirectToAction(nameof(Index));
                }
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "CreateRole", role) });

           // return View(role);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var city = await _context.Roles.FindAsync(id);
            _context.Roles.Remove(city);
            await _context.SaveChangesAsync();
            var Alldata = _context.Roles.ToList();
            var data = new CreateRoleViewModel() { IdentityRole = Alldata };
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "ViewAllRole", data) });
        }



        //public async Task<IActionResult> Delete(string id)
        //{
        //    var role = await _context.Roles.FindAsync(id);
        //    _context.Roles.Remove(role);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

    }
}