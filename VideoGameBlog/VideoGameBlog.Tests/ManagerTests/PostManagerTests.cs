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
    public class PostManagerTests
    {
        private PostManager sut = new PostManager();

        [SetUp]
        public void SetUp()
        {
            sut = new PostManager();
        }
        [Test]
        public void GetAllPosts_Performs_Expected_Work()
        {
            SetUp();

            var expected = sut.GetAllPost();

            Assert.That(expected, Is.Not.Null);
        }
        [Test]
        public void AddPost_Performs_Expected_Work()
        {
            SetUp();
            Post post = new Post();

            var expected = sut.AddPost(post);

            Assert.That(expected, Contains.Item(post));
        }

        [Test]
        public void GetPostById_Performs_Expected_Work()
        {
            SetUp();
            Post post = new Post();
            sut.AddPost(post);

            var expected = sut.GetById(post.Id);


            Assert.That(expected, Contains.Item(post));
        }
    }
}

