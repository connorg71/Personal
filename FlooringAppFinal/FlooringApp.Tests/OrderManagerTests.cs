using FlooringApp.BLL;
using FlooringApp.Data;
using FlooringApp.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringApp.Tests
{
    [TestFixture]
   public class OrderManagerTests
    {
        OrderManager sut;
        //Mock<IOrderCalculator> mockCalculator;
        Mock<IProductFileRepository> mockProductRepository;
        Mock<IOrderFileRepository> mockOrderRepository;
        [SetUp]
        public void SetUp()
        {
            mockProductRepository = new Mock<IProductFileRepository>(MockBehavior.Strict);
            //mockCalculator = new Mock<IOrderCalculator>(MockBehavior.Strict);
            mockOrderRepository = new Mock<IOrderFileRepository>();
            sut = new OrderManager(mockProductRepository.Object, mockOrderRepository.Object);
        }
        [Test]
        public void GetAllProducts_Always_PerformsExpectedWork()
        {
            //arrange
            List<Product> products = new List<Product>();
            mockProductRepository.Setup(p => p.GetAllProducts()).Returns(products);
            //act
            var result = sut.GetAllProducts();
            //assert
            Assert.That(result, Is.SameAs(products));
            mockProductRepository.VerifyAll();
        }
        [Test]
        public void GetAllOrders_Always_PerformsExpectedWork()
        {
            //arrange
            List<Order> orders = new List<Order>();
            var orderDate = DateTime.Today;
            mockOrderRepository.Setup(p => p.GetAllOrders(orderDate)).Returns(orders);
            //act
            var result = sut.GetAllOrders(orderDate);
            //assert
            Assert.That(result, Is.SameAs(orders));
           // mockProductRepository.VerifyAll();
        }
        [Test]
        public void GetOrder_Always_PerformsExpectedWork()
        {
			//arrange
			Order order = new Order();
			var orderDate = DateTime.Today;
			var orderNumber = 5;
			mockOrderRepository.Setup(p => p.GetOrder(orderDate, orderNumber)).Returns(order);
			//act
			var result = sut.GetOrder(orderDate, orderNumber);
			//assert
			Assert.That(result, Is.SameAs(order));
			mockProductRepository.VerifyAll();
		}
        [Test]
        public void AddOrder_Always_PerformsExpectedWork()
        {
            //arrange
            Order order = new Order();
            var orderDate = DateTime.Today;            
            mockOrderRepository.Setup(p => p.InsertOrder(orderDate, order));
            //act
            sut.AddOrder(orderDate, order);            
            //assert            
            mockProductRepository.VerifyAll();

        }
        [Test]
        public void RemoveOrder_Always_PerformsExpectedWork()
        {
			//arrange
			Order order = new Order();
			var orderDate = DateTime.Today;
			mockOrderRepository.Setup(p => p.RemoveOrder(orderDate, order));
			//act
			sut.RemoveOrder(orderDate, order);
			//assert            
			mockProductRepository.VerifyAll();
			Assert.That(order != null);
		}
        [Test]
        public void UpdateOrder_Always_PerformsExpectedWork()
        {
            //arrange
            Order order = new Order();
            var orderDate = DateTime.Today;
           //mockCalculator.Setup(p => p.Calculate(order)).Returns(order);
            mockOrderRepository.Setup(p => p.UpdateOrder(orderDate, order));
            //act
            sut.UpdateOrder(orderDate, order);
            //assert            
            mockProductRepository.VerifyAll();
        }

    }
}
