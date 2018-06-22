using CarDealerShip.Model.tables;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerShip.Model
{
	public class ApplicationUserManager : UserManager<User, int>
	{
		public ApplicationUserManager(IUserStore<User, int> store) : base(store)
		{
		}
	}
}
