using GradutionProject.Areas.Identity.Data;
using GradutionProject.Data;
using GradutionProject.Models;
using GradutionProject.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GradutionProject.Controllers
{
    [Authorize(Roles ="User")]
    public class PostsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public PostsController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Posts
        public IActionResult Index()
        {
            var LoggedInUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);//User ID
            UserProfileViewModel Profile = new UserProfileViewModel()
            {
                _user = _context.Users.Include(e => e.Image).FirstOrDefault(e => e.Id == LoggedInUserId),

                _Posts = _context.Posts.
                Include(p => p.Category).Include(p => p.City).Include(p => p.Region).Include(p => p.Images).Include(P => P._User)
                .Where(e => e.UserId == LoggedInUserId).OrderByDescending(e => e.Post_Id).ToList()
            };
            //var Alldata = _context.Posts.Include(p => p.Category).Include(p => p.City).Include(p => p.Region).Include(p => p.Images);
            return View(Profile);
        }

        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", 1);
            ViewData["RegionId"] = new SelectList(_context.Regions, "RegionId", "RegionName", 1);
            ViewData["CityId"] = new SelectList(_context.Cities, "City_id", "City_name", 1);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Post post, IFormFile[] Image)
        {

            post.Post_Create_Date = DateTime.Now;
            //post.CityId = 1;
            post.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);//login User//ID
            post._User = _context.Users.Find(post.UserId);
            var namelist = new List<string>();
            for (int i = 0; i < Image.Length; i++)
            {
                string folderpath = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                string filename = Guid.NewGuid().ToString() + "." + Image[i].FileName.Split('.')[1];
                string filepath = Path.Combine(folderpath, filename);
                if (System.IO.File.Exists(filepath))
                {
                    var ext = "";
                    filename = filename + "new" + ext;
                    filepath = Path.Combine(folderpath, filename);
                }
                namelist.Add(filename);
                Image[i].CopyTo(new FileStream(filepath, FileMode.Create));
            }

            if (ModelState.IsValid)
            {
                _context.Posts.Add(post);
                await _context.SaveChangesAsync();

                foreach (var item in namelist)
                {
                    var image = new Images() { ImgPath = item, PostId = post.Post_Id };
                    _context.Add(image);
                    await _context.SaveChangesAsync();
                }
                post.Images = _context.Images.Where(a => a.PostId == post.Post_Id).ToList();
                var Alldata = _context.Posts.Include(p => p.Category).Include(p => p.City).Include(p => p.Region).Include(p => p.Images).Include(P => P._User).OrderByDescending(e => e.Post_Id).ToList();
                var LoggedInUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);//User ID
                UserProfileViewModel Profile = new UserProfileViewModel()
                {
                    _user = _context.Users.Find(LoggedInUserId),
                    _Posts = Alldata.Where(e => e.UserId == LoggedInUserId).ToList()
                };

                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "ViewAll", Profile) });
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", post.CategoryId);
            ViewData["CityId"] = new SelectList(_context.Cities, "City_id", "City_name", post.CityId);
            ViewData["RegionId"] = new SelectList(_context.Regions, "RegionId", "RegionName", post.RegionId);

            //ViewData["listOfImages"] = namelist;
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Create", post) });

        }
        [AllowAnonymous]
        public IActionResult Details(int? id)
        {
            //var post = _context.Posts.Find(id);
            var _Post = _context.Posts.Include(p => p.Category).Include(P=>P._User).Include(p => p.City).Include(p => p.Region).Include(p => p.Images).Single(e => e.Post_Id == id);
            var images = _context.Images.Where(e => e.PostId == _Post.Post_Id).ToList();
            ViewData["ListOfImages"] = images;
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            ViewData["CityId"] = new SelectList(_context.Cities, "City_id", "City_name");
            ViewData["RegionId"] = new SelectList(_context.Regions, "RegionId", "RegionName");
            var comments = _context.Comments.Include(p => p.User).Where(c => c.PostId == id).OrderBy(c => c.CommentDate).ToList();
            var likes = _context.Likes.Include(p => p.User).Where(c => c.PostId == id).OrderBy(c => c.LikeDate).ToList();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewData["LoggedUserId"] = userId;
            ViewData["Likes"] = likes;
            ViewData["Comments"] = comments;
            var likesCount = _context.Likes.Where(e => e.PostId == id).Count();
            ViewData["likesCount"] = likesCount;
            var commentsCount = _context.Comments.Where(e => e.PostId == id).Count();
            ViewData["commentsCount"] = likesCount;
            return View(_Post);
        }


        // GET: Posts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var post = await _context.Posts.Include(p => p.Category).Include(p => p.City).Include(p => p.Region).Include(p => p.Images).SingleAsync(e => e.Post_Id == id);

            //var post = await _context.Posts.FindAsync(id);

            if (post == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", post.Category);
            ViewData["RegionId"] = new SelectList(_context.Regions, "RegionId", "RegionName", post.RegionId);
            ViewData["CityId"] = new SelectList(_context.Cities, "City_id", "City_name", 1);

            return View(post);
        }

        // POST: Posts/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Post post, IFormFile[] imgpath)
        {
            string filename = "";
            var Alldata = _context.Posts.Include(p => p.Category).Include(p => p.City).Include(p => p.Region).Include(P => P.Images).Include(p=>p._User).OrderByDescending(e => e.Post_Id).ToList();
            var _Post = _context.Posts/*.AsNoTracking()*/.Include(p => p.Category).Include(p => p.City).Include(p => p.Region).Include(p => p._User).Include(p => p.Images).Single(e => e.Post_Id == id);
            var img = _context.Images.Where(e => e.PostId == _Post.Post_Id).ToList();
            post.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            post._User = _context.Users.Find(post.UserId);

            //post.Images = img;
            if (imgpath.Length != 0)
            {
                for (int i = 0; i < img.Count; i++)
                {
                    System.IO.File.Delete(img[i].ImgPath);
                    _context.Images.Remove(img[i]);
                }

                _context.SaveChanges();
                var namelist = new List<string>();
                for (int i = 0; i < imgpath.Length; i++)
                {
                    string folderpath = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    filename = Guid.NewGuid().ToString() + "." + imgpath[i].FileName.Split('.')[1];
                    string filepath = Path.Combine(folderpath, filename);
                    if (System.IO.File.Exists(filepath))
                    {
                        var ext = "";
                        filename = filename + "new" + ext;
                        filepath = Path.Combine(folderpath, filename);
                    }
                    namelist.Add(filename);
                    imgpath[i].CopyTo(new FileStream(filepath, FileMode.Create));
                }
                foreach (var item in namelist)
                {
                    var image = new Images() { ImgPath = item, PostId = post.Post_Id };
                    _context.Add(image);
                    await _context.SaveChangesAsync();
                }
            }
            
            if (id != _Post.Post_Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Entry(_Post).CurrentValues.SetValues(post);
                await _context.SaveChangesAsync();

               

                var LoggedInUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);//User ID
                UserProfileViewModel Profile = new UserProfileViewModel()
                {
                    _user = _context.Users.Find(LoggedInUserId),
                    _Posts = Alldata.Where(e=>e.UserId==LoggedInUserId).ToList()
                };


                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "ViewAll", Profile) });
            }

            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", post.CategoryId);
            ViewData["CityId"] = new SelectList(_context.Cities, "City_id", "City_name", post.CityId);
            ViewData["RegionId"] = new SelectList(_context.Regions, "RegionId", "RegionName", post.RegionId);
            post.Images = _context.Images.Where(e => e.PostId == _Post.Post_Id).ToList();
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Edit", post) });
        }

        // GET: Posts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var ImagePost = _context.Images.Where(e => e.PostId == id).ToList();
            _context.Images.RemoveRange(ImagePost);
            for (int i = 0; i < ImagePost.Count; i++)
            {
                System.IO.File.Delete(ImagePost[i].ImgPath);
            }
            await _context.SaveChangesAsync();
            var post = await _context.Posts.FindAsync(id);
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            var LoggedInUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);//User ID
            UserProfileViewModel Profile = new UserProfileViewModel()
            {
                _user = _context.Users.Find(LoggedInUserId),
                _Posts = _context.Posts.Where(e=>e.UserId==LoggedInUserId).Include(p => p.Category).Include(p => p._User).Include(p => p.City).Include(p => p.Region).Include(P => P.Images).OrderByDescending(e => e.Post_Id).ToList()
            };

            //var Alldata = _context.Posts.Include(p => p.Category).Include(p => p._User).Include(p => p.City).Include(p => p.Region).Include(P => P.Images).ToList();
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "ViewAll", Profile) });
            //return RedirectToAction(nameof(Index));
        }

        //Edit profile
        //GET
        public IActionResult EditProfile(string id)
        {
            
            UserProfileViewModel Profile = new UserProfileViewModel()
            {
                _user = _context.Users.Include(e=>e.Image).SingleOrDefault(e=>e.Id==id),
            };
            return View(Profile);
        }


        //Edit Profile
        //Post
        [HttpPost]
        [ActionName("EditProfile")]
        public async Task<IActionResult> EditProfile1(string id, UserProfileViewModel Profile, IFormFile Image)
        {
            var userp = _context.Users.Find(id);
            var img = _context.Images.SingleOrDefault(a => a.UserId == Profile._user.Id);

            if (Image != null)
            {
                if (img != null)
                {
                    System.IO.File.Delete(img.ImgPath);
                    _context.Images.Remove(img);
                    _context.SaveChanges();
                }
            string folderpath = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            string filename = Guid.NewGuid().ToString() + "." + Image.FileName.Split('.')[1];
            string filepath = Path.Combine(folderpath, filename);
            if (System.IO.File.Exists(filepath))
            {
                var ext = "";
                filename = filename + "new" + ext;
                filepath = Path.Combine(folderpath, filename);
            }

            Image.CopyTo(new FileStream(filepath, FileMode.Create));
            var image = new Images() { ImgPath = filename, UserId = Profile._user.Id };
            _context.Add(image);
            await _context.SaveChangesAsync();

            }
            if (ModelState.IsValid)
            {
                // _context.Update(userp);
                //user._user.Image = _context.Images.SingleOrDefault(e => e.UserId == Profile._user.Id);//null
                Profile._user.Image = _context.Images.SingleOrDefault(e => e.UserId == Profile._user.Id);
                _context.Entry(userp).CurrentValues.SetValues(Profile._user);
                await _context.SaveChangesAsync();

                UserProfileViewModel UpdatedProfile = new UserProfileViewModel()
                {
                    _user = _context.Users.Include(e => e.Image).SingleOrDefault(e => e.Id == id),
                };
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "UserProfile", UpdatedProfile) });
            }

            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "EditProfile", Profile._user) });
        }



        [HttpPost]
        public IActionResult PostLike(int PostId, string UserId)
        {
            var like = _context.Likes.FirstOrDefault(e => e.UserId == UserId && e.PostId == PostId);
            if (like == null)
            {
                _context.Add(new Like() { PostId = PostId, UserId = UserId ,LikeDate=DateTime.Now});
            }
            else
            {
                _context.Remove(like);
            }
            _context.SaveChanges();
            return Json(true);
        }

        //GET: /Posts/ShowLikeOwners/PostID
        [HttpGet]
        public IActionResult ShowLikeOwners(int PostId)
        {
            //Step1: get all likes list by postID
            var likesList = _context.Likes.ToList().Where(l => l.PostId == PostId).ToList() ;
            //Step2: get all users by likeOwnerID in each item in like list derived from prev step
            var likeOwners =  from User in _context.Likes.Include(e=>e.User).ToList()
                              from Like in likesList
                              where User.UserId == Like.UserId
                              select User;
            //try getting user's(SignedInUser) friends
            var currentUserID = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.FirstOrDefault(e => e.Id == currentUserID);
            ViewData["User"] = user;
            //Step3:return user model to the partial view
            return PartialView(likeOwners.ToList());
        }


        //GET: /Posts/ShowLikeOwners/PostID
        [HttpGet]
        public IActionResult GetPosts()
        {
            var LoggedInUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);//User ID
            UserProfileViewModel Profile = new UserProfileViewModel()
            {
                _user = _context.Users.Find(LoggedInUserId),

                _Posts = _context.Posts.
                Include(p => p.Category).Include(p => p.City).Include(p => p.Region).Include(p => p.Images).Include(P => P._User)
                .Where(e => e.UserId == LoggedInUserId).ToList()
            };

            return PartialView("ViewAll", Profile);
        }
    }

}
