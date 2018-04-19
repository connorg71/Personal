using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace VideoGameBlog.UI.Models
{
	public class UserVM
	{
        public string Target { get; set; }
        [Required]
		public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string UserName { get; set; }
        public string RoleName { get; set; }
        public List<SelectListItem> AvailableRoles { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPasswordPrompt { get; set; }
	}
}