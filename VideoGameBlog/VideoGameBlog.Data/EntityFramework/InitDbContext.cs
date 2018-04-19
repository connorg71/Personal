using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using VideoGameBlog.Models;
using VideoGameBlog.Models.Identity;

namespace VideoGameBlog.Data.EntityFramework
{
	public class InitDbContext : IdentityDbContext
	{
		public InitDbContext() : base("VideoGameBlog")
		{
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Post>().HasMany(p => p.PostTags).WithMany(t => t.Posts).Map(m =>
			{
				m.ToTable("TagPosts");
				m.MapLeftKey("Post_Id");
				m.MapRightKey("Tag_Id");
			});
			base.OnModelCreating(modelBuilder);
		}

		public DbSet<BlogUser> Users { get; set; }
		public DbSet<BlogRole> Roles { get; set; }
		public DbSet<Post> Posts { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<StaticPage> StaticPages { get; set; }
		public DbSet<Tag> Tags { get; set; }
	}
}