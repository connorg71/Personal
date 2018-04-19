using System;
using System.Collections.Generic;
using VideoGameBlog.Models.Tables;

namespace VideoGameBlog.Models
{
	public class Post : ModelBase
	{
		public string PostTitle { get; set; }
		public string PostBody { get; set; }
		public DateTime PostedDate { get; set; }
		public string PostImageFileName { get; set; }
		public Category PostCategory { get; set; }
        public PostState PostState { get; set; }
        public string Username { get; set; }

		public virtual ICollection<Tag> PostTags { get; set; }

        public Post()
        {
            PostTags = new HashSet<Tag>();
        }
    }
}