using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreBlogSample.Models.ViewModels;
using AspNetCoreBlogSample.Models.DB;

namespace AspNetCoreBlogSample.Services
{
    public interface IUserService
    {
        bool AddUser(User user);
        IEnumerable<UserViewModel> GetUsersList();
        UserViewModel GetUser(int userId);
        User GetTestUser();
    }
}
