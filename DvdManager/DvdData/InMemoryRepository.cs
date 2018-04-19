using DvdModels;
using System.Collections.Generic;
using System.Linq;

namespace DvdData
{
	public class InMemoryRepository : IDvdRepository	
	{
		private static List<Dvd> Dvds = new List<Dvd>
		{
			new Dvd{ Director = "Director1", Id = 1, Notes = "Goodmovie", Rating = "PG", ReleaseYear = 2016, Title = "Movie1"  },
			new Dvd{ Director = "Director2", Id = 2, Notes = "BadMovie", Rating = "R", ReleaseYear = 2017, Title = "Movie2"  }
		};

		public Dvd CreateDvd(Dvd dvd)
		{
			var newId = Dvds.Max(d => d.Id) + 1;
			dvd.Id = newId;
			Dvds.Add(dvd);
			return dvd;
		}

		public void DeleteDvd(int id)
		{
			var existingDvd = Dvds.FirstOrDefault(d => d.Id == id);
			if (existingDvd == null)
			{
				return;
			}
			Dvds.Remove(existingDvd);
		}

		public List<Dvd> GetAllDvds()
		{
			return Dvds;
		}

		public List<Dvd> GetByDirector(string directorName)
		{
			return Dvds.Where(d => d.Director == directorName).ToList();
		}

		public List<Dvd> GetByRating(string rating)
		{
			return Dvds.Where(d => d.Rating == rating).ToList();
		}

		public List<Dvd> GetByTitle(string title)
		{
			return Dvds.Where(d => d.Title == title).ToList();
		}

		public List<Dvd> GetByYear(int year)
		{
			return Dvds.Where(d => d.ReleaseYear == year).ToList();
		}

		public Dvd GetDvd(int id)
		{
			return Dvds.FirstOrDefault(d => d.Id == id);
		}

		public void UpdateDvd(int id, Dvd dvd)
		{
			var existingDvd = Dvds.FirstOrDefault(d => d.Id == id);
			if (existingDvd == null)
			{
				return;
			}
			existingDvd.Director = dvd.Director;
			existingDvd.Notes = dvd.Notes;
			existingDvd.Rating = dvd.Rating;
			existingDvd.ReleaseYear = dvd.ReleaseYear;
			existingDvd.Title = dvd.Title;
		}
	}
}