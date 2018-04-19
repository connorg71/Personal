using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using VideoGameBlog.Data;
using VideoGameBlog.Data.InMemory;
using VideoGameBlog.Models;

namespace VideoGameBlog.Tests.MockTests
{
	[TestFixture]
	public class MockTests
	{
		[Test]
		public void CanGetStaticPageById()
		{
			var repo = new InMemoryStaticPageRepository();

			var sp = repo.Get(1);

			Assert.AreEqual(sp.Id, 1);
			Assert.AreEqual(sp.StaticPageTitle, "a page with a picture of master chief");
			Assert.AreEqual(sp.StaticPageContent, "video game blog faq");
			Assert.AreEqual(sp.StaticPageImageFileName, "masterchief.jpg");
		}

		[Test]
		public void CanGetAllStaticPages()
		{
			var repo = new InMemoryStaticPageRepository();

			var list = repo.GetAll();

			Assert.AreEqual(4, list.Count);
		}

		[Test]
		public void CanAddStaticPage()
		{
			var repo = new InMemoryStaticPageRepository();
			StaticPage sp = new StaticPage();

			sp.StaticPageTitle = "Test Page Title";
			sp.StaticPageImageFileName = "placeholder.png";
			sp.StaticPageContent = "This is content for a static page.";

			repo.Add(sp);

			var list = repo.GetAll();
			var staticPage = repo.Get(4);

			Assert.AreEqual(list.Count, 4);
			Assert.AreEqual(staticPage.Id, 4);
			Assert.AreEqual(staticPage.StaticPageTitle, "Test Page Title");
			Assert.AreEqual(staticPage.StaticPageImageFileName, "placeholder.png");
			Assert.AreEqual(staticPage.StaticPageContent, "This is content for a static page.");
		}

		[Test]
		public void CanDeleteStaticPage()
		{
			var repo = new InMemoryStaticPageRepository();
			StaticPage sp = new StaticPage();

			sp.StaticPageTitle = "Test Page Title Two";
			sp.StaticPageImageFileName = "placeholder2.png";
			sp.StaticPageContent = "This is content for a second test static page.";

			repo.Add(sp);

			Assert.IsNotNull(repo.Get(5));
			Assert.AreEqual(repo.Get(5).StaticPageContent, "This is content for a second test static page.");

			repo.Delete(5);

			Assert.IsNull(repo.Get(5));
		}

		[Test]
		public void CanUpdateStaticPage()
		{
			var repo = new InMemoryStaticPageRepository();

			var sp = repo.Get(4);
			sp.StaticPageContent = "This static page has been updated.";
			sp.StaticPageImageFileName = "placeholderUpdate.png";
			sp.StaticPageTitle = "Updated Static Page";

			repo.Edit(sp);

			Assert.AreEqual(repo.Get(4).StaticPageContent, "This static page has been updated.");
			Assert.AreEqual(repo.Get(4).StaticPageTitle, "Updated Static Page");
			Assert.AreEqual(repo.Get(4).StaticPageImageFileName, "placeholderUpdate.png");
		}

		[Test]
		public void CanAddTag()
		{
			var repo = new InMemoryTagRepository();
			Tag tag = new Tag();

			tag.TagName = "Test Test";

			repo.Add(tag);

			var list = repo.GetAll();
			var newTag = repo.Get(5);

			Assert.AreEqual(list.Count, 5);
			Assert.AreEqual(newTag.TagName, "Test Test");
		}

		[Test]
		public void CanAddPost()
		{
			var repo = new InMemoryPostRepository();
			var post = new Post();
			var cat = new Category();
			cat.CategoryName = "New Category for Testing!";
			var tagsList = new List<Tag>();
			var tag1 = new Tag();
			var tag2 = new Tag();
			tagsList.Add(tag1);
			tagsList.Add(tag2);

			post.PostTitle = "New Post";
			post.PostBody = "This is a shiny new post. Isn't it a beaut?";
			post.PostedDate = DateTime.Today;
			post.PostCategory = cat;
			post.PostTags = tagsList;

			repo.Add(post);

			Assert.AreEqual(4, repo.GetAll().Count);
			Assert.AreEqual("New Post", repo.Get(4).PostTitle);
			Assert.AreEqual("This is a shiny new post. Isn't it a beaut?", repo.Get(4).PostBody);
			Assert.AreEqual(DateTime.Today, repo.Get(4).PostedDate);
			Assert.AreEqual(cat.CategoryName, repo.Get(4).PostCategory.CategoryName);
			Assert.AreEqual(2, repo.Get(4).PostTags.Count());
		}

		[Test]
		public void CanDeletePost()
		{
			var repo = new InMemoryPostRepository();

			Assert.IsNotNull(repo.Get(3));

			repo.Delete(3);

			Assert.IsNull(repo.Get(3));
		}

		[Test]
		public void CanGetAllPosts()
		{
			var repo = new InMemoryPostRepository();

			var list = repo.GetAll();

			Assert.IsNotNull(list);
		}

		[Test]
		public void CanGetPostById()
		{
			var repo = new InMemoryPostRepository();

			Assert.IsNotNull(repo.Get(2));
		}
	}
}