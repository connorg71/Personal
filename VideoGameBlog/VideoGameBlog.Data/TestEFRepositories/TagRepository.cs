using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using VideoGameBlog.Data.EntityFramework.Entity;
using VideoGameBlog.Data.Interfaces;
using VideoGameBlog.Models;

namespace VideoGameBlog.Data.TestEFRepositories
{
	public class TagRepository : IAddOnlyRepo<Tag>
	{
		private BlogDbContext context { get; set; }

		public TagRepository(BlogDbContext context)
		{
            this.context = context;
		}

		public void Add(Tag newItem)
		{
			context.Tags.AddOrUpdate(newItem);
            context.SaveChanges();
        }

		public Tag Get(int id)
		{
			return context.Tags.Find(id);
		}

		public IList<Tag> GetAll()
		{
			return context.Tags.ToList();
		}
	}
}