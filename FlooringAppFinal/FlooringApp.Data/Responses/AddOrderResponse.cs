﻿using FlooringApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringApp.Data.Responses
{
    
   public class AddOrderResponse : Response
    {
        public Order Order { get; set; }
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public string State { get; set; }
        public decimal Area { get; set; }
    }
}
