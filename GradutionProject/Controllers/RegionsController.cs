using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GradutionProject.Data;
using GradutionProject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.Extensions.Hosting;
using X.PagedList;
using Microsoft.AspNetCore.Authorization;

namespace GradutionProject.Controllers
{
    [Authorize(Roles = "Admin,Manager")]

    public class RegionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public RegionsController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Regions
        public async Task<IActionResult> Index(int? page)
        {
            var PageNumber = page ?? 1;
            int pageSize = 2;
            var applicationDbContext = _context.Regions.Include(r => r.City).Include(a => a.Image).ToPagedList(PageNumber, pageSize);
            ViewBag.page = _context.Regions.Include(r => r.City).Include(a => a.Image).ToPagedList(PageNumber, pageSize);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Regions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var region = await _context.Regions
                .Include(r => r.City).Include(a => a.Image)
                .FirstOrDefaultAsync(m => m.RegionId == id);
            if (region == null)
            {
                return NotFound();
            }

            return View(region);
        }

        //GET: Regions/Create
        public IActionResult Create()


        {
            ViewData["CityId"] = new SelectList(_context.Cities, "City_id", "City_name");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RegionId,RegionName,CityId")] Region region, IFormFile imgpath, int id = 0)
        {

            string folderpath = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            string filename = Guid.NewGuid().ToString() + "." + imgpath.FileName.Split('.')[1];
            string filepath = Path.Combine(folderpath, filename);

            if (System.IO.File.Exists(filepath))
            {
                var ext = "";
                filename = filename + "new" + ext;
                filepath = Path.Combine(folderpath, filename);

            }
            imgpath.CopyTo(new FileStream(filepath, FileMode.Create));

            if (ModelState.IsValid)
            {
                _context.Add(region);
                await _context.SaveChangesAsync();
                var image = new Images() { ImgPath = filename, RegionId = region.RegionId };
                _context.Add(image);
                await _context.SaveChangesAsync();

                var Alldata = _context.Regions.Include(r => r.City).Include(a => a.Image).ToList();
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "ViewAllRegion", Alldata, _context)});
            }

            ViewData["CityId"] = new SelectList(_context.Cities, "City_id", "City_name", region.CityId);
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Create", region) });
        }

        // GET: Regions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //var post = await _context.Posts.Include(p => p.Category).Include(p => p.City).Include(p => p.Region).Include(p => p.Images).SingleAsync(e => e.Post_Id == id);

            //var region = await _context.Regions.FindAsync(id);
            var region = await _context.Regions.Include(a => a.City).Include(a => a.Image).SingleAsync(a => a.RegionId == id);
            ViewBag.img = _context.Images.SingleOrDefault(a => a.RegionId == region.RegionId);
            if (region == null)
            {
                return NotFound();
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "City_id", "City_name", region.CityId);
            return View(region);
        }

        // POST: Regions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RegionId,RegionName,CityId")] Region region, IFormFile imgpath)
        {
            //var filename = "";
            var Alldata = _context.Regions.Include(r => r.City).Include(a => a.Image).ToList();
            var reg = _context.Regions/*.AsNoTracking()*/.Include(a => a.City).Include(a => a.Image).Single(e => e.RegionId == id);
            var img = _context.Images.SingleOrDefault(a => a.RegionId == reg.RegionId);
            //img.ImgId = 1;
            if (imgpath != null)
            {
                System.IO.File.Delete(img.ImgPath);
                _context.Images.Remove(img);
                _context.SaveChanges();
                string folderpath = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                string filename = Guid.NewGuid().ToString() + "." + imgpath.FileName.Split('.')[1];
                string filepath = Path.Combine(folderpath, filename);
                if (System.IO.File.Exists(filepath))
                {
                    var ext = "";
                    filename = filename + "new" + ext;
                    filepath = Path.Combine(folderpath, filename);

                }
                imgpath.CopyTo(new FileStream(filepath, FileMode.Create));
                var image = new Images() { ImgPath = filename, RegionId = region.RegionId };
                _context.Add(image);
                await _context.SaveChangesAsync();
            }
            if (id != region.RegionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    _context.Entry(reg).CurrentValues.SetValues(region);
                    await _context.SaveChangesAsync();


                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegionExists(region.RegionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "ViewAllRegion", Alldata, _context) });
            }
            ViewData["CityId"] = new SelectList(_context.Cities, "City_id", "City_name", region.CityId);
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "Edit", region) });
        }


        public async Task<IActionResult> Delete(int id)
        {
            var reg = _context.Regions.AsNoTracking().FirstOrDefault(e => e.RegionId == id);
            var img = _context.Images.SingleOrDefault(a => a.RegionId == reg.RegionId);
            System.IO.File.Delete(img.ImgPath);
            _context.Images.Remove(img);
            _context.Regions.Remove(reg);
            await _context.SaveChangesAsync();
            var Alldata = _context.Regions.Include(r => r.City).Include(a => a.Image).ToList();
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "ViewAllRegion", Alldata, _context) });
        }

        private bool RegionExists(int id)
        {
            return _context.Regions.Any(e => e.RegionId == id);
        }
    }
}
