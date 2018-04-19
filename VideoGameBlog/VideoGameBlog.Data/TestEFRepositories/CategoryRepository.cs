using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using VideoGameBlog.Data.EntityFramework.Entity;
using VideoGameBlog.Data.Interfaces;
using VideoGameBlog.Models;

namespace VideoGameBlog.Data.TestEFRepositories
{
	public class CategoryRepository : IAddOnlyRepo<Category>
	{
		private BlogDbContext context { get; set; }

		public CategoryRepository(BlogDbContext context)
		{
            this.context = context;
		}

		public void Add(Category newItem)
		{
			context.Categories.AddOrUpdate(newItem);
            context.SaveChanges();
		}

		public Category Get(int id)
		{
			return context.Categories.Find(id);
		}

		public IList<Category> GetAll()
		{
			return context.Categories.ToList();
		}
	}
}