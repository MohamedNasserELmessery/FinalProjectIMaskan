using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GradutionProject.Data;
using GradutionProject.Models;
using X.PagedList;
using Microsoft.AspNetCore.Authorization;

namespace GradutionProject.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    public class CitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cities
        public async Task<IActionResult> Index(int? page)
        {
            var PageNumber = page ?? 1;
            int pageSize = 2;
            var applicationDbContext = _context.Cities.ToPagedList(PageNumber, pageSize);
            ViewBag.page = _context.Cities.ToPagedList(PageNumber, pageSize);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Cities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _context.Cities
                .FirstOrDefaultAsync(m => m.City_id == id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // GET: Cities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("City_id,City_name")] City city)
        {

            if (ModelState.IsValid)
            {
                _context.Add(city);
                await _context.SaveChangesAsync();
                var Alldata = _context.Cities.ToList();
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "ViewAllCities", Alldata, _context) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Create", city) });
        }

        // GET: Cities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var city = await _context.Cities.FindAsync(id);
            if (city == null)
            {
                return NotFound();
            }
            return View(city);
        }

        // POST: Cities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("City_id,City_name")] City city)
        {
            var Alldata = _context.Cities.ToList();
            var cit = _context.Cities.FirstOrDefault(e => e.City_id == id);
            if (id != city.City_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Entry(cit).CurrentValues.SetValues(city);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CityExists(city.City_id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "ViewAllCities", Alldata, _context) });
            }

            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "Edit", city) });
        }


        public async Task<IActionResult> Delete(int id)
        {
            var city = await _context.Cities.FindAsync(id);
            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();
            var Alldata = _context.Cities.ToList();
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "ViewAllCities", Alldata, _context) });
        }

        private bool CityExists(int id)
        {
            return _context.Cities.Any(e => e.City_id == id);
        }
    }
}
