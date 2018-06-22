using CarDealerShip.Model;
using CarDealerShip.Model.tables;
using CarDealerShip.Repository.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

namespace CarDealerShip.UI.App_Start
{
	public class IdentityConfig
	{
		public void Configuration(IAppBuilder app)
		{
			app.CreatePerOwinContext(() => new IdentityContext());

			app.CreatePerOwinContext<ApplicationUserManager>((options, context) =>
				new ApplicationUserManager(
					new UserStore(context.Get<IdentityContext>())));

			app.CreatePerOwinContext<ApplicationRoleManager>((options, context) =>
				new ApplicationRoleManager(
					new RoleStore(context.Get<IdentityContext>())));

			app.UseCookieAuthentication(new CookieAuthenticationOptions
			{
				AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
				LoginPath = new PathString("/Account/AccessDenied"),
			});
		}
	}
}