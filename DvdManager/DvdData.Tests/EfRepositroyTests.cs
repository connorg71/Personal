using DvdModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace DvdData.Tests
{
	[TestFixture]
	internal class EfRepositroyTests
	{
		private EfRepository sut;

		//IDvdRepository sut = new EfRepository();
		private Mock<IDvdRepository> mockdvdRepositroy;

		[SetUp]
		public void Setup()
		{
			mockdvdRepositroy = new Mock<IDvdRepository>();
			sut = new EfRepository();
		}

		[Test]
		public void DeleteDvdPerformsExpectedWork()
		{
			//arange
			Dvd dvd = new Dvd();
			var dvdId = 5;
			//act
			sut.DeleteDvd(dvdId);
			//assert
			Assert.That(dvd != null);
		}

		[Test]
		public void GetAllDvdsPerformsExpectedWork()
		{
			//arrange
			Dvd dvd = new Dvd();
			dvd.Id = 7;
		}

		////arrange
		//Order order = new Order();
		//var orderDate = DateTime.Today;
		//var orderNumber = 5;
		//mockOrderRepository.Setup(p => p.GetOrder(orderDate, orderNumber)).Returns(order);
		////act
		//var result = sut.GetOrder(orderDate, orderNumber);
		////assert
		//Assert.That(result, Is.SameAs(order));
		//	mockProductRepository.VerifyAll();
	}
}