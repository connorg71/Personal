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
	public class IdentityContext : IdentityDbContext, IIdentityContext
	{


		public IdentityContext() : base("CarDealerShip")
		{
			Database.SetInitializer<IdentityContext>(null);
		}

		public new DbSet<User> Users { get; set; }
		public new DbSet<Role> Roles { get; set; }
		public IDbSet<BodyStyle> BodyStyles { get; set; }
		public IDbSet<Color> Colors { get; set; }
		public IDbSet<ContactForm> ContactForms { get; set; }
		public IDbSet<Interior> Interiors { get; set; }
		public IDbSet<Make> Makes { get; set; }
		public IDbSet<Purchase> Purchases { get; set; }
		public IDbSet<Special> Specials { get; set; }
		public IDbSet<Transmission> Transmissions { get; set; }		
		public IDbSet<Vehicle> Vehicles { get; set; }
		public IDbSet<VehicleModel> VehicleModels { get; set; }
		public IDbSet<VehicleType> VehicleTypes { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<UserRole>().HasKey(p => new { p.UserId, p.RoleId });
			modelBuilder.Entity<UserLogin>().HasKey(p => new { p.UserId, p.ProviderKey });
			modelBuilder.Entity<BodyStyle>().MapToStoredProcedures();
			modelBuilder.Entity<Color>().MapToStoredProcedures();
			modelBuilder.Entity<ContactForm>().MapToStoredProcedures();
			modelBuilder.Entity<Interior>().MapToStoredProcedures();
			modelBuilder.Entity<Make>().MapToStoredProcedures();
			modelBuilder.Entity<Purchase>().MapToStoredProcedures();
			modelBuilder.Entity<Special>().MapToStoredProcedures();
			modelBuilder.Entity<Transmission>().MapToStoredProcedures();
			modelBuilder.Entity<Vehicle>().MapToStoredProcedures();
			modelBuilder.Entity<VehicleModel>().MapToStoredProcedures();
			modelBuilder.Entity<VehicleType>().MapToStoredProcedures();
			//modelBuilder.Entity<User>().Property(p => p.Id).HasDatabaseGeneratedOption()
			base.OnModelCreating(modelBuilder);


		}
	}
}
