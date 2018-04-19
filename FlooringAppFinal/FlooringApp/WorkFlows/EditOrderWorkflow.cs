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
  public class EditOrderWorkflow
    {
        private static Product product = new Product();
        private static ConsoleIO consoleIo = new ConsoleIO();
        //private static FileImpl fileImpl = new FileImpl();
        private static TaxFileRepository taxFileRepository = new TaxFileRepository();
        private static ProductFileRepository productFileRepository = new ProductFileRepository();
        private static OrderFileRepository orderFileRepository = new OrderFileRepository();
        //private static OrderCalculator calculator = new OrderCalculator(taxFileRepository);
        private static OrderManager orderManager = new OrderManager(productFileRepository, orderFileRepository);

        public void EditOrder()
        {

            Console.WriteLine("enter order date");
            var input = Console.ReadLine();
            DateTime orderDate = DateTime.Parse(input);
            var orders = orderManager.GetAllOrders(orderDate);

            Console.WriteLine("enter order number");
            input = Console.ReadLine();
            var orderNumber = int.Parse(input);

            var order = orders.FirstOrDefault(p => p.OrderNumber == orderNumber);

            Console.WriteLine("customer name: {0}", order.CustomerName);
            input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input) && input != order.CustomerName)
            {
                order.CustomerName = input;
            }
            Console.WriteLine("state: {0}", order.State);
            input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input) && input != order.State)
            {
                order.State = input;
            }
            Console.WriteLine("product type: {0}", order.ProductType);
            input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input) && input != order.ProductType)
            {
                order.ProductType = input;
            }
            Console.WriteLine("area: {0}", order.Area);
            input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input) && input != order.Area.ToString())
            {
                var area = decimal.Parse(input);
                order.Area = area;
            }
            orderManager.UpdateOrder(orderDate, order);

        }
    }
}
