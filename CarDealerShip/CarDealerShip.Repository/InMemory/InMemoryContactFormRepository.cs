using CarDealerShip.Model.tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerShip.Repository.InMemory
{
	public class InMemoryContactFormRepository : ICarDealerShipRepository<ContactForm>
	{
		List<ContactForm> contactForms = new List<ContactForm>();

		public void Create(ContactForm newItem)
		{
			newItem.Id = contactForms.Max(i => i.Id) + 1;
			contactForms.Add(newItem);
			
		}

		public void Delete(int id)
		{
			var existing = Get(id);
			if (existing == null)
			{
				return;
			}
			contactForms.Remove(existing);
		}

		public ContactForm Get(int id)
		{
			return contactForms.FirstOrDefault(p => p.Id == id);
		}

		public IList<ContactForm> GetAll()
		{
			return contactForms;
		}

		public void Update(ContactForm item)
		{
			var existing = Get(item.Id);
			if (existing == null)
			{
				return;
			}
			existing.Email = item.Email;
			existing.Message = item.Message;
			existing.Name = item.Name;
			existing.Phone = item.Phone;			
		}
	}
}
