using CarDealerShip.Model.tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerShip.Repository.InMemory
{
	public class InMemoryMakeRepository : ICarDealerShipRepository<Make>
	{
		List<Make> makes = new List<Make> { new Make { Id = 1, Description = "Ford"}, new Make { Id = 2, Description = "Toyota"}, new Make { Id = 3, Description = "Kia"} };

		public void Create(Make newItem)
		{
			newItem.Id = makes.Max(i => i.Id) + 1;
			makes.Add(newItem);
		}

		public void Delete(int id)
		{
			var existing = Get(id);
			if (existing == null)
			{
				return;
			}
			makes.Remove(existing);
		}

		public Make Get(int id)
		{
			return makes.FirstOrDefault(p => p.Id == id);
		}

		public IList<Make> GetAll()
		{
			return makes;
		}

		public void Update(Make item)
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
