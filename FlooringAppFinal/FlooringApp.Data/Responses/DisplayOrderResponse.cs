using FlooringApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringApp.Data.Responses
{
   public class DisplayOrderResponse : Response
    {

        public Order Order { get; set; }

    }
}
