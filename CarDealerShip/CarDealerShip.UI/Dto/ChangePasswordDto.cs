using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarDealerShip.UI.Dto
{
	public class ChangePasswordDto
	{
		[Required]
		public string CurrentPassword { get; set; }
		[Required]
		public string Password { get; set; }
		[Required]
		public string Confirm { get; set; }
	}
}