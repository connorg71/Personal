using CarDealerShip.Model.tables;
using System.Collections.Generic;
using System.Linq;

namespace CarDealerShip.Repository.InMemory
{
	public class InMemorySpecialsRepository : ICarDealerShipRepository<Special>
	{
		private static List<Special> specials = new List<Special>
		{
			new Special{Id = 1, Description = "special1", Title = "special1 title" },
			new Special{Id = 2, Description = "special2", Title = "special2 title" },
			new Special{Id = 3, Description = "special3", Title = "special3 title" },
			new Special{Id = 4, Description = "special4", Title = "special4 title" }
		};

		public void Create(Special newItem)
		{
			newItem.Id = specials.Max(i => i.Id) + 1;
			specials.Add(newItem);
		}

		public void Delete(int id)
		{
			var existing = Get(id);
			if (existing == null)
			{
				return;
			}
			specials.Remove(existing);
		}

		public Special Get(int id)
		{
			return specials.FirstOrDefault(i => i.Id == id);
		}

		public IList<Special> GetAll()
		{
			return specials;
		}

		public void Update(Special item)
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