using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using VideoGameBlog.BLL;
using VideoGameBlog.Data.TestEFRepositories;
using VideoGameBlog.Models;

namespace VideoGameBlog.Tests.ManagerTests
{
	[TestFixture]
	public class SubmissionManagerTests
	{
		private SubmissionManager sut = new SubmissionManager();
		private Mock<SubmissionRepository> mockRepo = new Mock<SubmissionRepository>();

		[SetUp]
		public void Setup()
		{
			sut = new SubmissionManager();
			mockRepo = new Mock<SubmissionRepository>();
		}

		[Test]
		public void GetAllSubmisions_Performs_Expected_Work()
		{
			//arrange
			Setup();
			List<Submission> submissions = new List<Submission>();
			//act
			var result = sut.GetAllSubmissions();
			//assert
			Assert.That(result, Is.SameAs(submissions));
		}

		[Test]
		public void AddSubmission_Performs_Expected_Work()
		{
			Setup();
			List<Submission> submissions = new List<Submission>();
			Submission submission = new Submission();

			sut.AddSubmission(submission);
			var expected = sut.GetById(submission.Id);

			Assert.That(submission, Is.SameAs(expected));
		}

		[Test]
		public void EditSubmission_Performs_Expected_Work()
		{
			Setup();
			var submissions = sut.GetAllSubmissions();
			Submission submission = new Submission();
			submission.Id = 12;
			submission.SubmissionBody = "bodeh";

			sut.EditSubmission(submission);

			Assert.That(submission, Is.Not.Null);
			//finish this
		}

		[Test]
		public void GetById_Performs_Expected_Work()
		{
			Setup();
			Submission submission = new Submission();
			submission.Id = 8;

			var expected = sut.GetById(8);

			Assert.That(expected, Is.SameAs(submission));
		}

		[Test]
		public void DeleteSubmision_Performs_Expected_Work()
		{
			Setup();
			Submission submission = new Submission();

			sut.DeleteSubmission(submission.Id);

			Assert.That(submission, Does.Not.Exist);
		}
	}
}