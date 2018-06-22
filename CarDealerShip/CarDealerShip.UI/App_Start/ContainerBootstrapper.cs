using Castle.Facilities.TypedFactory;
using Castle.Windsor;
using Castle.Windsor.Installer;
using System;

namespace CarDealerShip.UI.App_Start
{
	public class ContainerBootstrapper : IContainerAccessor, IDisposable
	{
		private readonly IWindsorContainer container;

		private ContainerBootstrapper(IWindsorContainer container)
		{
			this.container = container;
		}

		public IWindsorContainer Container
		{
			get { return container; }
		}

		public static ContainerBootstrapper Bootstrap()
		{
			var container = new WindsorContainer().AddFacility<TypedFactoryFacility>().
				Install(FromAssembly.This());
			return new ContainerBootstrapper(container);
		}

		public void Dispose()
		{
			Container.Dispose();
		}

	}
}