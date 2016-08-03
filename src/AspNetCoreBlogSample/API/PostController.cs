using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreBlogSample.Services;
using AspNetCoreBlogSample.Models.ViewModels;
using AspNetCoreBlogSample.Models.DB;

namespace AspNetCoreBlogSample.API
{
    [Produces("application/json")]
    [Route("api/Post")]
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public IEnumerable<PostDetailsViewModel> Get()
        {
            var posts = _postService.GetPostsList();
            return posts.ToList();
        }
    }
}