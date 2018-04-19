using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using VideoGameBlog.BLL.InMemoryManagers;
using VideoGameBlog.Data.TestEFRepositories;

namespace VideoGameBlog.UI.Models
{
	public class SubmissionVM
	{
		public string SubmissionId { get; set; }

		[Required(ErrorMessage = "Please enter a title for your submission.")]
		public string SubmissionTitle { get; set; }

		[AllowHtml]
		public string SubmissionBody { get; set; }

		public string SubmissionImageFileName { get; set; }

		[Required(ErrorMessage = "Please enter a category for your submission.")]
		public string SubmissionCategoryId { get; set; }

		public IEnumerable<SelectListItem> AvailableCategories { get; set; }
		public string SubmissionTags { get; set; }

		public void ResetDropdown()
		{
			CategoryManager mgr = new CategoryManager();

			List<SelectListItem> list = new List<SelectListItem>();

			SelectListItem placeholder = new SelectListItem()
			{
				Text = "Select Category",
				Value = ""
			};

			if (SubmissionCategoryId == null)
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

				if (SubmissionCategoryId != null && SubmissionCategoryId == c.Id.ToString())
				{
					item.Selected = true;
				}

				list.Add(item);
			}

			AvailableCategories = list;
		}
	}
}