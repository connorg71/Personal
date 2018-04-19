using System.Collections.Generic;
using System.Linq;
using VideoGameBlog.Data;
using VideoGameBlog.Data.Responses;
using VideoGameBlog.Data.TestEFRepositories;
using VideoGameBlog.Models;

namespace VideoGameBlog.BLL.Managers
{
	public class PostManager
	{
		private IVideoGameBlogRepository<Post> repo;

		public PostManager()
		{
			repo = new PostRepository(new Data.EntityFramework.Entity.BlogDbContext());
		}

		public List<Post> GetAllPost()
		{
			var all = repo.GetAll();
			return all.ToList();
		}

       public GenericResponse<Post> GetById(int id)
        {
            GenericResponse<Post> response = new GenericResponse<Post>();

            response.Payload = repo.Get(id);
            
            if (response.Payload == null)
            {
                response.Success = false;
                response.Message = "Could not load posts. Contact IT.";
            }

            else
            {
                response.Success = true;
            }

            return response;
        }

		public GenericResponse<Post> AddPost(Post post)
		{
			GenericResponse<Post> response = new GenericResponse<Post>();

			repo.Add(post);

			Post confirm = repo.Get(post.Id);

			//if (confirm != null &&
   //             confirm.PostTitle == post.PostTitle &&
   //             confirm.PostBody == post.PostBody &&
   //             confirm.PostCategory == post.PostCategory &&
   //             confirm.PostedDate == post.PostedDate &&
   //             confirm.PostImageFileName == post.PostImageFileName)
			//{
				response.Success = true;
				response.Payload = post;
			//}
			//else
			//{
			//	response.Success = false;
			//	response.Message = "ERROR : Post was not added to database.";
			//	response.Payload = post;
			//}

			return response;
		}

		public GenericResponse<Post> DeletePost(int id)
		{
			GenericResponse<Post> response = new GenericResponse<Post>();

			repo.Delete(id);

			if (repo.Get(id) == null)
			{
				response.Success = true;
			}
			else
			{
				response.Success = false;
				response.Message = "ERROR : Post was not deleted from database.";
				response.Payload = repo.Get(id);
			}

			return response;
		}

		public GenericResponse<Post> EditPost(Post post)
		{
			GenericResponse<Post> response = new GenericResponse<Post>();

			repo.Edit(post);

			if (repo.Get(post.Id) == post)
			{
				response.Success = true;
				response.Payload = repo.Get(post.Id);
			}
			else
			{
				response.Success = false;
				response.Message = "ERROR : Post was not edited within database.";
				response.Payload = post;
			}

			return response;
		}

        public GenericResponse<IEnumerable<Post>> GetByCategory(Category category)
        {
            GenericResponse<IEnumerable<Post>> response = new GenericResponse<IEnumerable<Post>>();

            response.Payload = repo.GetAll().Where(p => p.PostCategory.Id == category.Id);

            if (response.Payload == null)
            {
                response.Success = false;
                response.Message = "Error: Not able to load categories. Contact IT.";
            }

            else
            {
                response.Success = true;
            }

            return response;
        }
	}
}