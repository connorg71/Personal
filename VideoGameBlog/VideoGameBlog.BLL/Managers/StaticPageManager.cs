using System.Collections.Generic;
using System.Linq;
using VideoGameBlog.Data;
using VideoGameBlog.Data.Responses;
using VideoGameBlog.Data.TestEFRepositories;
using VideoGameBlog.Models;

namespace VideoGameBlog.BLL.Managers
{
	public class StaticPageManager
	{
		private IVideoGameBlogRepository<StaticPage> repo;

		public StaticPageManager()
		{
			repo = new StaticPageRepository(new Data.EntityFramework.Entity.BlogDbContext());
		}

		public GenericResponse<List<StaticPage>> GetAllStaticPage()
		{
			GenericResponse<List<StaticPage>> response = new GenericResponse<List<StaticPage>>();

			response.Payload = repo.GetAll().ToList();

			if (response.Payload != null && response.Payload.Count > 0)
			{
				response.Success = true;
			}
			else
			{
				response.Success = false;
				response.Message = "ERROR : Static Pages unable to load from database.";
			}

			return response;
		}

        public GenericResponse<StaticPage> GetById(int id)
        {
            GenericResponse<StaticPage> response = new GenericResponse<StaticPage>();

            response.Payload = repo.Get(id);

            if (response.Payload == null)
            {
                response.Success = false;
                response.Message = "Could not load Static Page. Contact IT.";
            }
            else
            {
                response.Success = true;
            }

            return response;
        }

		public GenericResponse<StaticPage> AddStaticPagePage(StaticPage staticPage)
		{
			GenericResponse<StaticPage> response = new GenericResponse<StaticPage>();

			repo.Add(staticPage);

			StaticPage confirm = repo.GetAll().FirstOrDefault(s => s.StaticPageTitle == staticPage.StaticPageTitle &&
															s.StaticPageContent == staticPage.StaticPageContent &&
															s.StaticPageImageFileName == staticPage.StaticPageImageFileName);

			if (confirm != null && repo.GetAll().Contains(confirm))
			{
				response.Success = true;
				response.Payload = confirm;
			}
			else
			{
				response.Success = false;
				response.Message = "ERROR : Static Page was not entered into database.";
				response.Payload = staticPage;
			}

			return response;
		}

		public GenericResponse<StaticPage> DeleteStaticPage(int id)
		{
			GenericResponse<StaticPage> response = new GenericResponse<StaticPage>();

			repo.Delete(id);

			if (repo.Get(id) == null)
			{
				response.Success = true;
			}
			else
			{
				response.Success = false;
				response.Message = "ERROR : Static page was not removed from the database.";
				response.Payload = repo.Get(id);
			}

			return response;
		}

		public GenericResponse<StaticPage> EditStaticPage(StaticPage staticPage)
		{
			GenericResponse<StaticPage> response = new GenericResponse<StaticPage>();

			repo.Edit(staticPage);

			if (repo.Get(staticPage.Id) == staticPage)
			{
				response.Success = true;
				response.Payload = repo.Get(staticPage.Id);
			}
			else
			{
				response.Success = false;
				response.Message = "ERROR : Static Page was not updated within database.";
				response.Payload = staticPage;
			}

			return response;
		}
	}
}