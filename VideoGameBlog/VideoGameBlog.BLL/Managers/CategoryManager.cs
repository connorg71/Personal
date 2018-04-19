using System.Collections.Generic;
using System.Linq;
using VideoGameBlog.Data.Interfaces;
using VideoGameBlog.Data.Responses;
using VideoGameBlog.Data.TestEFRepositories;
using VideoGameBlog.Models;

namespace VideoGameBlog.BLL.InMemoryManagers
{
	public class CategoryManager
	{
		private IAddOnlyRepo<Category> repo { get; set; }

		public CategoryManager()
		{
            repo = new CategoryRepository(new Data.EntityFramework.Entity.BlogDbContext());
		}

		public List<Category> GetAllCategories()
		{
			GenericResponse<Category> response = new GenericResponse<Category>();

			var all = repo.GetAll();
			return all.ToList();
		}

        public GenericResponse<Category> GetCategoryById(int id)
        {
            var response = new GenericResponse<Category>();
            var category = repo.Get(id);

            if (category == null)
            {
                response.Success = false;
                response.Message = "Unable to find category. Contact IT.";
            }

            else
            {
                response.Success = true;
                response.Payload = category;
            }

            return response;
        }

        public GenericResponse<Category> AddCategory(Category category)
		{
			GenericResponse<Category> response = new GenericResponse<Category>();
			List<Category> current = repo.GetAll().ToList();

			bool categoryExists = false;

			foreach (var c in current)
			{
				if (c.CategoryName == category.CategoryName)
				{
					categoryExists = true;
					category = c;
				}
			}

			if (categoryExists)
			{
				response.Success = false;
				response.Message = "Cannot add given category as it already exists in database";
				response.Payload = category;
			}
			else
			{
				repo.Add(category);
				response.Success = true;
				response.Payload = repo.GetAll().FirstOrDefault(c => c.CategoryName == category.CategoryName);
			}

			return response;
		}
	}
}