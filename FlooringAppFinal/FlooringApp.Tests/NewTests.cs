using FlooringApp.BLL;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringApp.BLL;

namespace FlooringApp.Tests
{
    [TestFixture]
    class NewTests
    {

        string filePath = @"C:\Users\scudm\source\repos\FlooringApp\Testdata\";
        string file = @"C:\Users\scudm\source\repos\FlooringApp\Flooring\Orders_06012013.txt";
        string newfolder = @"C:\Users\scudm\source\repos\FlooringApp\TestData\New";

        [SetUp]
        public void SetUp()
        {
            foreach (string file in Directory.GetFiles(filePath))
            {
                File.Delete(file);
            }

            //foreach (string file in Directory.GetFiles(newfolder))
            //{
            //    File.Delete(file);
            //}

            File.Copy(file, filePath + "Orders_06012013.txt");
            //File.Copy(file, filePath + "Orders_06012013.txt");

            //OrderManager orderManager = new OrderManager()
            //OrderManagerFactory.Create();
        }
        [Test]
        public void Test()
        {
            //SetUp();
            string a = "a";
            string b = "a";
            Assert.That(file == file);
        }
        [Test]
        public void Test2()
        {
            SetUp();            
        }

        

        
    }
}
