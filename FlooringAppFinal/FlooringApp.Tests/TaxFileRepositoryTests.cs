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
    public class TaxFileRepositoryTests
    {
        //Mock<IFile> mockFile;
        TaxFileRepository sut;

        [SetUp]
        public void SetUp()
        {
            //mockFile = new Mock<IFile>(MockBehavior.Strict);
            sut = new TaxFileRepository();
        }
        [Test]
        public void GetAllTaxRates_Always_PerformsExpectedWork()
        {
            List<string> fileData = new List<string>();
            fileData.Add("StateAbbreviation,StateName,TaxRate");
            fileData.Add("OH,Ohio,6.25");
            var expectedTax = new Tax { StateAbbreviation = "OH", StateName = "Ohio", TaxRate = 6.25M};
            //mockFile.Setup(p => p.ReadAllLines(It.IsAny<string>())).Returns(fileData.ToArray());

            var result = sut.GetAllTaxRates();

            Assert.That(result.Count, Is.EqualTo(4));
            var actual = result.First();
            Assert.That(actual.StateName, Is.EqualTo(expectedTax.StateName));
            Assert.That(actual.StateAbbreviation, Is.EqualTo(expectedTax.StateAbbreviation));
            Assert.That(actual.TaxRate, Is.EqualTo(expectedTax.TaxRate));
            //mockFile.VerifyAll();
        }
    }
}
