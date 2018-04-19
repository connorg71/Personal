using FlooringApp.Data;
using FlooringApp.Data.Responses;
using FlooringApp.Models;
using System;
using System.Collections.Generic;

namespace FlooringApp.BLL
{
	public class OrderManager
	{
		public OrderManager(IProductFileRepository productRepository, IOrderFileRepository orderRepository)
		{
			productFileRepository = productRepository;
			orderFileRepository = orderRepository;
		}

		private IOrderFileRepository orderFileRepository;
		private IProductFileRepository productFileRepository;
		public List<Order> GetAllOrders(DateTime orderDate)
		{
			List<Order> thisOrders = new List<Order>();
			if (orderDate != null)
			{
				var orders = orderFileRepository.GetAllOrders(orderDate);
				return orders;
			}
			Console.WriteLine("error");
			return thisOrders;
		}

		public void AddOrder(DateTime orderDate, Order order)
		{
			AddOrderResponse response = new AddOrderResponse();

			//response.Order = orderFileRepository.InsertOrder(orderDate, order);

			bool isValid = false;
			if (orderDate != null && order != null)
			{

				isValid = true;
			}
			while (isValid == true)
			{
				orderFileRepository.InsertOrder(orderDate, order);
			}
		}

		public List<Product> GetAllProducts()
		{
			DisplayOrderResponse displayOrderResponse = new DisplayOrderResponse();

			var products = productFileRepository.GetAllProducts();
			return products;
		}

		public void UpdateOrder(DateTime orderDate, Order order)
		{
			AddOrderResponse addOrderResponse = new AddOrderResponse();
			
			orderFileRepository.UpdateOrder(orderDate, order);

		}

		public Order GetOrder(DateTime orderDate, int orderNumber)
		{
			DisplayOrderResponse displayOrderResponse = new DisplayOrderResponse();

			Order order = orderFileRepository.GetOrder(orderDate, orderNumber);
			return order;
		}

		public void RemoveOrder(DateTime orderDate, Order order)
		{
			DeleteOrderResponse deleteOrderResponse = new DeleteOrderResponse();

			orderFileRepository.RemoveOrder(orderDate, order);
		}

	}

}
