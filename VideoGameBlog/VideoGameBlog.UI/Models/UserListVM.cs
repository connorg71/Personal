using System.Collections.Generic;
using VideoGameBlog.Models.Identity;

namespace VideoGameBlog.UI.Models
{
	public class UserListVM
	{
		public List<BlogUser> Users { get; set; }
		public List<BlogRole> Roles { get; set; }
	}
}