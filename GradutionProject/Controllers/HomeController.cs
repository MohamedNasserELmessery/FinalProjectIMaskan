using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GradutionProject.Models;
using GradutionProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace GradutionProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly RoleManager<IdentityRole> _roleManger;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context,RoleManager<IdentityRole> roleManager)
        {
            _roleManger = roleManager;
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
           
            //var applicationDbContext = _context.Regions.Include(r => r.City).Include(a => a.Image);
            HomeViewModel model = new HomeViewModel() { Regions = _context.Regions.Include(r => r.City).Include(a => a.Image).ToList() };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Posts()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Regionshow()
        {
            return View();
        }
        


    }
}
