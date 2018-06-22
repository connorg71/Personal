
using CarDealerShip.Model.tables;
using CarDealerShip.Repository;
using CarDealerShip.UI.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealerShip.UI.Controllers
{
	[Authorize(Roles = "Admin,Sales")]
	public class SalesController : Controller
	{
		private readonly Repository.ICarDealerShipRepository<Vehicle> vehicleRepository;
		private readonly ICarDealerShipRepository<Purchase> purchaseRepository;
		private readonly ICarDealerShipRepository<Make> makeRepository;
		private readonly ICarDealerShipRepository<VehicleModel> modelRepository;

		public SalesController(ICarDealerShipRepository<Vehicle> vehicleRepository, ICarDealerShipRepository<Purchase> purchaseRepository, ICarDealerShipRepository<Make> makeRepository, ICarDealerShipRepository<VehicleModel> modelRepository)
		{
			this.vehicleRepository = vehicleRepository;
			this.purchaseRepository = purchaseRepository;
			this.makeRepository = makeRepository;
			this.modelRepository = modelRepository;
		}

		// GET: Sales
		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Search(VehicleSearchDto searchCriteria)
		{
			var result = vehicleRepository.GetAll().Where(p => p.ModelYear.ToString() == searchCriteria.SearchTerm
			|| IsMakeMatch(p, searchCriteria.SearchTerm)
			|| IsModelMatch(p, searchCriteria.SearchTerm)
			|| IsModelYearMatch(p, searchCriteria.SearchTerm));
			//|| p.Model.ToLower() == searchCriteria.SearchTerm.ToLower());
			if (searchCriteria.MaxPrice != 0)
			{
				result = result.Where(p => (p.SalePrice < searchCriteria.MaxPrice && p.SalePrice > searchCriteria.MinPrice));
			}
			if (searchCriteria.MaxYear != 0)
			{
				result = result.Where(p => p.ModelYear < searchCriteria.MaxYear && p.ModelYear > searchCriteria.MinYear);
			}

			return View(result);
		}

		private bool IsMakeMatch(Vehicle vehicle, string searchTerm)
		{
			return makeRepository.GetAll().Any(p => p.Description.ToLower() == searchTerm.ToLower());
		}

		public ActionResult Purchase(int id)
		{
			var result = new PurchaseDto
			{
				Id = id
			};

			return View(result);
		}

		[HttpPost]
		public ActionResult Purchase(PurchaseDto dto)
		{
			var model = new Purchase();

			model.City = dto.City;
			model.Email = dto.Email;
			model.Phone = dto.Phone;
			model.PurchaseType = dto.PurchaseType;
			model.SalePrice = dto.SalePrice;
			model.SalesPersonId = dto.SalesPersonId;
			model.State = dto.State;
			model.Street1 = dto.Street1;
			model.Street2 = dto.Street2;
			model.ZipCode = dto.ZipCode;
			model.VehicleId = dto.Id;

			model.PurchaseDate = DateTime.Today;

			purchaseRepository.Create(model);
			var vehicle = vehicleRepository.Get(dto.Id);
			vehicle.Sold = true;
			vehicleRepository.Update(vehicle);

			return View();
		}

		private bool IsModelYearMatch(Vehicle vehicle, string searchTerm)
		{
			if (int.TryParse(searchTerm, out var parsedValue))
			{
				return vehicle.ModelYear == parsedValue;
			}
			return false;
		}

		private bool IsModelMatch(Vehicle vehicle, string searchTerm)
		{
			var modelMatch = modelRepository.GetAll().FirstOrDefault(p => p.Description.ToLower() == searchTerm.ToLower());
			if (modelMatch != null)
			{
				return vehicle.Model == modelMatch.Id;
			}
			return false;
		}
	}
}