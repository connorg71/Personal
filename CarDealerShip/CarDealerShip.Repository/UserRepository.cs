using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealerShip.Model;
using CarDealerShip.Model.tables;
using CarDealerShip.Repository.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CarDealerShip.Repository
{
	public class UserRepository : IUserRepository
	{
		private IdentityContext context;

		public UserRepository()
		{
			context = new IdentityContext();
		}

		public void AddUser(string userName, string email, string phone, string password, string role, string firstName, string lastName)
		{
			var userMgr = new ApplicationUserManager(new UserStore(context));

			var user = new User()
			{
				UserName = userName,
				Email = email,
				PhoneNumber = phone,
				FirstName = firstName,
				LastName = lastName
			};


			userMgr.Create(user, password);

			context.SaveChanges();

			userMgr.AddToRole(user.Id, role);

			context.SaveChanges();
		}

		public void EditUser(User target, string userName, string email, string phone, string password, string role, string firstName, string lastName)
		{
			//var userMgr = new UserManager<User>(new UserStore<User>(context));
			var userMgr = new ApplicationUserManager(new UserStore(context));
			target.UserName = userName;
			target.Email = email;
			target.PasswordHash = userMgr.PasswordHasher.HashPassword(password);
			target.FirstName = firstName;
			target.LastName = lastName;		
			var roles = userMgr.GetRoles(target.Id).ToArray();
			userMgr.Update(target);
			userMgr.RemoveFromRoles(target.Id, roles);
			userMgr.AddToRole(target.Id, role);

			context.SaveChanges();
		}

		public List<Role> GetAllRoles()
		{
			return context.Roles.ToList();
		}

		public List<User> GetAllUsers()
		{
			return context.Users.ToList();
		}

		public User GetUser(int id)
		{
			return context.Users.Find(id);
		}

		public int GetUserId(string userName)
		{
			return context.Users.FirstOrDefault(u => u.UserName == userName).Id;
		}

		public User GetUserByUserName(string userName)
		{
			var userMgr = new ApplicationUserManager(new UserStore(context));

			return userMgr.FindByName(userName);
		}

		public bool UserIsInRole(User user, string role)
		{
			var userMgr = new ApplicationUserManager(new UserStore(context));
			
			return userMgr.IsInRole(user.Id, role);
		}

		public string GetUserRole(int id)
		{
			var userMgr = new ApplicationUserManager(new UserStore(context));

			return userMgr.GetRoles(id).First();			
		}

		public void UpdatePassword(int userId, string currentPassword, string newPassword)
		{
			var userMgr = new ApplicationUserManager(new UserStore(context));

			userMgr.ChangePassword(userId, currentPassword, newPassword);
		}

		
	}
}
