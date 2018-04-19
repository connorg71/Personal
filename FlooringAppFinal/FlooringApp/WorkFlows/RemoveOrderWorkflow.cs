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
    public class RemoveOrderWorkflow
    {
        private static Product product = new Product();
        private static ConsoleIO consoleIo = new ConsoleIO();
        //private static FileImpl fileImpl = new FileImpl();
        private static TaxFileRepository taxFileRepository = new TaxFileRepository();
        private static ProductFileRepository productFileRepository = new ProductFileRepository();
        private static OrderFileRepository orderFileRepository = new OrderFileRepository();
        //private static OrderCalculator calculator = new OrderCalculator(taxFileRepository);
        private static OrderManager orderManager = new OrderManager(productFileRepository, orderFileRepository);


        public void RemoveOrder()
        {
            Console.WriteLine("enter order date");
            var input = Console.ReadLine();
            DateTime orderDate = DateTime.Parse(input);
            var orders = orderManager.GetAllOrders(orderDate);

            Console.WriteLine("enter order number");
            input = Console.ReadLine();
            var orderNumber = int.Parse(input);

            var order = orderManager.GetOrder(orderDate, orderNumber);

            if (order == null)
            {
                return;
            }
            else
            {
                Console.WriteLine("would you like to delete this order? \"Y/N\"");
                input = Console.ReadLine();
                if (input.ToLower() == "n")
                {
                    return;
                }

            }
            orderManager.RemoveOrder(orderDate, order);

        }
    }
}
