using System;
using System.Collections.Generic;
using System.Web.Mvc;
using VideoGameBlog.BLL;
using VideoGameBlog.BLL.InMemoryManagers;
using VideoGameBlog.BLL.Managers;
using VideoGameBlog.Data.TestEFRepositories;
using VideoGameBlog.Models;
using VideoGameBlog.Models.Tables;
using VideoGameBlog.UI.Models;

namespace VideoGameBlog.UI.Controllers
{
    public class MarketingController : Controller
    {
        [HttpGet]
        //[Authorize(Roles = "Marketing")]
        public ActionResult ViewSubmissions()
        {
            var mgr = new PostManager();

            List<Post> model = new List<Post>();

            var response = mgr.GetAllPost();

            foreach (var p in response)
            {
                if (p.Username == User.Identity.Name)
                    model.Add(p);
            }

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Marketing")]
        public ActionResult CreateSubmission()
        {
            var model = new SubmissionVM();

            model.ResetDropdown();
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Marketing")]
        public ActionResult CreateSubmission(SubmissionVM model)
        {
            var mgr = new PostManager();
            var catManager = new CategoryManager();
            var sub = new Post();

            sub.PostTitle = model.SubmissionTitle;
            sub.PostBody = model.SubmissionBody;
            sub.PostCategory = catManager.GetCategoryById(int.Parse(model.SubmissionCategoryId)).Payload;
            sub.PostImageFileName = "placeholder.png";
            sub.PostTags = new List<Tag>() { new Tag() { TagName = "Test" } };
            sub.PostState = PostState.Pending;
            sub.Username = User.Identity.Name;
            var response = mgr.AddPost(sub);
            if (response.Success == false)
            {
                throw new Exception();
            }

            model.ResetDropdown();
            return View(model);
        }

        //[HttpPost]
        //[Authorize(Roles = "Marketing")]
        //public ActionResult CreateSubmission()
        //{
        //    throw new NotImplementedException();
        //    return View();
        //}

        [HttpGet]
        //[Authorize(Roles = "Marketing")]
        public ActionResult EditSubmission(int id)
        {
            PostManager repo = new PostManager();

            var response = repo.GetById(id);

            if (!response.Success)
                throw new Exception(response.Message);

            SubmissionVM model = new SubmissionVM();
            model.ResetDropdown();
            model.SubmissionId = response.Payload.Id.ToString();
            model.SubmissionTitle = response.Payload.PostTitle;
            model.SubmissionBody = response.Payload.PostBody;
            model.SubmissionCategoryId = response.Payload.PostCategory.Id.ToString();
            model.SubmissionImageFileName = response.Payload.PostImageFileName;

            string tags = "";

            foreach (Tag t in response.Payload.PostTags)
            {
                tags += "#" + t.TagName + " ";
            }

            model.SubmissionTags = tags;

            return View(model);
        }

        [HttpPost]
        //[Authorize(Roles = "Marketing")]
        public ActionResult EditSubmission(SubmissionVM model)
        {
            if (ModelState.IsValid)
            {
                var postMgr = new PostManager();
                var catMgr = new CategoryManager();
                var tagMgr = new TagManager();
                
                var editTarget = postMgr.GetById(int.Parse(model.SubmissionId));
                //sub.Id = int.Parse(model.SubmissionId);
                editTarget.Payload.PostTitle = model.SubmissionTitle;
                editTarget.Payload.PostBody = model.SubmissionBody;
                editTarget.Payload.PostImageFileName = model.SubmissionImageFileName;

                var catResponse = catMgr.GetCategoryById(int.Parse(model.SubmissionCategoryId));

                if (catResponse.Success)
                    editTarget.Payload.PostCategory = catResponse.Payload;
                else
                    throw new Exception(catResponse.Message);

                var tagResponse = tagMgr.ConvertTagStringToList(model.SubmissionTags);

                if (tagResponse.Success)
                {
                    var tagList = new List<Tag>();

                    foreach (var t in tagResponse.Payload)
                    {
                        t.Posts.Add(editTarget.Payload);
                        tagMgr.AddTag(t);
                        tagList.Add(t);
                    }

                    editTarget.Payload.PostTags = tagList;
                }
                else
                    throw new Exception();

                editTarget.Payload.PostState = PostState.Pending;
                editTarget.Payload.Username = User.Identity.Name;

                var subResponse = postMgr.EditPost(editTarget.Payload);

                if (subResponse.Success)
                    return RedirectToAction("ViewSubmissions");
                else
                    throw new Exception(subResponse.Message);
            }
            else
                return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "Marketing")]
        public ActionResult DeleteSubmission(int id)
        {
            var mgr = new PostManager();
            var response = mgr.DeletePost(id);
            if (response.Success)
                return RedirectToAction("ViewSubmissions");
            else
                throw new Exception(response.Message);//return View(response);
        }
    }
}