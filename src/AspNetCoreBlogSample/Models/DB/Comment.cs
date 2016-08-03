using System;
using System.Collections.Generic;

namespace AspNetCoreBlogSample.Models.DB
{
    public partial class Comment
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime PublishedDate { get; set; }
        public string AuthorEmail { get; set; }
        public string AuthorName { get; set; }
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
