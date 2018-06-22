
using CarDealerShip.Model.tables;
using CarDealerShip.Repository;
using CarDealerShip.UI.Dto;
using CarDealerShip.UI.Factory;
using CarDealerShip.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity.Owin;
using CarDealerShip.Repository.Identity;

namespace CarDealerShip.UI.Controllers
{
	[Authorize(Roles = "Admin")]
	public class AdminController : Controller
	{
		private readonly ICarDealerShipRepository<Make> makeRepo;
		private readonly IAddVehicleViewModelFactory addVehicleViewModelFactory;
		private readonly ICarDealerShipRepository<Vehicle> vehicleRepo;
		private readonly ICarDealerShipRepository<VehicleModel> modelRepo;
		private readonly IUserRepository userRepo;
		private readonly ICarDealerShipRepository<Special> specialRepo;
		private readonly IViewModelFactory viewModelFactory;
		IList<LookupModelBase> vehicleTypes = new List<LookupModelBase> { new VehicleType { Id = 1, Description = "New" }, new VehicleType { Id = 2, Description = "Used" } };
		IList<LookupModelBase> bodyStyles = new List<LookupModelBase> { new BodyStyle { Id = 1, Description = "Car" }, new BodyStyle { Id = 2, Description = "Truck" }, new BodyStyle { Id = 3, Description = "SUV" } };
		IList<LookupModelBase> transmissions = new List<LookupModelBase> { new Transmission { Id = 1, Description = "Automatic" }, new Transmission { Id = 2, Description = "Manual" } };
		IList<LookupModelBase> colors = new List<LookupModelBase> { new Color { Id = 1, Description = "Black" }, new Color { Id = 2, Description = "Red" }, new Color { Id = 3, Description = "Blue" }, new Color { Id = 4, Description = "Brown" } };
		IList<LookupModelBase> interiors = new List<LookupModelBase> { new Interior { Id = 1, Description = "Black" }, new Interior { Id = 2, Description = "Grey" }, new Interior { Id = 3, Description = "Purple" } };

		public AdminController(ICarDealerShipRepository<Make> makeRepo, IAddVehicleViewModelFactory addVehicleViewModelFactory, ICarDealerShipRepository<Vehicle> vehicleRepo, ICarDealerShipRepository<VehicleModel> modelRepo, IUserRepository userRepo, ICarDealerShipRepository<Special> specialRepo, IViewModelFactory viewModelFactory)
		{
			this.makeRepo = makeRepo;
			this.addVehicleViewModelFactory = addVehicleViewModelFactory;
			this.vehicleRepo = vehicleRepo;
			this.modelRepo = modelRepo;
			this.userRepo = userRepo;
			this.specialRepo = specialRepo;
			this.viewModelFactory = viewModelFactory;
		}

		public ActionResult AddVehicle()
		{
			ConfigureViewBag();
			var viewModel = addVehicleViewModelFactory.Create(makeRepo);
			return View(viewModel);
		}

		[HttpPost]
		public ActionResult AddVehicle(AddVehicleViewModel viewModel)
		{
			vehicleRepo.Create(viewModel.Vehicle);
			return RedirectToAction("AddVehicle");
		}

		public ActionResult GetModels(int makeId)
		{
			var results = modelRepo.GetAll().Where(p => p.MakeId == makeId).Select(p => new { Id = p.Id, Description = p.Description });

			return Json(results, JsonRequestBehavior.AllowGet);
		}

		public ActionResult EditVehicle(int vehicleId)
		{
			var vehicle = vehicleRepo.Get(vehicleId);
			ConfigureViewBag();

			return View(vehicle);
		}

		private void ConfigureViewBag()
		{
			var items = new List<SelectListItem> { new SelectListItem() };
			var makes = makeRepo.GetAll();
			items.AddRange(makes.Select(p => new SelectListItem
			{ Text = p.Description, Value = p.Id.ToString() }));
			ViewBag.AvailableMakes = items;

			ViewBag.AvailableModels = new List<SelectListItem>();
			ViewBag.AvailableTypes = GetSelectListItems(vehicleTypes);
			ViewBag.AvailableBodyStyles = GetSelectListItems(bodyStyles);
			ViewBag.AvailableTransmissions = GetSelectListItems(transmissions);
			ViewBag.AvailableColors = GetSelectListItems(colors);
			ViewBag.AvailableInteriors = GetSelectListItems(interiors);
		}
		private List<SelectListItem> GetSelectListItems(IList<LookupModelBase> source)
		{
			var items = new List<SelectListItem> { new SelectListItem() };
			items.AddRange(source.Select(p => new SelectListItem
			{ Text = p.Description, Value = p.Id.ToString() }));
			return items;
		}

