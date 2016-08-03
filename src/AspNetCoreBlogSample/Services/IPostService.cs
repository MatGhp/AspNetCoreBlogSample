using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreBlogSample.Models.ViewModels;
using AspNetCoreBlogSample.Models.DB;
namespace AspNetCoreBlogSample.Services
{
    public interface IPostService
    {
        bool AddPost(AddPostViewModel addPostViewModel);
        PostDetailsViewModel GetPost(int PostId);
        IEnumerable<PostDetailsViewModel> GetPostsList();
    }
}
