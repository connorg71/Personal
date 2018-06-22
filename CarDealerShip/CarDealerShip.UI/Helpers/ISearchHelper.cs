using System.Collections.Generic;
using CarDealerShip.Model.Enums;
using CarDealerShip.Model.tables;
using CarDealerShip.UI.Dto;

namespace CarDealerShip.UI.Helpers
{
	public interface ISearchHelper
	{
		IEnumerable<Vehicle> Search(VehicleSearchDto searchCriteria, VehicleTypes vehicleType);
	}
}