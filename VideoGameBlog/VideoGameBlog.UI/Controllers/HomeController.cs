using System;
using System.Collections.Generic;
using System.Web.Mvc;
using VideoGameBlog.BLL.InMemoryManagers;
using VideoGameBlog.BLL.Managers;
using VideoGameBlog.Models;
using VideoGameBlog.UI.Models;

namespace VideoGameBlog.UI.Controllers
{
	public class HomeController : Controller
	{
		[HttpGet]
		[AllowAnonymous]
		public ActionResult Index()
		{
			PostManager mgr = new PostManager();
			HomeIndexVM model = new HomeIndexVM();

			var allPosts = mgr.GetAllPost();

			List<ViewPostVM> list = new List<ViewPostVM>();

			foreach (var p in allPosts)
			{
				ViewPostVM post = new ViewPostVM()
				{
					PostTitle = p.PostTitle,
					PostBody = p.PostBody,
					PostId = p.Id,
					PostCategory = p.PostCategory,
					PostedDate = p.PostedDate,
					PostImageFileName = p.PostImageFileName,
					PostTags = p.PostTags
				};
				list.Add(post);
			}

			model.Posts = list;

			return View(model);
		}

		[HttpGet]
		[AllowAnonymous]
		public ActionResult ViewPost(string id)
		{
            var manager = new PostManager();
            var response = manager.GetById(int.Parse(id));

            ViewPostVM model = new ViewPostVM()
            {
                PostBody = response.Payload.PostBody,
                PostCategory = response.Payload.PostCategory,
                PostId = response.Payload.Id,
                PostTitle = response.Payload.PostTitle,
                PostTags = response.Payload.PostTags,
                PostedDate = response.Payload.PostedDate,
                PostImageFileName = response.Payload.PostImageFileName

            };

            return View(model);
            
        }

		[HttpGet]
		[AllowAnonymous]
		public ActionResult GetPostByDate()
		{
			throw new NotImplementedException();
			return View();
		}

		[HttpGet]
		[AllowAnonymous]
		public ActionResult GetPostByTitle(string title)
		{
            throw new NotImplementedException();

        }

		[HttpGet]
		[AllowAnonymous]
		public ActionResult GetPostByTag()
		{
			throw new NotImplementedException();
			return View();
		}

		[HttpGet]
		[AllowAnonymous]
		public ActionResult GetPostByCategory(Category category)
		{
            var postManager = new PostManager();
            var catManager = new CategoryManager();
            var response = postManager.GetByCategory(category);
            var model = response.Payload;
			return View(model);
		}

		[HttpGet]
		[AllowAnonymous]
		public ActionResult ContactUs()
		{
			throw new NotImplementedException();
			return View();
		}

        //[HttpPost]
        //[AllowAnonymous]
        //public ActionResult ContactUs()
        //{
        //    throw new NotImplementedException();
        //    return View();
        //}

        public ActionResult StaticPageDetails(int id)
        {
            var manager = new StaticPageManager();
            var response = manager.GetById(id);
            var model = response.Payload;

            return View(model);
        }
    }
}