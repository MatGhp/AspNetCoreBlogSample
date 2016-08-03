using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreBlogSample.Models.DB;
using AspNetCoreBlogSample.Models.ViewModels;

namespace AspNetCoreBlogSample.Services
{
    public class CommentService : ICommentService
    {
        public void AddComment(AddCommentViewModel addCommentViewModel)
        {
            throw new NotImplementedException();
        }

        public Comment GetComment(int commentID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> GetComments(int postID)
        {
            throw new NotImplementedException();
        }
    }
}
