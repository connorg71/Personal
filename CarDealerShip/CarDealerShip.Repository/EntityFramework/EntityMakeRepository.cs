using CarDealerShip.Model.tables;
using CarDealerShip.Repository.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerShip.Repository.EntityFramework
{
	public class EntityMakeRepository : ICarDealerShipRepository<Make>
	{
		private readonly IIdentityContext context;

		public EntityMakeRepository(IIdentityContext context)
		{
			this.context = context;
		}
		public void Create(Make newItem)
		{
			context.Makes.Add(newItem);
			context.SaveChanges();
		}

		public void Delete(int id)
		{
			var item = Get(id);
			context.Makes.Remove(item);
			context.SaveChanges();
		}

		public Make Get(int id)
		{
			return context.Makes.FirstOrDefault(p => p.Id == id);
		}

		public IList<Make> GetAll()
		{
			return context.Makes.ToList();
		}

		public void Update(Make item)
		{
			var existingItem = Get(item.Id);
			existingItem.Description = item.Description;
			context.SaveChanges();

		}
	}
}
