using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using VideoGameBlog.Data.EntityFramework.Entity;
using VideoGameBlog.Models;

namespace VideoGameBlog.Data.TestEFRepositories
{
    public class PostRepository : IVideoGameBlogRepository<Post>
    {
        private BlogDbContext context { get; set; }

        public PostRepository(BlogDbContext context)
        {
            this.context = context;
        }

        public void Add(Post newItem)
        {
            context.Posts.AddOrUpdate(newItem);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Posts.Remove(Get(id));
            context.SaveChanges();
        }

        public void Edit(Post item)
        {
            context.Posts.AddOrUpdate(item);
            context.SaveChanges();
        }

		public Post Get(int id)
		{
            using (BlogDbContext cxt = new BlogDbContext())
            {
                return cxt.Posts.Include("PostCategory").Include("PostTags").FirstOrDefault(p => p.Id == id);
            }
        }

		public IList<Post> GetAll()
		{
			using (BlogDbContext cxt = new BlogDbContext())
            {
                var query = cxt.Posts.Include("PostCategory").Include("PostTags");
                return query.ToList();
            }
		}
	}
}