using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System.Web.Mvc;

namespace CarDealerShip.UI.App_Start.Bootstrapper
{
	using Plumbing;

	public class ControllersInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(
				Classes.
					FromThisAssembly().
					BasedOn<IController>().
					If(c => c.Name.EndsWith("Controller")).
					LifestyleTransient());

			ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container));
		}
	}
}