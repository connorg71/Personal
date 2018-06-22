using Castle.Windsor;
using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace CarDealerShip.UI.Plumbing
{
	public class WindsorControllerFactory : DefaultControllerFactory
	{
		private readonly IWindsorContainer container;

		public WindsorControllerFactory(IWindsorContainer container)
		{
			this.container = container;
		}

		protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
		{
			if (controllerType != null && container.Kernel.HasComponent(controllerType))
				return (IController)container.Resolve(controllerType);

			return base.GetControllerInstance(requestContext, controllerType);
		}

		public override void ReleaseController(IController controller)
		{
			container.Release(controller);
		}
	}
}