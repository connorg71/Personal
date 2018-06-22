using CarDealerShip.Model.tables;
using CarDealerShip.Repository;
using CarDealerShip.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerShip.UI.Factory
{
	public interface IAddVehicleViewModelFactory
	{
		IAddVehicleViewModel Create(ICarDealerShipRepository<Make> makeRepo);
	}
}
