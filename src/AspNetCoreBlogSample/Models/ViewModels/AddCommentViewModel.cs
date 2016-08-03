using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreBlogSample.Models.ViewModels
{
    public class AddCommentViewModel
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime PublishedDate { get; set; }
        public string AuthorEmail { get; set; }
        public string AuthorName { get; set; }
        public int PostId { get; set; }
        public virtual DB.Post Post { get; set; }
    }
}
