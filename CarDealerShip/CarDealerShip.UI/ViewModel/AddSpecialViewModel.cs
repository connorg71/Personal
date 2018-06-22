using CarDealerShip.Model.tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealerShip.UI.ViewModel
{
	public class AddSpecialViewModel : IViewModel
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public IList<Special> Specials { get; set; }
	}
}