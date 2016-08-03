using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreBlogSample.Models.ViewModels;
using AspNetCoreBlogSample.Models.DB;
namespace AspNetCoreBlogSample.Services
{
    interface ICommentService
    {
        void AddComment(AddCommentViewModel addCommentViewModel);
        IEnumerable<Comment> GetComments(int postID);
        Comment GetComment(int commentID);
    }
}
