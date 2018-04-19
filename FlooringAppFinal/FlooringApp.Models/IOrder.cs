using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringApp.Models
{
    public interface IOrder
    {
        List<Order> DisplayOrders(DateTime orderDate);
        Order AddOrder(Order order);
        Order LookupOrder(Order order);
        Order EditOrder(Order order);
        Order RemoveOrder(Order order);
    }
}

