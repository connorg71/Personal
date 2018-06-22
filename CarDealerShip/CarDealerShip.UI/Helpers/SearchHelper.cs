using CarDealerShip.Model.Enums;
using CarDealerShip.Model.tables;
using CarDealerShip.Repository;
using CarDealerShip.UI.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealerShip.UI.Helpers
{
	public class SearchHelper : ISearchHelper
	{
		private readonly ICarDealerShipRepository<Vehicle> vehicleRepository;
		private readonly ICarDealerShipRepository<Make> makeRepository;
		private readonly ICarDealerShipRepository<VehicleModel> modelRepository;

		public SearchHelper(ICarDealerShipRepository<Vehicle> vehicleRepository, ICarDealerShipRepository<Make> makeRepository, ICarDealerShipRepository<VehicleModel> modelRepository)
		{
			this.vehicleRepository = vehicleRepository;
			this.makeRepository = makeRepository;
			this.modelRepository = modelRepository;
		}

		public IEnumerable<Vehicle> Search(VehicleSearchDto searchCriteria, VehicleTypes vehicleType)
		{
			var maxPrice = searchCriteria.MaxPrice != 0 ? searchCriteria.MaxPrice : int.MaxValue;
			var minPrice = searchCriteria.MinPrice != 0 ? searchCriteria.MinPrice : 0;
			var maxYear = searchCriteria.MaxYear != 0 ? searchCriteria.MaxYear : int.MaxValue;
			var minYear = searchCriteria.MinYear != 0 ? searchCriteria.MinYear : 0;

			var result = vehicleRepository.GetAll().Where(p => p.Type == vehicleType).Where(p => p.ModelYear.ToString() == searchCriteria.SearchTerm
						|| IsMakeMatch(p, searchCriteria.SearchTerm)
						|| IsModelMatch(p, searchCriteria.SearchTerm)
						|| IsModelYearMatch(p, searchCriteria.SearchTerm)).Where(p => IsInPriceRange(p, minPrice, maxPrice)).Where(p => IsInModelYearRange(p, minYear, maxYear));
			//|| p.Model.ToLower() == searchCriteria.SearchTerm.ToLower());			

			
			var take = Math.Min(result.Count(), 20);
			result = result.Take(take);
			return result;
		}

		private bool IsInModelYearRange(Vehicle vehicle, int minYear, int maxYear)
		{
			return vehicle.ModelYear >= minYear && vehicle.ModelYear <= maxYear;
		}

		private bool IsInPriceRange(Vehicle vehicle, int minPrice, int maxPrice)
		{
			return vehicle.SalePrice >= minPrice && vehicle.SalePrice <= maxPrice;
		}

		private bool IsMakeMatch(Vehicle vehicle, string searchTerm)
		{
			return makeRepository.GetAll().Any(p => p.Description.ToLower().StartsWith(searchTerm.ToLower()));
		}

		private bool IsModelYearMatch(Vehicle vehicle, string searchTerm)
		{
			if (int.TryParse(searchTerm, out var parsedValue))
			{
				return vehicle.ModelYear == parsedValue;
			}
			return false;
		}

		private bool IsModelMatch(Vehicle vehicle, string searchTerm)
		{
			var modelMatch = modelRepository.GetAll().FirstOrDefault(p => p.Description.ToLower().StartsWith(searchTerm.ToLower()));
			if (modelMatch != null)
			{
				return vehicle.Model == modelMatch.Id;
			}
			return false;
		}
	}
}