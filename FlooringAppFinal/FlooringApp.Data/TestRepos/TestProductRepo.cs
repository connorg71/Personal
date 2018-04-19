using FlooringApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringApp.Data.TestRepos
{
    public class TestProductRepo
    {
        string filePath = @"C:\Users\scudm\source\repos\FlooringApp\Testdata\Products.txt";
        public List<Product> GetAllProducts()
        {
            var data = File.ReadAllLines(filePath);
            List<Product> products = new List<Product>();
            for (int i = 1; i < data.Length; i++)
            {
                var product = new Product();
                var row = data[i];
                var columns = row.Split(',');
                product.ProductType = columns[0];
                product.CostPerSquareFoot = decimal.Parse(columns[1]);
                product.LaborCostPerSquareFoot = decimal.Parse(columns[2]);

                products.Add(product);
            }
            return products;
        }
    }
}
