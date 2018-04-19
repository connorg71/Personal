using System;
using System.Collections.Generic;
using FlooringApp.Models;

namespace FlooringApp.Data
{
    public interface IOrderFileRepository
    {
        void InsertOrder(DateTime orderDate, Order order);
        List<Order> GetAllOrders(DateTime orderDate);
        Order GetOrder(DateTime orderDate, int orderNumber);
        void RemoveOrder(DateTime orderDate, Order order);
        void UpdateOrder(DateTime orderDate, Order order);
    }
}