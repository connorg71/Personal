using DvdData;
using DvdModels;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Web.Http;

namespace Dvd.Controllers
{
	public class DvdController : ApiController
	{
		private IDvdRepository dvdRepository;
		private RepositoryFactory repositoryFactory = new RepositoryFactory();

		public DvdController()
		{
			var repositoryType = ConfigurationManager.AppSettings["RepositoryType"];
			dvdRepository = repositoryFactory.Create(repositoryType);
		}

		[Route("dvds")]
		[HttpGet]
		public List<DvdModels.Dvd> GetAllDvds()
		{
			return dvdRepository.GetAllDvds();
		}

		[Route("dvd/{id}")]
		[HttpGet]
		public IHttpActionResult GetDvd(int id)
		{
			var data = dvdRepository.GetDvd(id);
			if (data == null)
			{
				return NotFound();
			}
			return Content(HttpStatusCode.OK, data);
		}

		[Route("dvds/title/{title}")]
		[HttpGet]
		public IHttpActionResult GetDvdsByTitle(string title)
		{
			var data = dvdRepository.GetByTitle(title);
			return Content(HttpStatusCode.OK, data);
		}

		[Route("dvds/year/{releaseYear}")]
		[HttpGet]
		public IHttpActionResult GetDvdsByYear(int year)
		{
			var data = dvdRepository.GetByYear(year);
			return Content(HttpStatusCode.OK, data);
		}

		[Route("dvds/director/{directorName}")]
		[HttpGet]
		public IHttpActionResult GetDvdsByYear(string directorName)
		{
			var data = dvdRepository.GetByDirector(directorName);
			return Content(HttpStatusCode.OK, data);
		}

		[Route("dvds/rating/{rating}")]
		[HttpGet]
		public IHttpActionResult GetDvdsByRating(string rating)
		{
			var data = dvdRepository.GetByRating(rating);
			return Content(HttpStatusCode.OK, data);
		}

		[Route("dvd")]
		[HttpPost]
		public IHttpActionResult CreateDvd(DvdModels.Dvd dvd)
		{
			var data = dvdRepository.CreateDvd(dvd);
			return Content(HttpStatusCode.OK, data);
		}

		[Route("dvd/{id}")]
		[HttpPut]
		public IHttpActionResult UpdateDvd(int id, DvdModels.Dvd dvd)
		{
			dvdRepository.UpdateDvd(id, dvd);
			return Ok();
		}

		[Route("dvd/{id}")]
		[HttpDelete]
		public IHttpActionResult DeleteDvd(int id)
		{
			dvdRepository.DeleteDvd(id);
			return Ok();
		}
	}
}