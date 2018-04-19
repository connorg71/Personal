using System.Data.Entity;
using VideoGameBlog.Models;

namespace VideoGameBlog.Data.EntityFramework.Entity
{
	public class BlogDbContext : DbContext
	{
		public BlogDbContext() : base("VideoGameBlog")
		{
			Database.SetInitializer<BlogDbContext>(null);
		}

		public DbSet<Post> Posts { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<StaticPage> StaticPages { get; set; }
		public DbSet<Tag> Tags { get; set; }
	}
}