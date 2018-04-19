using DvdModels;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace DvdData.Tests
{
	[TestFixture]
	public class InMemoryRepoTests
	{
		//public void SetUp()
		//{
		//	IDvdRepository repository = new InMemoryRepository();
		//	List<Dvd> dvds = new List<Dvd>();
		//	Dvd dvd = new Dvd();

		//}
		Mock<IDvdRepository> mockRepo;
		InMemoryRepository sut;
		[TestCase(1)]
		public void DeleteDvdWorks()
		{
			//mockRepo = new Mock<InMemoryRepository>();
			//IDvdRepository repository = new InMemoryRepository();
			
			Dvd dvd = new Dvd
			{
				Id = 5,
				Director = "MovieMachine6",
				Notes = "too much acting",
				Rating = "R",
				ReleaseYear = 2005,
				Title = "Batman 15 Return of batman"				
			};
			sut.CreateDvd(dvd);
			sut.DeleteDvd(5);
			List<Dvd> dvds = sut.GetAllDvds();
			Assert.IsFalse(dvds.Contains(dvd));
		}
		[Test]
		public void CreateDvdPerformsExpectedWork()
		{
			IDvdRepository repository = new InMemoryRepository();
			List<Dvd> dvds = new List<Dvd>();
			Dvd dvd = new Dvd();
			repository.CreateDvd(dvd);
			Assert.That(dvds.Contains(dvd));
		}
		[Test]
		public void GetDvdPerformsExpectedWork()
		{
			IDvdRepository repository = new InMemoryRepository();
			Dvd dvd = new Dvd() { Director = "DirectorTronFive", Id = 6, Notes = "moving pictures", Rating = "R", ReleaseYear = 2055, Title = "SpaceMovie" };
			var GotDvd = repository.GetDvd(dvd.Id);
			Assert.AreSame(dvd, GotDvd);
		}
		[Test]
		public void GetDvdByDiectorPerformsExpectedWork()
		{			
			//List<Dvd> gottedDvds = new List<Dvd>();
			Dvd dvd = new Dvd() { Director = "movieguy7", Id = 9, Notes = "movie is good", Rating = "PG", ReleaseYear = 2004, Title = "thisMovie" };
			sut.CreateDvd(dvd);
			//List<Dvd> gottedDvds = sut.GetByDirector("movieguy7");
			Dvd gettedDvd = sut.GetDvd(9);


			Assert.AreSame(gettedDvd.Director, "movieguy7");
		}
	}
	}