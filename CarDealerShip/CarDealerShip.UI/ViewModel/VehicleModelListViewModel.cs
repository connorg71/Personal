using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealerShip.UI.ViewModel
{
	public class VehicleModelListViewModel : IViewModel
	{
		public string Make { get; set; }
		public string Model { get; set; }
		
	}
}