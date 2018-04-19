namespace VideoGameBlog.Data.Migrations
{
	using Microsoft.AspNet.Identity;
	using Microsoft.AspNet.Identity.EntityFramework;
	using System.Data.Entity.Migrations;
	using VideoGameBlog.Data.InMemory;
	using VideoGameBlog.Models.Identity;

	internal sealed class Configuration : DbMigrationsConfiguration<VideoGameBlog.Data.EntityFramework.InitDbContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(VideoGameBlog.Data.EntityFramework.InitDbContext context)
		{
			var userMgr = new UserManager<BlogUser>(new UserStore<BlogUser>(context));
			var roleMgr = new RoleManager<BlogRole>(new RoleStore<BlogRole>(context));

			if (!roleMgr.RoleExists("Admin"))
			{
				roleMgr.Create(new BlogRole() { Name = "Admin" });
			}
			if (!roleMgr.RoleExists("Marketing"))
			{
				roleMgr.Create(new BlogRole() { Name = "Marketing" });
			}
			if (!roleMgr.RoleExists("Disabled"))
			{
				roleMgr.Create(new BlogRole() { Name = "Disabled" });
			}

			// create the default user
			var admin = new BlogUser()
			{
				UserName = "devteam",
                Email = "devteam@sg.org",
                PhoneNumber = "1111111111"
			};
			var marketing = new BlogUser()
			{
				UserName = "testmarketing",
                Email = "testmarketing@sg.org",
                PhoneNumber = "2222222222"
			};
			var disabled = new BlogUser()
			{
				UserName = "testdisabled",
                Email = "testdisabled@sg.org",
                PhoneNumber = "3333333333"
			};

			// create the user with the manager class
			if (userMgr.FindByName(admin.UserName) == null)
				userMgr.Create(admin, "corndog123");
			if (userMgr.FindByName(marketing.UserName) == null)
				userMgr.Create(marketing, "corndog123");
			if (userMgr.FindByName(disabled.UserName) == null)
				userMgr.Create(disabled, "corndog123");

			// add the user to the admin role
			userMgr.AddToRole(admin.Id, "Admin");
			userMgr.AddToRole(marketing.Id, "Marketing");
			userMgr.AddToRole(disabled.Id, "Disabled");

			InMemoryCategoryRepository catRepo = new InMemoryCategoryRepository();
			foreach (var c in catRepo.GetAll())
			{
				context.Categories.AddOrUpdate(c);
				context.SaveChanges();
			}

			InMemoryTagRepository tagRepo = new InMemoryTagRepository();
			foreach (var t in tagRepo.GetAll())
			{
				context.Tags.AddOrUpdate(t);
				context.SaveChanges();
			}

			InMemoryStaticPageRepository statRepo = new InMemoryStaticPageRepository();
			foreach (var s in statRepo.GetAll())
			{
				context.StaticPages.AddOrUpdate(s);
				context.SaveChanges();
			}

			InMemoryPostRepository postRepo = new InMemoryPostRepository();
			foreach (var p in postRepo.GetAll())
			{
				context.Posts.AddOrUpdate(p);
                context.SaveChanges();
			}
		}
	}
}