using CarDealerShip.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealerShip.UI.Dto
{
	public class PurchaseDto
	{
		public int Id { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public string Street1 { get; set; }
		public string Street2 { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string ZipCode { get; set; }
		public double SalePrice { get; set; }
		public int SalesPersonId { get; set; }
		public PurchaseTypes PurchaseType { get; set; }
	}
}