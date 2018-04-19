using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameBlog.BLL.Managers;
using VideoGameBlog.Data.TestEFRepositories;
using VideoGameBlog.Models;

namespace VideoGameBlog.Tests.ManagerTests
{
    [TestFixture]
    public class StaticPageManagerTests
    {
        private StaticPageManager sut = new StaticPageManager();

        [SetUp]
        public void SetUp()
        {
            sut = new StaticPageManager();
        }
        [Test]
        public void GetAllStaticPages_Performs_Expected_Work()
        {
            SetUp();

            var expected = sut.GetAllStaticPage();

            Assert.That(expected, Is.Not.Null);
        }
        [Test]
        public void AddStaticPage_Performs_Expected_Work()
        {
            SetUp();
            StaticPage staticPage = new StaticPage();

            var expected = sut.AddStaticPagePage(staticPage);

            Assert.That(expected, Contains.Item(staticPage));
        }

       
    }
}
