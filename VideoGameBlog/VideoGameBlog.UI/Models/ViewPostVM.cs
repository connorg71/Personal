using System;
using System.Collections.Generic;
using System.Web.Mvc;
using VideoGameBlog.Models;

namespace VideoGameBlog.UI.Models
{
	public class ViewPostVM
	{
		public int PostId { get; set; }
		public string PostTitle { get; set; }

		[AllowHtml]
		public string PostBody { get; set; }

		public DateTime PostedDate { get; set; }
		public string PostImageFileName { get; set; }
		public Category PostCategory { get; set; }
		public IEnumerable<Tag> PostTags { get; set; }
	}
}