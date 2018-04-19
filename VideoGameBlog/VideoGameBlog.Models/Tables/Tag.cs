using System.Collections.Generic;

namespace VideoGameBlog.Models
{
	public class Tag : ModelBase
	{
		public string TagName { get; set; }

		public virtual ICollection<Post> Posts { get; set; }

		public Tag()
		{
			Posts = new HashSet<Post>();
		}
	}
}