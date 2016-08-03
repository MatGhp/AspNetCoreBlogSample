using System;
using System.Collections.Generic;

namespace AspNetCoreBlogSample.Models.DB
{
    public partial class Post
    {
        public Post()
        {
            Comment = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Summary { get; set; }
        public DateTime PublishedDate { get; set; }
        public DateTime? EditedDate { get; set; }

        public virtual ICollection<Comment> Comment { get; set; }
        public virtual User User { get; set; }
    }
}
