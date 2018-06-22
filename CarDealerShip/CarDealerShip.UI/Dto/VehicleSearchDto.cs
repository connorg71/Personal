using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealerShip.UI.Dto
{
	public class VehicleSearchDto
	{
		public string SearchTerm { get; set; }
		public int MinPrice { get; set; }
		public int MaxPrice { get; set; }
		public int MinYear { get; set; }
		public int MaxYear { get; set; }
	}
}