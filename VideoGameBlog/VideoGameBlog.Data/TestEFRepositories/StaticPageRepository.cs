using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using VideoGameBlog.Data.EntityFramework.Entity;
using VideoGameBlog.Models;

namespace VideoGameBlog.Data.TestEFRepositories
{
	public class StaticPageRepository : IVideoGameBlogRepository<StaticPage>
	{
		private BlogDbContext context { get; set; }

		public StaticPageRepository(BlogDbContext context)
		{
            this.context = context;
		}

		public void Add(StaticPage newItem)
		{
			context.StaticPages.AddOrUpdate(newItem);
            context.SaveChanges();
		}

		public void Delete(int id)
		{
			context.StaticPages.Remove(Get(id));
            context.SaveChanges();
        }

		public void Edit(StaticPage item)
		{
			context.StaticPages.AddOrUpdate(item);
            context.SaveChanges();
        }

		public StaticPage Get(int id)
		{
			return context.StaticPages.Find(id);
		}

		public IList<StaticPage> GetAll()
		{
			return context.StaticPages.ToList();
		}
	}
}