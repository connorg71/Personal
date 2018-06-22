using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealerShip.UI.ViewModel
{
	public interface IAddVehicleModelViewModel : IViewModel
	{
		IList<VehicleModelListViewModel> VehicleModels { get; set; }
		string VehicleModelDescription { get; set; }
		int MakeId { get; set; }
	}
}