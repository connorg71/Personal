using CarDealerShip.Model.tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerShip.Repository.InMemory
{
	public class InMemoryVehicleModelRepository : ICarDealerShipRepository<VehicleModel>
	{
		List<VehicleModel> vehicleModels = new List<VehicleModel>
		{
			new VehicleModel { Id = 1, MakeId = 1 ,Description = "Mustang"},
			new VehicleModel { Id = 2, MakeId = 1 ,Description = "Escort"},
			new VehicleModel { Id = 3, MakeId = 1 ,Description = "Explorer"},
			new VehicleModel { Id = 4, MakeId = 2 ,Description = "Camry"},
			new VehicleModel { Id = 5, MakeId = 2 ,Description = "Land Cruiser"},
			new VehicleModel { Id = 6, MakeId = 2 ,Description = "Pruis"},
			new VehicleModel { Id = 7, MakeId = 3 ,Description = "Rio"},
			new VehicleModel { Id = 8, MakeId = 3 ,Description = "Fiesta"},
			new VehicleModel { Id = 9, MakeId = 3 ,Description = "Stinger"}
		};


		public void Create(VehicleModel newItem)
		{
			newItem.Id = vehicleModels.Max(i => i.Id) + 1;
			vehicleModels.Add(newItem);
		}

		public void Delete(int id)
		{
			var existing = Get(id);
			if (existing == null)
			{
				return;
			}
			vehicleModels.Remove(existing);
		}

		public VehicleModel Get(int id)
		{
			return vehicleModels.FirstOrDefault(p => p.Id == id);			
		}

		public IList<VehicleModel> GetAll()
		{
			return vehicleModels;
		}

		public void Update(VehicleModel item)
		{
			var existing = Get(item.Id);
			if (existing == null)
			{
				return;
			}
			existing.Description = item.Description;			
		}
	}
}
