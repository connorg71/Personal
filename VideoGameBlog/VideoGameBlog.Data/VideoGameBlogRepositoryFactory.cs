using System;
using System.Configuration;
using VideoGameBlog.Data.InMemory;
using VideoGameBlog.Data.Interfaces;
using VideoGameBlog.Models;

namespace VideoGameBlog.Data
{
	public class VideoGameBlogRepositoryFactory
	{
		public static IAddOnlyRepo<Category> CreateCategoryRepository()
		{
			string mode = ConfigurationManager.AppSettings["Mode"].ToString();

			switch (mode)
			{
				case "SampleData":
					return new InMemoryCategoryRepository();
				//case "EntityFramework":
				//    return new EntityFramework.EntityFrameworkCategoryRepository();
				default:
					throw new Exception("Mode value in web config is not valid. Consult IT.");
			}
		}

		public static IVideoGameBlogRepository<Post> CreatePostRepository()
		{
			string mode = ConfigurationManager.AppSettings["Mode"].ToString();

			switch (mode)
			{
				case "SampleData":
					return new InMemoryPostRepository();
				//case "EntityFramework":
				//    return new EntityFramework.EntityFrameworkPostRepository();
				default:
					throw new Exception("Mode value in web config is not valid. Consult IT.");
			}
		}

		public static IVideoGameBlogRepository<StaticPage> CreateStaticPageRepository()
		{
			string mode = ConfigurationManager.AppSettings["Mode"].ToString();

			switch (mode)
			{
				case "SampleData":
					return new InMemoryStaticPageRepository();
				//case "EntityFramework":
				//    return new EntityFramework.EntityFrameworkStaticPageRepository();
				default:
					throw new Exception("Mode value in web config is not valid. Consult IT.");
			}
		}

		public static IAddOnlyRepo<Tag> CreateTagRepository()
		{
			string mode = ConfigurationManager.AppSettings["Mode"].ToString();

			switch (mode)
			{
				case "SampleData":
					return new InMemoryTagRepository();
				//case "EntityFramework":
				//    return new EntityFramework.EntityFrameworkTagRepository();
				default:
					throw new Exception("Mode value in web config is not valid. Consult IT.");
			}
		}
	}
}