using System.Collections.Generic;
using VideoGameBlog.Models;

namespace VideoGameBlog.Data.Interfaces
{
	public interface IAddOnlyRepo<T> where T : ModelBase
	{
		IList<T> GetAll();

		void Add(T newItem);

		T Get(int id);
	}
}