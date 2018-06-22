using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerShip.Model.tables
{
	public class UserStore : UserStore<User, Role, int, UserLogin, UserRole, UserClaim>
	{
		public UserStore(DbContext context) : base(context)
		{
		}
	}
}
