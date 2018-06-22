using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerShip.Model.tables
{
	public class RoleStore : RoleStore<Role, int, UserRole>
	{
		public RoleStore(DbContext context) : base(context)
		{
		}
	}

}
