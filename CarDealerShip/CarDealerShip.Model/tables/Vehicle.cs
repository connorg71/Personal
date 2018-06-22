using CarDealerShip.Model.Enums;

namespace CarDealerShip.Model.tables
{
	public class Vehicle : ModelBase
	{
		public int ModelYear { get; set; }
		public double SalePrice { get; set; }
		public bool Featured { get; set; }
		public bool Sold { get; set; }
		public string Vin { get; set; }
		public int Make { get; set; }
		public int Model { get; set; }
		public VehicleTypes Type { get; set; }
		public int BodyStyle { get; set; }
		public int Transmission { get; set; }
		public int Color { get; set; }
		public int Interior { get; set; }
		public double Mileage { get; set; }
		public double MSRP { get; set; }
		public string Description { get; set; }
		public string PictureUrl { get; set; }


	}
}