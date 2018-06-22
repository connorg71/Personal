using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(CarDealerShip.UI.App_Start.WindsorActivator), "PreStart")]
[assembly: ApplicationShutdownMethodAttribute(typeof(CarDealerShip.UI.App_Start.WindsorActivator), "Shutdown")]

namespace CarDealerShip.UI.App_Start
{
	public static class WindsorActivator
	{
		private static ContainerBootstrapper bootstrapper;

		public static void PreStart()
		{
			bootstrapper = ContainerBootstrapper.Bootstrap();
		}

		public static void Shutdown()
		{
			if (bootstrapper != null)
				bootstrapper.Dispose();
		}
	}
}