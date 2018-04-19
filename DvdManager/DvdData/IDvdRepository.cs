using DvdModels;
using System.Collections.Generic;

namespace DvdData
{
	public interface IDvdRepository
	{
		List<Dvd> GetAllDvds();

		Dvd GetDvd(int id);

		List<Dvd> GetByTitle(string title);

		List<Dvd> GetByYear(int year);

		List<Dvd> GetByDirector(string directorName);

		List<Dvd> GetByRating(string rating);

		Dvd CreateDvd(Dvd dvd);

		void UpdateDvd(int id, Dvd dvd);

		void DeleteDvd(int id);
	}
}