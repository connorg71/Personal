using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameBlog.Data.Interfaces;
using VideoGameBlog.Data.Responses;
using VideoGameBlog.Data.TestEFRepositories;
using VideoGameBlog.Models.Identity;

namespace VideoGameBlog.BLL.Managers
{
    public class AccountManager
    {
        private IEFIdentityRepository repo { get; set; }

        public AccountManager()
        {
            repo = new UserRepository();
        }

        public GenericResponse<List<BlogRole>> GetAllRoles()
        {
            GenericResponse<List<BlogRole>> response = new GenericResponse<List<BlogRole>>();

            response.Payload = repo.GetAllRoles();

            if (response.Payload != null &&
                response.Payload.Count > 0)
            {
                response.Success = true;
            }
            else
            {
                response.Success = false;
                response.Message = "ERROR : Unable to retrieve a list of roles from database";
            }

            return response;
        }

        public GenericResponse<List<BlogUser>> GetAllUsers()
        {
            GenericResponse<List<BlogUser>> response = new GenericResponse<List<BlogUser>>();

            response.Payload = repo.GetAllUsers();

            if (response.Payload != null &&
                response.Payload.Count > 0)
            {
                response.Success = true;
            }
            else
            {
                response.Success = false;
                response.Message = "ERROR : Unable to retrieve a list of roles from database";
            }

            return response;
        }

        public GenericResponse<string> GetIdByUserName(string userName)
        {
            GenericResponse<string> response = new GenericResponse<string>();

            response.Payload = repo.GetUserId(userName);

            var check = repo.GetUser(response.Payload);

            if (check != null &&
                check.Id == response.Payload &&
                check.UserName == userName)
            {
                response.Success = true;
            }
            else
            {
                response.Success = false;
                response.Message = "ERROR : Unable to retrieve user's id from the database";
            }

            return response;
        }

        public GenericResponse<BlogUser> GetUserByUserName(string userName)
        {
            GenericResponse<BlogUser> response = new GenericResponse<BlogUser>();

            response.Payload = repo.GetUserByUserName(userName);

            if (response.Payload != null &&
                response.Payload.UserName == userName)
            {
                response.Success = true;
            }
            else
            {
                response.Success = false;
                response.Message = "ERROR : Unable to retrieve a user by that name from database";
            }

            return response;
        }

        public GenericResponse<BlogUser> GetUserById(string userId)
        {
            GenericResponse<BlogUser> response = new GenericResponse<BlogUser>();

            response.Payload = repo.GetUser(userId);

            if (response.Payload != null &&
                response.Payload.Id == userId)
            {
                response.Success = true;
            }
            else
            {
                response.Success = false;
                response.Message = "ERROR : Unable to get user by given user id";
            }

            return response;
        }

        public GenericResponse<BlogUser> AddUser(string name, string email, string phone, string password, string role)
        {
            GenericResponse<BlogUser> response = new GenericResponse<BlogUser>();

            repo.AddUser(name, email, phone, password, role);

            response.Payload = repo.GetUserByUserName(name);

            if (response.Payload != null &&
                response.Payload.Email == email &&
                repo.UserIsInRole(response.Payload, role))
                response.Success = true;
            else
            {
                response.Success = false;
                response.Message = "ERROR : User incorrectly enter into database";
            }

            return response;
        }

        public GenericResponse<BlogUser> EditUser(BlogUser target, string name, string email, string phone, string password, string role)
        {
            GenericResponse<BlogUser> response = new GenericResponse<BlogUser>();

            repo.EditUser(target, name, email, phone, password, role);

            response.Payload = repo.GetUser(target.Id);

            if (response.Payload != null &&
                response.Payload.UserName == name &&
                response.Payload.Email == email &&
                repo.UserIsInRole(response.Payload, role))
                response.Success = true;
            else
            {
                response.Success = false;
                response.Message = "ERROR : User incorrectly updated in database";
            }

            return response;
        }
    }
}
