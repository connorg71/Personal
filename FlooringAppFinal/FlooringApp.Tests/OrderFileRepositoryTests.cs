using FlooringApp.Data;
using FlooringApp.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringApp.Tests
{
    [TestFixture]
    public class OrderFileRepositoryTests

    {
        [SetUp]
        public void SetUp()
        {
           var sut = new OrderFileRepository();

            List<string> fileData = new List<string>();
            var filePath = @"C:\Users\scudm\source\repos\FlooringApp\Flooring\Orders_{0}.txt";
            var testFile = @"C:\Users\scudm\Desktop\TestFile.txt";
            File.Copy(filePath, testFile);
        }

        //[Test]
        //public void GetOrder_Always_PerformsExpectedWork()
        //{
        //    var sut = new OrderFileRepository();
            
        //    var orderDate = DateTime.Today;
        //    var orderNumber = 1;
            

        //    var result = sut.GetOrder(orderDate, orderNumber);

        //    Assert.That(result, Is.Not.Null);
        //}
        //[Test]
        //public void InsertOrder_Always_PerformsExpectedWork()
        //{
        //    var sut = new OrderFileRepository();

        //    var order = new Order();
        //    var orderDate = DateTime.Today;
       
        //    sut.InsertOrder(orderDate, order);
           
        //}
        //[Test]
        //public void RemoveOrder_Always_PerformsExpectedWork()
        //{
        //    var sut = new OrderFileRepository();
        //    var order = new Order();
        //    var orderDate = DateTime.Today;
       

        //    sut.RemoveOrder(orderDate, order);
        //    //mockFile.VerifyAll();
        //}
        //[Test]
        //public void UpdateOrder_Always_PerformsExpectedWork()
        //{
        //    var sut = new OrderFileRepository();
        //    var order = new Order();
        //    var orderDate = DateTime.Today;
         

        //    sut.UpdateOrder(orderDate, order);
        //    //mockFile.VerifyAll();
        //}
        //[Test]
        //public void GetAllOrders_Always_PerformsExpectedWork()
        //{
        //    var sut = new OrderFileRepository();
        //    //var expectedOrder = new Order();
        //    var orderDate = DateTime.Today;
                      

        //    var result = sut.GetAllOrders(orderDate);
        //    Assert.That(result.Count, Is.EqualTo(2));
        //}
    }
}
