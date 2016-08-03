using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreBlogSample.Models.DB;
using AspNetCoreBlogSample.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreBlogSample.Services
{
    public class PostService : IPostService
    {
        private readonly BlogSampleContext context;
        public PostService(BlogSampleContext _context)
        {
            this.context = _context;
        }
        public bool AddPost(AddPostViewModel addPostViewModel)
        {
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    var post = new Post
                    {
                        Id = addPostViewModel.Id,
                        Body = addPostViewModel.Body,
                        PublishedDate = addPostViewModel.PublishedDate,
                        Title = addPostViewModel.Title,
                        User = addPostViewModel.User,
                        UserId = addPostViewModel.UserId
                    };
                    context.Post.Add(post);
                    context.SaveChanges();
                    dbContextTransaction.Commit();
                    return true;

                }
                catch
                {
                    dbContextTransaction.Rollback();
                    return false;
                }
            }
        }

        public PostDetailsViewModel GetPost(int PostId)
        {
            var p = context.Post.FirstOrDefault(post => post.Id == PostId);
            if (p != null)
            {
                return new PostDetailsViewModel
                {
                    Body = p.Body,
                    Comment = p.Comment,
                    Id = p.Id,
                    EditedDate = p.EditedDate,
                    PublishedDate = p.PublishedDate,
                    Summary = p.Summary,
                    Title = p.Title,
                    User = p.User,
                };
            }
            else return null;
        }

        public IEnumerable<PostDetailsViewModel> GetPostsList()
        {
            if (context.Post.Any())
                return context.Post.Include(c => c.Comment)
                    .Select(p => new PostDetailsViewModel
                    {
                        Body = p.Body,
                        Comment = p.Comment,
                        Id = p.Id,
                        EditedDate = p.EditedDate,
                        PublishedDate = p.PublishedDate,
                        Summary = p.Summary,
                        Title = p.Title,
                        User = p.User,
                        UserId = p.UserId
                    }).OrderByDescending(p=>p.PublishedDate);
            return Enumerable.Empty<PostDetailsViewModel>();
            //if (context.Post.Any())
            //    return context.Post.ToList();
            //return Enumerable.Empty<Post>();
        }
    }
}
