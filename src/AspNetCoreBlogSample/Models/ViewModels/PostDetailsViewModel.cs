
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreBlogSample.Models.ViewModels
{
    public class PostDetailsViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Summary { get; set; }
        public DateTime PublishedDate { get; set; }
        public DateTime? EditedDate { get; set; }

        public  IEnumerable<DB.Comment> Comment { get; set; }
        public  DB.User User { get; set; }
    }
}
