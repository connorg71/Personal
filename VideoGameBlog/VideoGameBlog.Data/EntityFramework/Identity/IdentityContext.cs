using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using VideoGameBlog.Models.Identity;

namespace VideoGameBlog.Data.EntityFramework.Identity
{
	public class IdentityContext : IdentityDbContext
	{
		public IdentityContext() : base("VideoGameBlog")
		{
			Database.SetInitializer<IdentityContext>(null);
		}

		public DbSet<BlogUser> Users { get; set; }
		public DbSet<BlogRole> Roles { get; set; }
	}
}