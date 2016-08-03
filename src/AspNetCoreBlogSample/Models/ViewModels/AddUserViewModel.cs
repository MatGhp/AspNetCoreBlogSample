using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace AspNetCoreBlogSample.Models.ViewModels
{
    public class AddUserViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Email is required!")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string UserName { get; set; }
    }
}
