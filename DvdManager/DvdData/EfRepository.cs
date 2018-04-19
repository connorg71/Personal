using DvdModels;
using System.Collections.Generic;
using System.Linq;

namespace DvdData
{
	public class EfRepository : IDvdRepository
	{
		private DvdContext context;

		public EfRepository()
		{
			context = new DvdContext();
		}

		public Dvd CreateDvd(Dvd dvd)
		{
			var inserted = context.Dvds.Add(dvd);
			context.SaveChanges();
			return inserted;
		}

		public void DeleteDvd(int id)
		{
			var existingDvd = context.Dvds.FirstOrDefault(d => d.Id == id);
			if (existingDvd == null)
			{
				return;
			}
			context.Dvds.Remove(existingDvd);
			context.SaveChanges();
		}

		public List<Dvd> GetAllDvds()
		{
			return context.Dvds.ToList();
		}

		public List<Dvd> GetByDirector(string directorName)
		{
			return context.Dvds.Where(d => d.Director == directorName).ToList();
		}

		public List<Dvd> GetByRating(string rating)
		{
			return context.Dvds.Where(d => d.Rating == rating).ToList();
		}

		public List<Dvd> GetByTitle(string title)
		{
			return context.Dvds.Where(d => d.Title == title).ToList();
		}

		public List<Dvd> GetByYear(int year)
		{
			return context.Dvds.Where(d => d.ReleaseYear == year).ToList();
		}

		public Dvd GetDvd(int id)
		{
			return context.Dvds.FirstOrDefault(d => d.Id == id);
		}

		public void UpdateDvd(int id, Dvd dvd)
		{
			var existingDvd = context.Dvds.FirstOrDefault(d => d.Id == id);
			if (existingDvd == null)
			{
				return;
			}
			existingDvd.Director = dvd.Director;
			existingDvd.Notes = dvd.Notes;
			existingDvd.Rating = dvd.Rating;
			existingDvd.ReleaseYear = dvd.ReleaseYear;
			existingDvd.Title = dvd.Title;
			context.SaveChanges();
		}
	}
}