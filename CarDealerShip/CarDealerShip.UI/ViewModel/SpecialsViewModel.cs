
using CarDealerShip.Model.tables;
using System.Collections.Generic;

namespace CarDealerShip.UI.ViewModel
{
	public class SpecialsViewModel : IViewModel
	{
		public IList<Special> Specials { get; set; }
	}
}