using CarDealerShip.Model.tables;
using CarDealerShip.Repository.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerShip.Repository.EntityFramework
{
	public class EntityPurchaseRepository : ICarDealerShipRepository<Purchase>
	{
		private readonly IIdentityContext context;

		public EntityPurchaseRepository(IIdentityContext context)
		{
			this.context = context;
		}
		public void Create(Purchase newItem)
		{
			context.Purchases.Add(newItem);
			context.SaveChanges();
		}

		public void Delete(int id)
		{
			var item = Get(id);
			context.Purchases.Remove(item);
			context.SaveChanges();
		}

		public Purchase Get(int id)
		{
			return context.Purchases.FirstOrDefault(p => p.Id == id);
		}

		public IList<Purchase> GetAll()
		{
			return context.Purchases.ToList();
		}

		public void Update(Purchase item)
		{
			var existingItem = Get(item.Id);

			existingItem.City = item.City;
			existingItem.Email = item.Email;
			existingItem.Phone = item.Phone;
			existingItem.PurchaseDate = item.PurchaseDate;
			existingItem.PurchaseType = item.PurchaseType;
			existingItem.SalePrice = item.SalePrice;
			existingItem.SalesPersonId = item.SalesPersonId;
			existingItem.State = item.State;
			existingItem.Street1 = item.Street1;
			existingItem.Street2 = item.Street2;
			existingItem.VehicleId = item.VehicleId;
			existingItem.ZipCode = item.ZipCode;

			context.SaveChanges();

		}
	}
}
