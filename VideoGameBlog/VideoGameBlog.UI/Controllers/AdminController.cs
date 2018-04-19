using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Web.Mvc;
using VideoGameBlog.BLL;
using VideoGameBlog.BLL.InMemoryManagers;
using VideoGameBlog.BLL.Managers;
using VideoGameBlog.Models;
using VideoGameBlog.Models.Tables;
using VideoGameBlog.UI.Models;

namespace VideoGameBlog.UI.Controllers
{
	public class AdminController : Controller
	{
		[HttpGet]
		[Authorize(Roles = "Admin")]
		public ActionResult Index()
		{
			return View();
		}

		[HttpGet]
		[Authorize(Roles = "Admin")]
		public ActionResult StaticPages()
		{
            var mgr = new StaticPageManager();
            var response = mgr.GetAllStaticPage();
            var model = response.Payload;

            return View(model);
        }

		[HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult AddStaticPage()
		{
            StaticPageVM model = new StaticPageVM();

			return View();
		}

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult AddStaticPage(StaticPageVM model)
        {
            StaticPage sp = new StaticPage();
            var mgr = new StaticPageManager();

            sp.StaticPageTitle = model.StaticPageTitle;
            sp.StaticPageContent = model.StaticPageContent;
            sp.StaticPageImageFileName = model.StaticPageImageFileName;
            var response = mgr.AddStaticPagePage(sp);

            if (response.Success == false)
            {
                return View(model);
            }

            else
            {
                return RedirectToAction("StaticPages");
            }
        }
        
		[HttpGet]
		//[Authorize(Roles = "Admin")]
		public ActionResult EditStaticPage(int id)
		{
            var mgr = new StaticPageManager();
            var response = mgr.GetById(id);
            var sub = response.Payload;
            var model = new StaticPageVM();

            model.StaticPageId = sub.Id;
            model.StaticPageTitle = sub.StaticPageTitle;
            model.StaticPageContent = sub.StaticPageContent;
            model.StaticPageImageFileName = sub.StaticPageImageFileName;

            return View(model);
            
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public ActionResult EditStaticPage(StaticPageVM model)
        {
            if (ModelState.IsValid)
            {
                var pageMgr = new StaticPageManager();

                var sp = new StaticPage();
                sp.Id = model.StaticPageId;
                sp.StaticPageTitle = model.StaticPageTitle;
                sp.StaticPageContent = model.StaticPageContent;
                sp.StaticPageImageFileName = model.StaticPageImageFileName;

                var response = pageMgr.EditStaticPage(sp);
                if (!response.Success)
                {
                    return View(model);
                }
                else
                {
                    return RedirectToAction("StaticPages");
                }
            }

            return View();
        }
        
		[HttpPost]
		[Authorize(Roles = "Admin")]
		public ActionResult DeleteStaticPage()
		{
			throw new NotImplementedException();
			return View();
		}

		[HttpGet]
		[Authorize(Roles = "Admin")]
		public ActionResult CreatePost()
		{
			var model = new PostVM();

			model.ResetDropdown();
			return View(model);
		}

		[HttpPost]
		[Authorize(Roles = "Admin")]
		public ActionResult CreatePost(PostVM model, HttpPostedFileBase upload)
		{
			var mgr = new PostManager();
			var catManager = new CategoryManager();
			var post = new Post();

			var filePath = "~/images/";
			filePath = Server.MapPath(filePath);
			upload.SaveAs(filePath + upload.FileName);

			post.PostImageFileName = (upload.FileName);
			post.PostTitle = model.PostTitle;
			post.PostBody = model.PostBody;
			post.PostCategory = catManager.GetCategoryById(int.Parse(model.PostCategoryId)).Payload;
			post.PostTags = new List<Tag>() { new Tag() { TagName = "Test" } };

			var response = mgr.AddPost(post);
			if (response.Success == false)
			{
				throw new Exception();
			}

			model.ResetDropdown();
			return View(model);
		}

		[HttpGet]
        
		[Authorize(Roles = "Admin")]
		public ActionResult EditPost()
		{
            throw new NotImplementedException();
            return View();
        }

        //[HttpPost]
        //[Authorize(Roles = "Admin")]
        //public ActionResult EditPost()
        //{
        //    throw new NotImplementedException();
        //    return View();
        //}

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult DeletePost()
        {
            throw new NotImplementedException();
            return View();
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public ActionResult ViewSubmissions()
        {
            var mgr = new PostManager();
            var response = mgr.GetAllPost();
            List<Post> model = new List<Post>();

            foreach (var p in response)
            {
                if (p.PostState == PostState.Pending)
                    model.Add(p);
            }

			return View(model);
		}
        
        public ActionResult ReviewSubmission(int id, PostState review)
        {
            PostManager mgr = new PostManager();

			var response = mgr.GetById(id);
            
            if (response.Success)
            {
                response.Payload.PostState = review;

                var reviewResponse = mgr.EditPost(response.Payload);

                if (reviewResponse.Success)
                    return RedirectToAction("ViewSubmissions");
                else
                    throw new Exception(reviewResponse.Message);
            }
            else
                throw new Exception(response.Message);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult GetSubmissionByUser()
        {
            throw new NotImplementedException();
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult GetSubmissionByTitle()
        {
            throw new NotImplementedException();
            return View();
        }
        
        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public ActionResult Details(int id)
        {
            var mgr = new PostManager();
            var response = mgr.GetById(id);

            if (response.Success)
            {
                var model = response.Payload;

                return View(model);
            }
            else
                throw new Exception(response.Message);
        }
    }
}