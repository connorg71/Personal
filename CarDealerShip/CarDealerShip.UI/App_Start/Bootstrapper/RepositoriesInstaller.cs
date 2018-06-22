
using CarDealerShip.Model.tables;
using CarDealerShip.Repository;
using CarDealerShip.Repository.EntityFramework;
using CarDealerShip.Repository.InMemory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System.Configuration;

namespace CarDealerShip.UI.App_Start.Bootstrapper
{
	public class RepositoriesInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			var mode = ConfigurationManager.AppSettings["Mode"];
			container.Register(Component.For<IUserRepository>().ImplementedBy<UserRepository>());

			if (mode == "QA")
			{
				//container.Register(Classes.FromAssemblyNamed("CarDealerShip.Repository").Where(Component.IsInNamespace("CarDealerShip.Repository.InMemory")).BasedOn<IRepository>().WithServiceAllInterfaces());
				container.Register(Component.For<ICarDealerShipRepository<Special>>().ImplementedBy<InMemorySpecialsRepository>());
				container.Register(Component.For<ICarDealerShipRepository<Vehicle>>().ImplementedBy<InMemoryVehicleRepository>());
				container.Register(Component.For<ICarDealerShipRepository<ContactForm>>().ImplementedBy<InMemoryContactFormRepository>());
				container.Register(Component.For<ICarDealerShipRepository<Purchase>>().ImplementedBy<InMemoryPurchaseRepository>());
				container.Register(Component.For<ICarDealerShipRepository<Make>>().ImplementedBy<InMemoryMakeRepository>());
				container.Register(Component.For<ICarDealerShipRepository<VehicleModel>>().ImplementedBy<InMemoryVehicleModelRepository>());
				
				//container.Register(Component.For<ICarDealerShipRepository<User>>().ImplementedBy<InMemoryUserRepository>());


			}
			else if(mode == "PROD")
			{
				container.Register(Component.For<ICarDealerShipRepository<ContactForm>>().ImplementedBy<EntityContactFormRepository>());
				container.Register(Component.For<ICarDealerShipRepository<Make>>().ImplementedBy<EntityMakeRepository>());
				container.Register(Component.For<ICarDealerShipRepository<Purchase>>().ImplementedBy<EntityPurchaseRepository>());
				container.Register(Component.For<ICarDealerShipRepository<Special>>().ImplementedBy<EntitySpecialsRepository>());
				container.Register(Component.For<ICarDealerShipRepository<VehicleModel>>().ImplementedBy<EntityVehicleModelRepository>());
				container.Register(Component.For<ICarDealerShipRepository<Vehicle>>().ImplementedBy<EntityVehicleRepository>());
			}
		}
	}
}