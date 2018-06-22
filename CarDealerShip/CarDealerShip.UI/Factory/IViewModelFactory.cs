using CarDealerShip.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealerShip.UI.Factory
{
	public interface IViewModelFactory
	{
		T Create<T>() where T : IViewModel;
	}
}