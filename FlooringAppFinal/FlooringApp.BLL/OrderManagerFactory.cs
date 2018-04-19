using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using FlooringApp.Data;
using FlooringApp.Data.TestRepos;

namespace FlooringApp.BLL
{
    public static class OrderManagerFactory
    {
        
        public static OrderManager Create()
        {            
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();


            //return new OrderManager();
            //return new OrderManager(new TestOrderRepo(), new TestProductRepo());
            throw new NotImplementedException();
        }
    }
}

