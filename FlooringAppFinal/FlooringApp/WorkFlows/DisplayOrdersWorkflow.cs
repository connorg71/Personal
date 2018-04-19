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
   public class DisplayOrdersWorkflow
    {
        private static Product product = new Product();
        private static ConsoleIO consoleIo = new ConsoleIO();
        //private static FileImpl fileImpl = new FileImpl();
        private static TaxFileRepository taxFileRepository = new TaxFileRepository();
        private static ProductFileRepository productFileRepository = new ProductFileRepository();
        private static OrderFileRepository orderFileRepository = new OrderFileRepository();
        //private static OrderCalculator calculator = new OrderCalculator(taxFileRepository);
        private static OrderManager orderManager = new OrderManager(productFileRepository, orderFileRepository);

        public void DisplayOrders()
        {
            Console.WriteLine("Please enter the date for your orders");
            var input = Console.ReadLine();
            bool dateParse = DateTime.TryParse(input, out DateTime orderDate);
            if (dateParse == true)
            {
                var orders = orderManager.GetAllOrders(orderDate);
                if (orders.Count == 0)
                {
                    Console.WriteLine("no orders to display");
                    Console.ReadKey();
                    return;
                }
                foreach (var order in orders)
                {
                    consoleIo.DisplayOrderDetails(order);
                }
            }
            else
            {
                Console.WriteLine("invalid date format");
            }
            Console.ReadKey();

        }
    }
}
