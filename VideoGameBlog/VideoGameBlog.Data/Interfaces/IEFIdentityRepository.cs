
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameBlog.Data.Responses;

using VideoGameBlog.Models.Identity;

namespace VideoGameBlog.Data.Interfaces
{

    public interface IEFIdentityRepository
    {
        List<BlogUser> GetAllUsers();

        List<BlogRole> GetAllRoles();

        BlogUser GetUser(string id);

        string GetUserId(string userName);

        BlogUser GetUserByUserName(string userName);

        void AddUser(string userName, string email, string phone, string password, string role);
        void EditUser(BlogUser target, string userName, string email, string phone, string password, string role);

        bool UserIsInRole(BlogUser user, string role);
    }
}
