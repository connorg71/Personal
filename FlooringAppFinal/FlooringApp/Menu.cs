using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringApp.BLL;
using FlooringApp.Data;
using FlooringApp.Models;
using FlooringApp.WorkFlows;

namespace FlooringApp.UI
{
    class Menu
    {     
        private static DisplayOrdersWorkflow displayOrdersWorkflow = new DisplayOrdersWorkflow();
        private static EditOrderWorkflow editOrderWorkflow = new EditOrderWorkflow();
        private static AddOrderWorkflow addOrderWorkflow = new AddOrderWorkflow();
        private static RemoveOrderWorkflow removeOrderWorkflow = new RemoveOrderWorkflow();
        public static void start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Flooring Orders Application");
                Console.WriteLine("------------------------");
                Console.WriteLine("1. Display Orders");
                Console.WriteLine("2. Add an Order");
                Console.WriteLine("3. Edit an Order");
                Console.WriteLine("4. Remove an Order");

                Console.WriteLine("\nQ to quit");
                Console.Write("\nEnter selection: ");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        DisplayOrders();
                        break;
                    case "2":
                        AddOrder();
                        break;
                    case "3":
                        EditOrder();
                        break;
                    case "4":
                        RemoveOrder();
                        break;
                    case "Q":
                    case "q":
                        return;
                }
            }
        }

        private static void DisplayOrders()
        {
            displayOrdersWorkflow.DisplayOrders();
        }
        private static void AddOrder()
        {
            addOrderWorkflow.AddOrder();
        }
        private static void EditOrder()
        {
            editOrderWorkflow.EditOrder();            
        }
        private static void RemoveOrder()
        {
            removeOrderWorkflow.RemoveOrder();            
        }
    }
}
