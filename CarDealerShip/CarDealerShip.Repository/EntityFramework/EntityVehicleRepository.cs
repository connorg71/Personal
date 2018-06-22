using CarDealerShip.Model.tables;
using CarDealerShip.Repository.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerShip.Repository.EntityFramework
{
	public class EntityVehicleRepository : ICarDealerShipRepository<Vehicle>
	{
		private readonly IIdentityContext context;

		public EntityVehicleRepository(IIdentityContext context)
		{
			this.context = context;
		}
		public void Create(Vehicle newItem)
		{
			context.Vehicles.Add(newItem);
			context.SaveChanges();
		}

		public void Delete(int id)
		{
			var item = Get(id);
			context.Vehicles.Remove(item);
			context.SaveChanges();
		}

		public Vehicle Get(int id)
		{
			return context.Vehicles.FirstOrDefault(p => p.Id == id);
		}

		public IList<Vehicle> GetAll()
		{
			return context.Vehicles.ToList();
		}

		public void Update(Vehicle item)
		{
			var existingItem = Get(item.Id);
			existingItem.BodyStyle = item.BodyStyle;
			existingItem.Color = item.Color;
			existingItem.Description = item.Description;
			existingItem.Featured = item.Featured;
			existingItem.Interior = item.Interior;
			existingItem.Make = item.Make;
			existingItem.Mileage = item.Mileage;
			existingItem.Model = item.Model;
			existingItem.ModelYear = item.ModelYear;
			existingItem.MSRP = item.MSRP;
			existingItem.PictureUrl = item.PictureUrl;
			existingItem.SalePrice = item.SalePrice;
			existingItem.Sold = item.Sold;
			existingItem.Transmission = item.Transmission;
			existingItem.Type = item.Type;
			existingItem.Vin = item.Vin;

			context.SaveChanges();

		}
	}
}
