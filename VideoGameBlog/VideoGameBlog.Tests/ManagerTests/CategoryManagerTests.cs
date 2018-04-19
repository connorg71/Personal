using NUnit.Framework;
using Moq;
using VideoGameBlog.BLL;
using VideoGameBlog.BLL.InMemoryManagers;
using VideoGameBlog.Data.TestEFRepositories;
using VideoGameBlog.Models;

namespace VideoGameBlog.Tests.ManagerTests
{
	[TestFixture]
	public class CategoryManagerTests
	{
		private CategoryManager sut = new CategoryManager();

		[SetUp]
		public void SetUp()
		{
			sut = new CategoryManager();
		}

		[Test]
		public void GetAllCategories_Performs_Expected_Work()
		{
			SetUp();

			var expected = sut.GetAllCategories();

			Assert.That(expected, Is.Not.Null);
		}

		[Test]
		public void AddCategory_Performs_Expected_Work()
		{
			SetUp();
			Category category = new Category();

			var expected = sut.AddCategory(category);

			Assert.That(expected, Contains.Item(category));
		}

		[Test]
		public void GetCategoryById_Performs_Expected_Work()
		{
			SetUp();
			Category category = new Category();
			sut.AddCategory(category);

			var expected = sut.GetCategoryById(category.Id);


			Assert.That(expected, Contains.Item(category));

		}
	}
}