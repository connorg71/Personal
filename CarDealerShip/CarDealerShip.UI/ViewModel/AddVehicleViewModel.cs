
using CarDealerShip.Model.tables;
using CarDealerShip.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealerShip.UI.ViewModel
{
	public class AddVehicleViewModel : IAddVehicleViewModel
	{
		public Vehicle Vehicle { get; set; }
	}
}