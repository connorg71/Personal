using CarDealerShip.Model;
using CarDealerShip.Model.tables;
using CarDealerShip.Repository;
using CarDealerShip.UI.Dto;
using CarDealerShip.UI.Factory;
using CarDealerShip.UI.ViewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace CarDealerShip.UI.Controllers
{
    public class AccountController : Controller
    {
		private readonly IUserRepository userRepo;
		private readonly IViewModelFactory viewModelFactory;

		public AccountController(IUserRepository userRepo, IViewModelFactory viewModelFactory)
		{
			this.userRepo = userRepo;
			this.viewModelFactory = viewModelFactory;
		}
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }


		public ActionResult ChangePassword()
		{
			//TO DO: CAN ONLY CHANGE OWN PASSWORD
			var dto = new ChangePasswordDto();
			return View(dto);
		}

		[HttpPost]
		public ActionResult ChangePassword(ChangePasswordDto dto)
		{
			var user = userRepo.GetUser(5);
			if (dto.Password != dto.Confirm)
			{
				ModelState.AddModelError("Password", "Password Do Not Match!");
				return View(dto);
			}			
			userRepo.UpdatePassword(5, dto.CurrentPassword, dto.Password);
			return View();
		}

		[AllowAnonymous]
		public ActionResult Login()
		{
			var viewModel = viewModelFactory.Create<ILoginViewModel>();

			return View(viewModel);
		}

		[ValidateAntiForgeryToken]
		[AllowAnonymous]
		[HttpPost]
		public ActionResult Login(LoginViewModel model, string returnUrl)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
			var authManager = HttpContext.GetOwinContext().Authentication;

			// attempt to load the user with this password
			User user = userManager.Find(model.UserName, model.Password);

			// user will be null if the password or user name is bad
			if (user == null)
			{
				ModelState.AddModelError("", "Invalid username or password");

				return View(model);
			}
			else
			{
				// successful login, set up their cookies and send them on their way
				var identity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
				authManager.SignIn(new AuthenticationProperties(), identity);

				if (!string.IsNullOrEmpty(returnUrl))
				{
					return Redirect(returnUrl);
				}
				else
				{
					if (userManager.IsInRole(user.Id, "Disabled"))
					{
						return RedirectToAction("AccountDisabled");
					}
					else
					{
						return RedirectToAction("Index", "Home");
					}
				}
			}
		}
		[HttpGet]
		[AllowAnonymous]
		public ActionResult AccessDenied()
		{
			return View();
		}
	}
}