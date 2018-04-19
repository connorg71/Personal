using System.Collections.Generic;
using System.Linq;
using VideoGameBlog.Data.Interfaces;
using VideoGameBlog.Models;

namespace VideoGameBlog.Data.InMemory
{
	public class InMemoryCategoryRepository : IAddOnlyRepo<Category>
	{
		public List<Category> categories = new List<Category>
		{
			new Category{Id = 1, CategoryName = "Rant"},
			new Category{Id = 2, CategoryName = "VR"},
			new Category{Id = 3, CategoryName = "Western"},
			new Category{Id = 4, CategoryName = "Old School"}
		};

		public void Add(Category newItem)
		{
			newItem.Id = categories.Max(i => i.Id) + 1;
			categories.Add(newItem);
		}

		public Category Get(int id)
		{
			return categories.FirstOrDefault(i => i.Id == id);
		}

		public IList<Category> GetAll()
		{
			return categories;
		}
	}
}