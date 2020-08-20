using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GradutionProject.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GradutionProject.Models;
using System.Collections.Immutable;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using GradutionProject.Areas.Identity.Data;
using GradutionProject.ViewModel;
using System.Security.Claims;

namespace GradutionProject.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> _userManager;
        private Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> _roleManager;

        public AdminController(ApplicationDbContext context,
            Microsoft.AspNetCore.Identity.UserManager<GradutionProject.Areas.Identity.Data.ApplicationUser> userManager,
            Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager=userManager;
            _roleManager = roleManager;
        }

        // GET: Posts
        public IActionResult Index()
        {
            var uNum= _context.Users.Count();
            var pNum= _context.Posts.Count();
            var rNum = _context.Regions.Count();
            var cNum = _context.Cities.Count();
            ViewData["RegionNumber"] = rNum;
            ViewData["PostsNumber"] = pNum;
            ViewData["UsersNumber"] = uNum;
            ViewData["CityNumber"] = cNum;

            //var Alldata = _context.Posts.Include(p => p.Category).Include(p => p.City).Include(p => p.Region);
            return View();
        }
        public IActionResult ViewTable()
        {
            var Alldata = _context.Posts.Include(p => p.Category).Include(p => p.City).Include(p => p.Region);
            return View(Alldata.ToList());
        }
        public IActionResult ViewUsers()
        {
            var Alldata = _context.Users.Include(e=>e.Image);
            return View(Alldata.ToList());
        }
        public IActionResult GetAllUsers()
        {
            var loggedUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userRols = _context.UserRoles.ToList();
            var Alldata = _context.Users.Include(e => e.Image).Include(e=>e.UserPosts).Where(e=>e.Id!= loggedUserId).ToList();

            var selectedLst = (from item in Alldata
                              select new { item.Id,item.UserName, item.Email, item.UserPosts.Count, roleName = GetUserRole(item.Id), anotherRole = GetUserSecondRole(item.Id) }).ToList();
            return new JsonResult(selectedLst);
        }
        public string GetUserRole(string userId)
        {
            var userRoleId = _context.UserRoles.FirstOrDefault(e => e.UserId == userId).RoleId;
            if (userRoleId == null)
            {
                userRoleId = "c243698f-92d4-4bfc-9828-a3c69b72670c";
            }
            var roleName = _context.Roles.FirstOrDefault(e => e.Id == userRoleId).Name;
            return roleName;
        }
        public string GetUserSecondRole(string userId)
        {
            var userRoleId = _context.UserRoles.AsEnumerable().LastOrDefault(e => e.UserId == userId);
            var roleName = _context.Roles.FirstOrDefault(e => e.Id == userRoleId.RoleId).Name;
            if (roleName == GetUserRole(userId))
            {
                return "--";
            }
            return roleName;
        }
        public IActionResult GetAllPosts()
        {

            var Alldata = _context.Posts.Include(p => p.Category).Include(p => p.City).Include(p => p.Region).Include(P=>P.Images);
            var selectedLst = from item in Alldata
                              select new { item.Post_Id, item.Post_Title, item.Post_Create_Date, item.Price };
            return new JsonResult(selectedLst);
        }
       
        public IActionResult GetAllRegions()
        {

            var Alldata = _context.Regions.Include(e => e.Image).Include(e=>e.Posts).Include(e=>e.City).ToList();
            //var img = _context.Images.ToList();
            var selectedLst = from item in Alldata
                              select new { item.RegionId, item.RegionName,item.Posts.Count ,item.City.City_name,item.Image.ImgPath};
            return new JsonResult(selectedLst);
        }
        public IActionResult GetAllComments(int id)
        {
            var Alldata = _context.Comments.Where(e=>e.PostId==id).ToList();
            var selectedLst = from item in Alldata
                              select new { item.CommentId,item.CommentBody, item.CommentDate };
            return new JsonResult(selectedLst);
        }
        public IActionResult GetAllMessages()
        {

            var Alldata = _context.Message.OrderByDescending(e=>e.MessageId).ToList();
            var selectedLst = from item in Alldata
                              select new { item.MessageId, item.Message, item.UserName, item.Email };
            return new JsonResult(selectedLst);
        }
        public IActionResult GetAllCategories()
        {

            var Alldata = _context.Categories.Include(e=>e.Posts).ToList();
            var selectedLst = from item in Alldata
                              select new { item.CategoryId, item.CategoryName,item.Posts.Count };
            return new JsonResult(selectedLst);
        }
        public IActionResult GetAllCities()
        {

            var Alldata = _context.Cities.Include(e => e.Regions).ToList();
            var selectedLst = from item in Alldata
                              select new { item.City_id, item.City_name, item.Regions.Count };
            return new JsonResult(selectedLst);
        }
        [HttpGet]
        public async Task<IActionResult> ManageUserRole(string Id)
        {
            ViewBag.userId = Id;
            var user = _context.Users.FirstOrDefault(e => e.Id == Id);
            //var user = await _userManager.FindByIdAsync(Id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id ={Id} can't be found";
                return Content("Error");
            }
            var model = new List<UserRoleViewModel>();
            foreach (var role in _roleManager.Roles)
            {
                var userRole = new UserRoleViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    userRole.IsSelected = true;
                }
                else
                {
                    userRole.IsSelected = false;
                }

                model.Add(userRole);
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ManageUserRoles(List<UserRoleViewModel> model, string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {Id} cannot be found";
                return Content("Error");
            }

            var roles = await _userManager.GetRolesAsync(user);
            var result = await _userManager.RemoveFromRolesAsync(user, roles);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove user existing roles");
                return View(model);
            }

            result = await _userManager.AddToRolesAsync(user,
                model.Where(x => x.IsSelected).Select(y => y.RoleName));

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected roles to user");
                return View(model);
            }

            return RedirectToAction("ViewUsers", new { Id = Id });
        }
        public async Task<IActionResult> DeletePosts(int? id)
        {
            var ImagePost = _context.Images.Where(e => e.PostId == id).ToList();
            _context.Images.RemoveRange(ImagePost);
            await _context.SaveChangesAsync();
            var post = await _context.Posts.FindAsync(id);
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            //var Alldata = _context.Posts.Include(p => p.Category).Include(p => p.City).Include(p => p.Region).Include(P => P.Images).ToList();
            return new JsonResult(true);
        }
        public async Task<IActionResult> DeleteMessage(int? id)
        {
           
            var message = await _context.Message.FindAsync(id);
            _context.Message.Remove(message);
            await _context.SaveChangesAsync();
            //var Alldata = _context.Posts.Include(p => p.Category).Include(p => p.City).Include(p => p.Region).Include(P => P.Images).ToList();
            return new JsonResult(true);
        }
        public async Task<IActionResult> DeleteRegionAndPosts(int? id)
        {
            var _Posts = _context.Posts.Where(e => e.RegionId == id).ToList();
            if (_Posts.Count != 0)
            {
                foreach (var item in _Posts)
                {
                    var imgs = _context.Images.Where(e => e.PostId == item.Post_Id).ToList();
                    if (imgs != null)
                    {
                        foreach (var img in imgs)
                        {
                            var image = _context.Images.FirstOrDefault(e => e.ImgId == img.ImgId);
                            System.IO.File.Delete(image.ImgPath);
                            _context.Images.Remove(image);
                            _context.SaveChanges();
                        }
                    }

                    _context.Posts.Remove(item);
                    _context.SaveChanges();
                }
            }
            var _region =  _context.Regions.Find(id);
            var regionImg = _context.Images.FirstOrDefault(e => e.RegionId == id);
            System.IO.File.Delete(regionImg.ImgPath);
            _context.Images.Remove(regionImg);
            _context.Regions.Remove(_region);
            await _context.SaveChangesAsync();
            return new JsonResult(true);
        }


        public async Task<IActionResult> DeleteRegion(int? id)
        {
            var regionPosts = _context.Posts.Any(e => e.RegionId == id);
            if (regionPosts == false)
            {
                var regionImage = _context.Images.FirstOrDefault(e => e.RegionId == id);
                System.IO.File.Delete(regionImage.ImgPath);
                _context.Images.Remove(regionImage);
                var region = _context.Regions.FirstOrDefault(e => e.RegionId == id);
                _context.Regions.Remove(region);
                await _context.SaveChangesAsync();
                return new JsonResult(true);

            }

            //var ImagePost = _context.Images.Where(e => e.RegionId == id).ToList();
            //_context.Images.RemoveRange(ImagePost);
            //await _context.SaveChangesAsync();

            //var AllPostsRealtedToReagion = _context.Posts.Any(e => e.RegionId == id);

            //_context.Posts.RemoveRange(AllPostsRealtedToReagion);
            //await _context.SaveChangesAsync();

            //var Region = await _context.Regions.FindAsync(id);
            //_context.Regions.Remove(Region);
            //await _context.SaveChangesAsync();
            return new JsonResult(false);
        }
        public IActionResult DeleteRegionPosts(int? id)
        {

            var _Posts = _context.Posts.Where(e => e.RegionId == id).ToList();
            foreach (var item in _Posts)
            {
                var imgs = _context.Images.Where(e => e.PostId == item.Post_Id).ToList();
                if (imgs != null)
                {
                    foreach (var img in imgs)
                    {
                        var image = _context.Images.FirstOrDefault(e => e.ImgId == img.ImgId);
                        System.IO.File.Delete(image.ImgPath);
                        _context.Images.Remove(image);
                        _context.SaveChanges();
                    }
                }

                _context.Posts.Remove(item);
                _context.SaveChanges();
            }
            //var posts = _context.Posts.Where(e => e.RegionId == id).ToList();
            //foreach (var item in posts)
            //{

            //    _context.Posts.Remove(item);
            //    _context.SaveChanges();
            //}
            return new JsonResult(true);
        }
        public async Task<IActionResult> DeleteComment(int? id)
        {
            var _Comment = await _context.Comments.FindAsync(id);
            _context.Comments.Remove(_Comment);
            await _context.SaveChangesAsync();
            return new JsonResult(true);
        }
        public async Task<IActionResult> DeleteCategory(int? id)
        {
            var _Posts = _context.Posts.Where(e => e.CategoryId == id).ToList();
            foreach (var item in _Posts)
            {
                var imgs = _context.Images.Where(e => e.PostId == item.Post_Id).ToList();
                if (imgs != null)
                {
                    foreach (var img in imgs)
                    {
                        var image = _context.Images.FirstOrDefault(e => e.ImgId == img.ImgId);
                        System.IO.File.Delete(image.ImgPath);
                        _context.Images.Remove(image);
                        _context.SaveChanges();
                    }
                }

                _context.Posts.Remove(item);
                _context.SaveChanges();
            }
            //var CategoryPosts = _context.Posts.Where(e => e.CategoryId == id).ToList();//Male
            //foreach (var item in CategoryPosts)
            //{
            //    item.CategoryId = 1;
            //} 
            //await _context.SaveChangesAsync();

            var _category = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(_category);
            await _context.SaveChangesAsync();
            return new JsonResult(true);
        }
        public async Task<IActionResult> DeleteCity(int? id)
        {
            var _Posts = _context.Posts.Where(e => e.CityId == id).ToList();
            foreach (var item in _Posts)
            {
                var imgs = _context.Images.Where(e => e.PostId == item.Post_Id).ToList();
                if (imgs != null)
                {
                    foreach (var img in imgs)
                    {
                        var image = _context.Images.FirstOrDefault(e => e.ImgId == img.ImgId);
                        System.IO.File.Delete(image.ImgPath);
                        _context.Images.Remove(image);
                        _context.SaveChanges();
                    }
                }

                _context.Posts.Remove(item);
                _context.SaveChanges();
            }

            //var CityPosts = _context.Posts.Where(e => e.CityId == id).ToList();//Male
            //foreach (var item in CityPosts)
            //{
            //    item.CityId = 1;
            //}
            //await _context.SaveChangesAsync();

            var _city = await _context.Cities.FindAsync(id);
            _context.Cities.Remove(_city);
            await _context.SaveChangesAsync();
            return new JsonResult(true);
        }
        public IActionResult DeleteUser(string id)
        {

            //var CategoryPosts = _context.Posts.Where(e => e.CategoryId == id).ToList();//Male
            //foreach (var item in CategoryPosts)
            //{
            //    item.CategoryId = 1;
            //}
            //await _context.SaveChangesAsync();

            var loggedUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (loggedUserId == id)
            {
                return new JsonResult(false);
            }
           
            var UserLikes = _context.Likes.Where(e => e.UserId == id);
            _context.Likes.RemoveRange(UserLikes);
            //await _context.SaveChangesAsync();

            var UserComments = _context.Comments.Where(e => e.UserId == id);
            _context.Comments.RemoveRange(UserComments);
            //await _context.SaveChangesAsync();

            var _Posts = _context.Posts.Where(e => e.UserId == id).ToList();
            foreach (var item in _Posts)
            {
                var imgs = _context.Images.Where(e => e.PostId == item.Post_Id).ToList();
                if (imgs != null)
                {
                    foreach (var img in imgs)
                    {
                        var image = _context.Images.FirstOrDefault(e => e.ImgId == img.ImgId);
                        System.IO.File.Delete(image.ImgPath);
                        _context.Images.Remove(image);
                        _context.SaveChanges();
                    }
                }
                
                _context.Posts.Remove(item);
                _context.SaveChanges();
            }


            var User = _context.Users.Find(id);

            var userRole = _context.UserRoles.FirstOrDefault(e => e.UserId == User.Id);
            if (userRole != null)
            {
                _context.UserRoles.Remove(userRole);
            }

            var userPic = _context.Images.FirstOrDefault(e => e.UserId == User.Id);

            if (userPic != null)
            {
                System.IO.File.Delete(userPic.ImgPath);
                _context.Images.Remove(userPic);
            }

            _context.Users.Remove(User);

            _context.SaveChanges();

            return new JsonResult(true);
        }

    }
}