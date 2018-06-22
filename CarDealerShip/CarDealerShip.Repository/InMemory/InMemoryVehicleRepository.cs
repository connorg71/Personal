
using CarDealerShip.Model.Enums;
using CarDealerShip.Model.tables;
using System.Collections.Generic;
using System.Linq;

namespace CarDealerShip.Repository.InMemory
{
	public class InMemoryVehicleRepository : ICarDealerShipRepository<Vehicle>
	{
		private IList<Vehicle> vehicles = new List<Vehicle>
		{
			new Vehicle { ModelYear = 1995, SalePrice = 1200, Featured = true, Id = 1, Vin = "12345", Type = VehicleTypes.Used },
			new Vehicle { ModelYear = 1996, SalePrice = 8000, Featured = false, Id = 2, Vin = "asdfghkj", Type = VehicleTypes.New },
			new Vehicle { ModelYear = 2000, SalePrice = 7050, Featured = true, Id = 3, Vin = "989jhjhjh", Type = VehicleTypes.Used },
			new Vehicle {ModelYear = 2006, SalePrice = 9000, Featured = true, Id = 4, Vin = "asdfjeye", Sold = true, Type = VehicleTypes.New}
		};

		public void Create(Vehicle newItem)
		{
			newItem.Id = vehicles.Max(i => i.Id) + 1;
			vehicles.Add(newItem);
		}

		public void Delete(int id)
		{
			var existing = Get(id);
			if (existing == null)
			{
				return;
			}
			vehicles.Remove(existing);
		}

		public Vehicle Get(int id)
		{
			return vehicles.FirstOrDefault(i => i.Id == id);
		}

		public IList<Vehicle> GetAll()
		{
			return vehicles;
		}

		public void Update(Vehicle item)
		{
			var existing = Get(item.Id);
			if (existing == null)
			{
				return;
			}
			existing.ModelYear = item.ModelYear;
			existing.SalePrice = item.SalePrice;
			existing.Featured = item.Featured;
		}
	}
}