		public ActionResult DeleteVehicle(int id)
		{
			vehicleRepo.Delete(id);

			return RedirectToAction("vehicles");
		}

		public ActionResult Vehicles()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Search(VehicleSearchDto searchCriteria)
		{
			var result = vehicleRepo.GetAll().Where(p => p.ModelYear.ToString() == searchCriteria.SearchTerm
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
			var modelMatch = modelRepo.GetAll().FirstOrDefault(p => p.Description.ToLower() == searchTerm.ToLower());
			if (modelMatch != null)
			{
				return vehicle.Model == modelMatch.Id;
			}
			return false;
		}

		private bool IsMakeMatch(Vehicle vehicle, string searchTerm)
		{
			return makeRepo.GetAll().Any(p => p.Description.ToLower() == searchTerm.ToLower());
		}

		public ActionResult Users()
		{
			var dbContext = HttpContext.GetOwinContext().Get<IdentityContext>();
			var users = dbContext.Users;
			return View(users);
		}

		public ActionResult AddUser()
		{
			var user = new User();
			var viewModel = viewModelFactory.Create<UserViewModel>();
			viewModel.User = user;
			return View(viewModel);
		}

		[HttpPost]
		public ActionResult AddUser(UserViewModel viewModel)
		{
			userRepo.AddUser(viewModel.User.Email, viewModel.User.Email, viewModel.User.PhoneNumber, viewModel.Password, viewModel.Role.ToString(), viewModel.User.FirstName, viewModel.User.LastName);

			return RedirectToAction("Users");
		}

		public ActionResult EditUser(int id)
		{
			var user = userRepo.GetUser(id);
			var viewModel = viewModelFactory.Create<UserViewModel>();
			var role = userRepo.GetUserRole(id);
			viewModel.Role = (Model.Enums.Roles)Enum.Parse(typeof(Model.Enums.Roles), role);
			viewModel.User = user;
			return View(viewModel);
		}

		[HttpPost]
		public ActionResult EditUser(UserViewModel viewModel)
		{
			var existingUser = userRepo.GetUser(viewModel.User.Id);
			userRepo.EditUser(existingUser, viewModel.User.UserName, viewModel.User.Email, viewModel.User.PhoneNumber, viewModel.Password, viewModel.Role.ToString(), viewModel.User.FirstName, viewModel.User.LastName);

			return RedirectToAction("Users");

		}

		public ActionResult Makes()
		{
			var makes = makeRepo.GetAll();

			return View(makes);
		}

		public ActionResult Models()
		{
			var makes = makeRepo.GetAll();
			var availableMakes = makes.Select(p => new SelectListItem { Value = p.Id.ToString(), Text = p.Description });
			var models = modelRepo.GetAll();
			var viewModels = new List<VehicleModelListViewModel>();
			foreach (var model in models)
			{
				var make = makes.First(p => p.Id == model.MakeId).Description;
				var vm = viewModelFactory.Create<VehicleModelListViewModel>();
				vm.Make = make;
				vm.Model = model.Description;
				viewModels.Add(vm);
			}
			var viewModel = viewModelFactory.Create<AddVehicleModelViewModel>();
			viewModel.VehicleModels = viewModels.OrderBy(p => p.Make).ToList();
			viewModel.AvailableMakes = availableMakes;
			return View(viewModel);
		}

		[HttpPost]
		public ActionResult Models(AddVehicleModelViewModel viewModel)
		{
			var model = new VehicleModel { Description = viewModel.VehicleModelDescription, MakeId = viewModel.MakeId };

			modelRepo.Create(model);

			return RedirectToAction("Models");
		}

		public ActionResult Specials()
		{
			var specials = specialRepo.GetAll();
			var viewModel = viewModelFactory.Create<AddSpecialViewModel>();
			viewModel.Specials = specials;

			return View(viewModel);
		}

		[HttpPost]
		public ActionResult Specials(AddSpecialViewModel viewModel)
		{
			var special = new Special { Title = viewModel.Title, Description = viewModel.Description };

			specialRepo.Create(special);

			return RedirectToAction("Specials");
		}

		public ActionResult DeleteSpecial(int id)
		{
			specialRepo.Delete(id);

			return RedirectToAction("Specials");
		}


	}
}