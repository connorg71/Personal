using CarDealerShip.Model.tables;
using CarDealerShip.Repository.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerShip.Repository.EntityFramework
{
	public class EntitySpecialsRepository : ICarDealerShipRepository<Special>
	{
		private readonly IIdentityContext context;

		public EntitySpecialsRepository(IIdentityContext context)
		{
			this.context = context;
		}
		public void Create(Special newItem)
		{
			context.Specials.Add(newItem);
			context.SaveChanges();
		}

		public void Delete(int id)
		{
			var item = Get(id);
			context.Specials.Remove(item);
			context.SaveChanges();
		}

		public Special Get(int id)
		{
			return context.Specials.FirstOrDefault(p => p.Id == id);
		}

		public IList<Special> GetAll()
		{
			return context.Specials.ToList();
		}

		public void Update(Special item)
		{
			var existingItem = Get(item.Id);
			existingItem.Description = item.Description;
			existingItem.Title = item.Title;
			context.SaveChanges();

		}
	}
}
