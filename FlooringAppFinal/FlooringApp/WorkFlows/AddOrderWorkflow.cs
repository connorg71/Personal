using FlooringApp.BLL;
using FlooringApp.Data;
using FlooringApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringApp.WorkFlows
{
   public class AddOrderWorkflow
    {
        private static Product product = new Product();
        private static ConsoleIO consoleIo = new ConsoleIO();
        //private static FileImpl fileImpl = new FileImpl();
        private static TaxFileRepository taxFileRepository = new TaxFileRepository();
        private static ProductFileRepository productFileRepository = new ProductFileRepository();
        private static OrderFileRepository orderFileRepository = new OrderFileRepository();
        //private static OrderCalculator calculator = new OrderCalculator(taxFileRepository);
        private static OrderManager orderManager = new OrderManager(productFileRepository, orderFileRepository);

        public void AddOrder()
        {
            var order = new Order();
            var products = orderManager.GetAllProducts();

            Console.WriteLine("Please enter the date of your order");
            string input = Console.ReadLine();
            DateTime orderDate = DateTime.Parse(input);

            Console.WriteLine("Please enter the customers name");
            input = Console.ReadLine();
            order.CustomerName = input;

            Console.WriteLine("Please enter the state of your order");
            input = Console.ReadLine();
            //validate that state exists i tax file
            order.State = input;

            Console.WriteLine("Please enter the product type, below are our options: ");
            foreach (var product in products)
            {
                consoleIo.DisplayProductDetails(product);
            }
            input = Console.ReadLine();
            order.ProductType = Console.ReadLine();

            Console.WriteLine("Please enter the area with a minimum of 100sq ft");
            input = Console.ReadLine();
            order.Area = decimal.Parse(input);

            consoleIo.DisplayOrderDetails(order);
            Console.WriteLine("would you like to save and place this order? \"Y/N\"");
            input = Console.ReadLine();
            if (input.ToLower() == "y")
            {
                orderManager.AddOrder(orderDate, order);
            }
            else
            {
                return;
            }


        }
    }
}
