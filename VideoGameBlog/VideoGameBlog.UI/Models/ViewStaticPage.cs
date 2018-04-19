using System.Web.Mvc;

namespace VideoGameBlog.UI.Models
{
	public class ViewStaticPage
	{
		public string Title { get; set; }

		[AllowHtml]
		public string Content { get; set; }

		public string Image { get; set; }
	}
}