using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreBlogSample.Models.ViewModels
{
    public class AddPostViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }

        [ScaffoldColumn(false)]
        public DateTime PublishedDate { get; set; }

        public int UserId { get; set; }
        public DB.User User { get; set; }
    }
}
