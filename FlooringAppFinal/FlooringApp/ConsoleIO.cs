using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringApp.Models;

namespace FlooringApp
{
    class ConsoleIO
    {
        public void DisplayOrderDetails(Order order)
        {
            Console.WriteLine($"Order Number: {order.OrderNumber}");
            Console.WriteLine($"Customer Name: {order.CustomerName}");
            Console.WriteLine($"State: {order.State}");
            Console.WriteLine($"Taxrate: {order.TaxRate}");
            Console.WriteLine($"Product Type: {order.ProductType}");
            Console.WriteLine($"Area: {order.Area}");
            Console.WriteLine($"Cost Per Square Foot: {order.CostPerSquareFoot:c}");
            Console.WriteLine($"Labour Cost Per Square Foot: {order.LaborCostPerSquareFoot:c}");
            Console.WriteLine($"Matierial Cost: {order.MaterialCost:c}");
            Console.WriteLine($"Labour Cost: {order.LaborCost:c}");
            Console.WriteLine($"Tax: {order.Tax:c}");
            Console.WriteLine($"Total: {order.Total:c}");
        }
        public void DisplayProductDetails(Product product)
        {
            Console.WriteLine($"Product: {product.ProductType}");
            Console.WriteLine($"Cost Per Square Foot: {product.CostPerSquareFoot}");
            Console.WriteLine($"Labour Cost Per Square Foot: {product.LaborCostPerSquareFoot}");
            Console.WriteLine();
        }
    }
}
