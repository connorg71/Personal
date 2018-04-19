using FlooringApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringApp.Data.TestRepos
{
    public class TestOrderRepo : IOrderFileRepository
    {
        private const string ColumnHeaders = "OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total";
        string filePath = @"C:\Users\scudm\source\repos\FlooringApp\Testdata\";
        string file = @"C:\Users\scudm\source\repos\FlooringApp\Flooring\Orders_{0}.txt";
        string newfolder = @"C:\Users\scudm\source\repos\FlooringApp\TestData\New";

        public Order GetOrder(DateTime orderDate, int orderNumber)
        {
            var orders = GetAllOrders(orderDate);
            var order = orders.FirstOrDefault(p => p.OrderNumber == orderNumber);
            return order;
        }
        public List<Order> GetAllOrders(DateTime orderDate)
        {
            var fileName = GenerateFileName(orderDate);
            List<Order> orders = new List<Order>();
            if (File.Exists(fileName))
            {
                string[] rows = File.ReadAllLines(fileName);

                for (var index = 1; index < rows.Length; index++)
                {
                    var row = rows[index];
                    var order = MapOrder(row);
                    orders.Add(order);
                }
                return orders;
            }
            else
            {
                Console.WriteLine("No accounts for that date");
                return orders;
            }






        }
        private Order MapOrder(string row)
        {
            string[] columns = row.Split(',');
            var order = new Order();
            order.OrderNumber = int.Parse(columns[0]);
            order.CustomerName = columns[1];
            order.State = columns[2];
            order.TaxRate = decimal.Parse(columns[3]);
            order.ProductType = columns[4];
            order.Area = decimal.Parse(columns[5]);
            order.CostPerSquareFoot = decimal.Parse(columns[6]);
            order.LaborCostPerSquareFoot = decimal.Parse(columns[7]);

            return order;
        }
        public void InsertOrder(DateTime orderDate, Order order)
        {
            var orders = GetAllOrders(orderDate);
            var orderId = orders.Max(i => i.OrderNumber) + 1;
            order.OrderNumber = orderId;
            orders.Add(order);
            WriteOrders(orderDate, orders);
        }

        private void WriteOrders(DateTime orderDate, List<Order> orders)
        {
            var fileName = GenerateFileName(orderDate);
            List<string> fileData = new List<string>();
            fileData.Add(ColumnHeaders);
            fileData.AddRange(orders.Select(p => p.ToString()));
            File.WriteAllLines(fileName, fileData);
        }
        private string GenerateFileName(DateTime orderDate)
        {
            return string.Format(filePath, orderDate.ToString("MMddyyyy"));
        }
        public void UpdateOrder(DateTime orderDate, Order order)
        {

            var orders = GetAllOrders(orderDate);
            //add validtaion for nonexistant order
            var oldOrder = orders.FirstOrDefault(p => p.OrderNumber == order.OrderNumber);
            orders.Remove(oldOrder);
            orders.Add(order);
            WriteOrders(orderDate, orders);
        }
        public void RemoveOrder(DateTime orderDate, Order order)
        {
            if (orderDate != null && order != null)
            {
                var orders = GetAllOrders(orderDate);
                var oldOrder = orders.FirstOrDefault(p => p.OrderNumber == order.OrderNumber);
                orders.Remove(oldOrder);
                WriteOrders(orderDate, orders);
            }
        }
    }
}
