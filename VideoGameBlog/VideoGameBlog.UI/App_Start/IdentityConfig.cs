using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using VideoGameBlog.Data.EntityFramework.Identity;
using VideoGameBlog.Models.Identity;

namespace VideoGameBlog.UI.App_Start
{
	public class IdentityConfig
	{
		public void Configuration(IAppBuilder app)
		{
			app.CreatePerOwinContext(() => new IdentityContext());

			app.CreatePerOwinContext<UserManager<BlogUser>>((options, context) =>
				new UserManager<BlogUser>(
					new UserStore<BlogUser>(context.Get<IdentityContext>())));

			app.CreatePerOwinContext<RoleManager<BlogRole>>((options, context) =>
				new RoleManager<BlogRole>(
					new RoleStore<BlogRole>(context.Get<IdentityContext>())));

			app.UseCookieAuthentication(new CookieAuthenticationOptions
			{
				AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
				LoginPath = new PathString("/Account/AccessDenied"),
			});
		}
	}
}