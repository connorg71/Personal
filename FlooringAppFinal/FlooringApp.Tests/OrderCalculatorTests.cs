using FlooringApp.BLL;
using FlooringApp.Data;
using FlooringApp.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

//namespace FlooringApp.Tests
//{
//    [TestFixture]
//    public class OrderCalculatorTests
//    {
//        OrderCalculator sut;
//        Mock<ITaxFileRepository> mockRepository;
//        [SetUp]
//        public void SetUp()
//        {
//            mockRepository = new Mock<ITaxFileRepository>(MockBehavior.Strict);
//            sut = new OrderCalculator(mockRepository.Object);
//        }
//        [TestCase(120, 10, 10, "CT", .1)]
//        [TestCase(120, 20, 20, "NY", .2)]
//        public void Calculate_Always_ReturnsExpectedValue(int area, int labour, int material, string state, decimal taxRate)

//        {
//            //arrange
//            Order order = new Order
//            {
//                Area = area,
//                LaborCostPerSquareFoot = labour,
//                CostPerSquareFoot = material,
//                State = state
//            };

//            var expectedLabourCost = labour * area;
//            var expectedMaterialCost = material * area;
//            var expectedTax = (expectedMaterialCost + expectedLabourCost) * (taxRate / 100);
//            var expectedTaxrate = taxRate;
//            var expectedTotal = (expectedTax + expectedLabourCost + expectedMaterialCost);

//            var taxData = new List<Tax>();
//            taxData.Add(new Tax { StateAbbreviation = state, TaxRate = taxRate });
//            mockRepository.Setup(p => p.GetAllTaxRates()).Returns(taxData);

//            //act
//            var result = sut.Calculate(order);
//            //assert
//            Assert.That(order.LaborCost, Is.EqualTo(expectedLabourCost));
//            Assert.That(order.MaterialCost, Is.EqualTo(expectedMaterialCost));
//            Assert.That(order.Tax, Is.EqualTo(expectedTax));
//            Assert.That(order.TaxRate, Is.EqualTo(expectedTaxrate));
//            Assert.That(order.Total, Is.EqualTo(expectedTotal));

//        }
//    }
//}
