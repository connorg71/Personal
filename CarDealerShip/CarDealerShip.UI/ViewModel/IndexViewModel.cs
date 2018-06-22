
using CarDealerShip.Model.tables;
using System.Collections.Generic;

namespace CarDealerShip.UI.ViewModel
{
	public class IndexViewModel : IViewModel
	{
		public IList<Special> Specials { get; set; }
		public IList<Vehicle> FeaturedVehicles { get; set; }
	}
}