using FlooringApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringApp.Data
{
   public interface IProductFileRepository
    {
        List<Product> GetAllProducts();
    }
}
