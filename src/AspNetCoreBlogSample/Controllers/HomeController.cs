using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreBlogSample.Services;
using AspNetCoreBlogSample.Models.ViewModels;
using AspNetCoreBlogSample.Models.DB;

namespace AspNetCoreBlogSample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService _postService;
        private readonly IUserService _userService;
        private readonly User testUser;
        public HomeController(IPostService postService, IUserService userService)
        {
            _postService = postService;
            _userService = userService;
            testUser = userService.GetTestUser();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

       
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddPost()
        {

            var post = new AddPostViewModel {
                User= testUser,
                UserId = testUser.Id
            };
            return View(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddPost(AddPostViewModel post)
        {
            if (ModelState.IsValid)
            {
                post.PublishedDate = DateTime.Now;
                post.User = testUser;
                post.UserId = testUser.Id;

                if (_postService.AddPost(post))
                {
                    ViewBag.Message = "Post added successfully";
                    AspNetCoreBlogSample.Hubs.PostHub.FetchPost();
                }
            }
            return View();
        }
    }
}
