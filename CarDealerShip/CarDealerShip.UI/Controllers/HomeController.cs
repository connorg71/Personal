
using CarDealerShip.Model.tables;
using CarDealerShip.Repository;
using CarDealerShip.UI.ViewModel;
using System.Linq;
using System.Web.Mvc;

namespace CarDealerShip.UI.Controllers
{
	public class HomeController : Controller
	{
		private readonly ICarDealerShipRepository<Special> specialsRepository;
		private readonly ICarDealerShipRepository<Vehicle> vehicleRepository;
		private readonly ICarDealerShipRepository<ContactForm> contactRepository;

		public HomeController(ICarDealerShipRepository<Special> specialsRepository, ICarDealerShipRepository<Vehicle> vehicleRepository, ICarDealerShipRepository<ContactForm> contactRepository)
		{
			this.specialsRepository = specialsRepository;
			this.vehicleRepository = vehicleRepository;
			this.contactRepository = contactRepository;
		}

		// GET: Home
		public ActionResult Index()
		{
			var featuredVehicles = vehicleRepository.GetAll().Where(i => i.Featured == true).ToList();
			var vm = new IndexViewModel { Specials = specialsRepository.GetAll(), FeaturedVehicles = featuredVehicles };
			return View(vm);
		}

		public ActionResult Specials()
		{
			var vm = new SpecialsViewModel { Specials = specialsRepository.GetAll() };
			return View(vm);
		}

		public ActionResult Contact(string vin = null)
		{
			var data = new ContactForm();
			if (!string.IsNullOrEmpty(vin))
			{
				data.Message = vin;
			}

			return View(data);
		}

		[HttpPost]
		public ActionResult Contact(ContactForm contactForm)
		{
			contactRepository.Create(contactForm);
			return View();
		}
	}
}