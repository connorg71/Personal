using CarDealerShip.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;

namespace CarDealerShip.Model.tables
{
	public class User : IdentityUser<int, UserLogin, UserRole, UserClaim>
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }


		public async Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
		{
			// Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
			var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
			// Add custom user claims here
			return userIdentity;
		}


	}
}
