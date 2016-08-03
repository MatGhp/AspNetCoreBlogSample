using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreBlogSample.Models.DB;
using AspNetCoreBlogSample.Models.ViewModels;

namespace AspNetCoreBlogSample.Services
{
    public class UserService : IUserService
    {
        private readonly BlogSampleContext context;
        public UserService(BlogSampleContext _context)
        {
            this.context = _context;
        }
        public bool AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public UserViewModel GetUser(int userId)
        {
            var user = context.User.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                return new UserViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    UserName = user.UserName
                    
                };
            }
            else return null;
        }

        public IEnumerable<UserViewModel> GetUsersList()
        {
            if (context.User.Any())
            {
                return context.User.Select(u => new UserViewModel { Id = u.Id, UserName = u.UserName, Email = u.Email });
            }
            return Enumerable.Empty<UserViewModel>();
        }

        public User GetTestUser()
        {
            return context.User.FirstOrDefault();
        }
    }
}
