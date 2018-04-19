using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace VideoGameBlog.UI.Models
{
	public class StaticPageVM
	{
		public int StaticPageId { get; set; }

		[Required(ErrorMessage = "Please enter a title for your static page.")]
		public string StaticPageTitle { get; set; }

		[AllowHtml]
		public string StaticPageContent { get; set; }

		public string StaticPageImageFileName { get; set; }
	}
}