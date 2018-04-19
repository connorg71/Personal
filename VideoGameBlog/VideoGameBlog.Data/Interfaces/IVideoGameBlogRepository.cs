using VideoGameBlog.Data.Interfaces;
using VideoGameBlog.Models;

namespace VideoGameBlog.Data
{
	public interface IVideoGameBlogRepository<T> : IAddOnlyRepo<T> where T : ModelBase
	{
		void Edit(T item);

		void Delete(int id);
	}
}