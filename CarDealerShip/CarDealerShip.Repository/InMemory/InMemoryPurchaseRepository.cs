using CarDealerShip.Model.tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerShip.Repository.InMemory
{
	public class InMemoryPurchaseRepository : ICarDealerShipRepository<Purchase>
	{
		List<Purchase> purchases = new List<Purchase>();

		public void Create(Purchase newItem)
		{
			newItem.Id = purchases.Max(i => i.Id) + 1;
			purchases.Add(newItem);
		}

		public void Delete(int id)
		{
			var existing = Get(id);
			if (existing == null)
			{
				return;
			}
			purchases.Remove(existing);
		}

		public Purchase Get(int id)
		{
			return purchases.FirstOrDefault(i => i.Id == id);
		}

		public IList<Purchase> GetAll()
		{
			return purchases;
		}

		public void Update(Purchase item)
		{
			var existing = Get(item.Id);
			if (existing == null)
			{
				return;
			}

			existing.City = item.City;
			existing.Email = item.Email;
			existing.Phone = item.Phone;
			existing.PurchaseDate = item.PurchaseDate;
			existing.PurchaseType = item.PurchaseType;
			existing.SalePrice = item.SalePrice;
			existing.SalesPersonId = item.SalesPersonId;
			existing.State = item.State;
			existing.Street1 = item.Street1;
			existing.Street2 = item.Street2;
			existing.ZipCode = item.ZipCode;
			existing.VehicleId = item.Id;
		}
	}
}
