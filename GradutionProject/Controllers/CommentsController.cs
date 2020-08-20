using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GradutionProject.Data;
using GradutionProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GradutionProject.Controllers
{
   
    public class CommentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public CommentsController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult showCommentPost(int id)
        {
            var comments = _context.Comments.Include(p => p.User).Include(p => p.User.Image).Where(c => c.PostId == id).OrderBy(c => c.CommentDate).ToList();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewData["LoggedUserId"] = userId;
            return PartialView(comments);
        }

        public JsonResult AddComment([Bind("CommentId,CommentBody,PostId,UserId")] Comments com)
        {
            string CurrentUserID = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            com.UserId = CurrentUserID;
            com.CommentDate = DateTime.Now;
            _context.Add(com);
            _context.SaveChanges();
            return Json(com.PostId);
        }

        public JsonResult Delete(int id)
        {
            Comments comment = _context.Comments.FirstOrDefault(e=>e.CommentId==id);
            if (comment == null)
            {
                return Json("");
            }
            _context.Remove(comment);
            _context.SaveChanges();
            return Json(comment.PostId);
        }


    }
}