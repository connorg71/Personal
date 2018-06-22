using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerShip.Model.tables
{
	public class Role : IdentityRole<int, UserRole>
	{
		public Role()
		{
		}

		public Role(string name)
		{
			Name = name;
		}
	}
}
