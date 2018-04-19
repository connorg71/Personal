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
    public class ProductFileRepositoryTests
    {
        //Mock<IFile> mockFile;
        ProductFileRepository sut;

        [SetUp]
        public void SetUp()
        {
           // mockFile = new Mock<IFile>(MockBehavior.Strict);
            sut = new ProductFileRepository();
        }
        [Test]
        public void GetAllProducts_Always_PerformsExpectedWork()
        {
            List<string> fileData = new List<string>();
            fileData.Add("ProductType,CostPerSquareFoot,LaborCostPerSquareFoot");
            fileData.Add("Carpet,2.25,2.10");
            var expectedProduct = new Product { ProductType = "Carpet", CostPerSquareFoot = 2.25M, LaborCostPerSquareFoot = 2.10M };
            //mockFile.Setup(p => p.ReadAllLines(It.IsAny<string>())).Returns(fileData.ToArray());
            

            var result = sut.GetAllProducts();

            Assert.That(result.Count, Is.EqualTo(4));
            //var actual = result.First();
            //Assert.That(actual.ProductType, Is.EqualTo(expectedProduct.ProductType));
            //Assert.That(actual.CostPerSquareFoot, Is.EqualTo(expectedProduct.CostPerSquareFoot));
            //Assert.That(actual.LaborCostPerSquareFoot, Is.EqualTo(expectedProduct.LaborCostPerSquareFoot));
            //mockFile.VerifyAll();
        }
    }
}
