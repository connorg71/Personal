using System.Collections;
using System.Collections.Generic;

namespace VideoGameBlog.Models
{
	public class StaticPage : ModelBase
	{
		public string StaticPageContent { get; set; }
		public string StaticPageTitle { get; set; }
		public string StaticPageImageFileName { get; set; }
	}
}