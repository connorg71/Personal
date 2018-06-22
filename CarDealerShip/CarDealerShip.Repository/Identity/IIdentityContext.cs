using CarDealerShip.Model.tables;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerShip.Repository.Identity
{
	public interface IIdentityContext
	{
		IDbSet<IdentityUser> Users { get; set; }
		DbSet<Role> Roles { get; set; }
		IDbSet<BodyStyle> BodyStyles { get; set; }
		IDbSet<Color> Colors { get; set; }
		IDbSet<ContactForm> ContactForms { get; set; }
		IDbSet<Interior> Interiors { get; set; }
		IDbSet<Make> Makes { get; set; }
		IDbSet<Purchase> Purchases { get; set; }
		IDbSet<Special> Specials { get; set; }
		IDbSet<Transmission> Transmissions { get; set; }
		IDbSet<Vehicle> Vehicles { get; set; }
		IDbSet<VehicleModel> VehicleModels { get; set; }
		IDbSet<VehicleType> VehicleTypes { get; set; }

		int SaveChanges();

	}
}
