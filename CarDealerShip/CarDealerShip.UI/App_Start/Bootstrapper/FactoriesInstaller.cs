using CarDealerShip.UI.Factory;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealerShip.UI.App_Start.Bootstrapper
{
	public class FactoriesInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(Component.For<IAddVehicleViewModelFactory>().AsFactory());
			container.Register(Component.For<IViewModelFactory>().AsFactory());
		}
	}
}