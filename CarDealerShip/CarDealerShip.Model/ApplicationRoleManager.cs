using CarDealerShip.Model.tables;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerShip.Model
{
	public class ApplicationRoleManager : RoleManager<Role, int>
	{
		public ApplicationRoleManager(IRoleStore<Role, int> store) : base(store)
		{
		}
	}
}
