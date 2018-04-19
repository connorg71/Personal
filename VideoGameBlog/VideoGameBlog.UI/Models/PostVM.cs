using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using VideoGameBlog.BLL.InMemoryManagers;
using VideoGameBlog.Data.TestEFRepositories;
using VideoGameBlog.Models;

namespace VideoGameBlog.UI.Models
{
	public class PostVM
	{
		public int PostId { get; set; }

		[Required(ErrorMessage = "Please enter a title for your post.")]
		public string PostTitle { get; set; }

		[AllowHtml]
		public string PostBody { get; set; }

		public DateTime PostedDate { get; set; }
		public string PostImageFileName { get; set; }

		[Required(ErrorMessage = "Please select a category for your post.")]
		public string PostCategoryId { get; set; }

		public List<SelectListItem> AvailableCategories { get; set; }
		public string NewCategory { get; set; }
		public IEnumerable<Tag> PostTags { get; set; }

		public void ResetDropdown()
		{
			CategoryManager mgr = new CategoryManager();

			List<SelectListItem> list = new List<SelectListItem>();

			SelectListItem placeholder = new SelectListItem()
			{
				Text = "Select Category",
				Value = ""
			};

			if (PostCategoryId == null)
			{
				placeholder.Selected = true;
			}

			foreach (var c in mgr.GetAllCategories())
			{
				SelectListItem item = new SelectListItem()
				{
					Text = c.CategoryName,
					Value = c.Id.ToString()
				};

				if (PostCategoryId != null && PostCategoryId == c.Id.ToString())
				{
					item.Selected = true;
				}

				list.Add(item);
			}

			AvailableCategories = list;
		}

	}
}