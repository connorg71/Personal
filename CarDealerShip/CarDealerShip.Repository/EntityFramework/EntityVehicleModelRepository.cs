using CarDealerShip.Model.tables;
using CarDealerShip.Repository.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerShip.Repository.EntityFramework
{
	public class EntityVehicleModelRepository : ICarDealerShipRepository<VehicleModel>
	{
		private readonly IIdentityContext context;

		public EntityVehicleModelRepository(IIdentityContext context)
		{
			this.context = context;
		}
		public void Create(VehicleModel newItem)
		{
			context.VehicleModels.Add(newItem);
			context.SaveChanges();
		}

		public void Delete(int id)
		{
			var item = Get(id);
			context.VehicleModels.Remove(item);
			context.SaveChanges();
		}

		public VehicleModel Get(int id)
		{
			return context.VehicleModels.FirstOrDefault(p => p.Id == id);
		}

		public IList<VehicleModel> GetAll()
		{
			return context.VehicleModels.ToList();
		}

		public void Update(VehicleModel item)
		{
			var existingItem = Get(item.Id);
			existingItem.Description = item.Description;

			context.SaveChanges();

		}
	}
}
