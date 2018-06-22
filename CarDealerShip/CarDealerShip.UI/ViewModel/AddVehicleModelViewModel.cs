using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealerShip.UI.ViewModel
{
	public class AddVehicleModelViewModel : IAddVehicleModelViewModel
	{
		public IList<VehicleModelListViewModel> VehicleModels { get; set; }
		public string VehicleModelDescription { get; set; }
		public int MakeId { get; set; }
		public IEnumerable<SelectListItem> AvailableMakes { get; set; }
	}
}