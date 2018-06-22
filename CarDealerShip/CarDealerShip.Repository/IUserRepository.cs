using CarDealerShip.Model.tables;
using System.Collections.Generic;

namespace CarDealerShip.Repository
{
	public interface IUserRepository
	{
		List<User> GetAllUsers();

		List<Role> GetAllRoles();

		User GetUser(int id);

		int GetUserId(string userName);

		User GetUserByUserName(string userName);

		void AddUser(string userName, string email, string phone, string password, string role, string firstName, string lastName);
		void EditUser(User target, string userName, string email, string phone, string password, string role, string firstName, string lastName);

		bool UserIsInRole(User user, string role);

		string GetUserRole(int id);

		void UpdatePassword(int userId, string currentPassword, string newPassword);
	}
}