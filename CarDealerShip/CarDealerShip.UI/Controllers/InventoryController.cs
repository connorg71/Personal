
using CarDealerShip.Model.Enums;
using CarDealerShip.Model.tables;
using CarDealerShip.Repository;
using CarDealerShip.UI.Dto;
using CarDealerShip.UI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealerShip.UI.Controllers
{

	public class InventoryController : Controller
	{
		private readonly ICarDealerShipRepository<Vehicle> vehicleRepository;
		private readonly ICarDealerShipRepository<Make> makeRepository;
		private readonly ICarDealerShipRepository<VehicleModel> modelRepository;
		private readonly ISearchHelper searchHelper;

		public InventoryController(ICarDealerShipRepository<Vehicle> vehicleRepository, ICarDealerShipRepository<Make> makeRepository, ICarDealerShipRepository<VehicleModel> modelRepository, ISearchHelper searchHelper)
		{
			this.vehicleRepository = vehicleRepository;
			this.makeRepository = makeRepository;
			this.modelRepository = modelRepository;
			this.searchHelper = searchHelper;
		}
		// GET: Inventory
		public ActionResult Details(int id)
		{
			var data = vehicleRepository.Get(id);

			return View(data);
		}

		public ActionResult New()
		{
			return View();
		}

		public ActionResult Used()
		{
			return View();
		}

		[HttpPost]
		public ActionResult New(VehicleSearchDto searchCriteria)
		{			
			var vehicleType = VehicleTypes.New;
			IEnumerable<Vehicle> result = searchHelper.Search(searchCriteria, vehicleType);
			return View("SearchResults", result);
		}

		

		[HttpPost]
		public ActionResult Used(VehicleSearchDto searchCriteria)
		{
			var vehicleType = VehicleTypes.Used;
			IEnumerable<Vehicle> result = searchHelper.Search(searchCriteria, vehicleType);
			return View("SearchResults", result);
		}

		

	}
}