using System;
using System.Collections.Generic;

namespace AspNetCoreBlogSample.Models.DB
{
    public partial class User
    {
        public User()
        {
            Post = new HashSet<Post>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<Post> Post { get; set; }
    }
}
