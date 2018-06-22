using CarDealerShip.Model.Enums;
using CarDealerShip.Model.tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealerShip.UI.ViewModel
{ 
	public class UserViewModel : IViewModel
	{
		public User User { get; set; }
		public Roles Role { get; set; }
		public string Password { get; set; }
	}
}