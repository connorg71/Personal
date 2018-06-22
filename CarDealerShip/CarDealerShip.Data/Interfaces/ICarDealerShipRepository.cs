
using CarDealerShip.Model.tables;
using System.Collections.Generic;

namespace CarDealerShip.Repository
{
	public interface ICarDealerShipRepository<T> : IRepository where T : ModelBase
	{
		void Create(T newItem);

		T Get(int id);

		void Update(T item);

		void Delete(int id);

		IList<T> GetAll();
	}
}