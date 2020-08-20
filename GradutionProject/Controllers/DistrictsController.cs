using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GradutionProject.Data;
using GradutionProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace GradutionProject.Controllers
{
    public class DistrictsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DistrictsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? id)
        {
            ViewBag.DistrictId = id ?? 0;
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", 1);
            ViewData["RegionId"] = new SelectList(_context.Regions, "RegionId", "RegionName", 1);
            return View();
        }

        [HttpPost]
        public JsonResult LoadPosts([FromBody] FilterViewModel filter)
        {
            try
            {
                var model = _context.Posts.Include(p => p.Images).Where(e => 
                (filter.DistrictId == 0 || e.RegionId == filter.DistrictId ) &&
                (filter.CatagoryId == 0 || e.CategoryId == filter.CatagoryId) &&
                (filter.MinimumPrice == 0 || e.Price >= filter.MinimumPrice) &&
                (filter.MaximumPrice == 0 || e.Price <= filter.MaximumPrice)&&
                (filter.FinishingState==0 || e.FinishingState==filter.FinishingState)&&
                (filter.FurnitureState==0 || e.FurnitureState==filter.FurnitureState)
                ).Skip((filter.Page - 1) * 10).Take(10).ToList();
                //var data = JsonConvert.SerializeObject(model, Formatting.None,
                //        new JsonSerializerSettings()
                //        {
                //            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                //        });
                return Json(model);
            }
            catch (Exception e)
            {
                return Json(null);
            }
        }

        public JsonResult LoadPagesCount()
        {
            try
            {
                var model = _context.Posts.ToList();
                var data = model.ToList();
                var pagePosts = 10;
                var pagesCount = (data.Count / pagePosts) + ((data.Count % pagePosts) > 0 ? 1 : 0);
                return Json(pagesCount);
            }
            catch (Exception e)
            {
                return Json(null);
            }
        }
    }

}