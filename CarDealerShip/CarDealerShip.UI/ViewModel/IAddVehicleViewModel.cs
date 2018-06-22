using System.Collections.Generic;
using System.Web.Mvc;

using CarDealerShip.Model.tables;

namespace CarDealerShip.UI.ViewModel
{
	public interface IAddVehicleViewModel : IViewModel
	{		
		Vehicle Vehicle { get; set; }
	}
}