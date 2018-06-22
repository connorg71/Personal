using CarDealerShip.Model.tables;
using CarDealerShip.Repository.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerShip.Repository.EntityFramework
{
	public class EntityContactFormRepository : ICarDealerShipRepository<ContactForm>
	{
		private readonly IIdentityContext context;

		public EntityContactFormRepository(IIdentityContext context)
		{
			this.context = context;
		}
		public void Create(ContactForm newItem)
		{
			context.ContactForms.Add(newItem);
			context.SaveChanges();
		}

		public void Delete(int id)
		{
			var item = Get(id);
			context.ContactForms.Remove(item);
			context.SaveChanges();
		}

		public ContactForm Get(int id)
		{
			return context.ContactForms.FirstOrDefault(p => p.Id == id);
		}

		public IList<ContactForm> GetAll()
		{
			return context.ContactForms.ToList();
		}

		public void Update(ContactForm item)
		{
			var existingItem = Get(item.Id);
			existingItem.Email = item.Email;
			existingItem.Message = item.Message;
			existingItem.Name = item.Name;
			existingItem.Phone = item.Phone;

			context.SaveChanges();

		}
	}
}
