using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using VideoGameBlog.Data.EntityFramework.Identity;
using VideoGameBlog.Data.Interfaces;
using VideoGameBlog.Models.Identity;
using VideoGameBlog.Data.Responses;

namespace VideoGameBlog.Data.TestEFRepositories
{
	public class UserRepository : IEFIdentityRepository
    {
		private IdentityContext context { get; set; }

		public UserRepository()
		{
			context = new IdentityContext();
		}

        public void AddUser(string userName, string email, string phone, string password, string role)
        {
            var userMgr = new UserManager<BlogUser>(new UserStore<BlogUser>(context));

            var user = new BlogUser()
            {
                UserName = userName,
                Email = email,
                PhoneNumber = phone
            };

            userMgr.Create(user, password);

            userMgr.AddToRole(user.Id, role);

            context.SaveChanges();
        }

        public void EditUser(BlogUser target, string userName, string email, string phone, string password, string role)
        {
            var userMgr = new UserManager<BlogUser>(new UserStore<BlogUser>(context));

            target.UserName = userName;
            target.Email = email;
            target.PasswordHash = userMgr.PasswordHasher.HashPassword(password);
            var roles = userMgr.GetRoles(target.Id).ToArray();
            userMgr.Update(target);
            userMgr.RemoveFromRoles(target.Id, roles);
            userMgr.AddToRole(target.Id, role);

            context.SaveChanges();
        }

        public List<BlogRole> GetAllRoles()
		{
			return context.Roles.ToList();
		}

		public List<BlogUser> GetAllUsers()
		{
			return context.Users.ToList();
		}

		public BlogUser GetUser(string id)
		{
			return context.Users.Find(id);
		}

		public string GetUserId(string userName)
		{
			return context.Users.FirstOrDefault(u => u.UserName == userName).Id;
		}

        public BlogUser GetUserByUserName(string userName)
        {
            var userMgr = new UserManager<BlogUser>(new UserStore<BlogUser>(context));

            return userMgr.FindByName(userName);
        }

        public bool UserIsInRole(BlogUser user, string role)
        {
            var userMgr = new UserManager<BlogUser>(new UserStore<BlogUser>(context));

            return userMgr.IsInRole(user.Id, role);
        }
    }
}
