using FlooringApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringApp.Data
{
    public class TaxFileRepository : ITaxFileRepository
    {
        
        private const string filePath = @"C:\Users\scudm\source\repos\FlooringApp\Flooring\Taxes.txt";
       
        public List<Tax> GetAllTaxRates()
        {
            var data = File.ReadAllLines(filePath);
            List<Tax> taxes = new List<Tax>();
            for (int i = 1; i < data.Length; i++)
            {
                var tax = new Tax();
                var row = data[i];
                var columns = row.Split(',');
                tax.StateAbbreviation = columns[0];
                tax.StateName = columns[1];
                tax.TaxRate = decimal.Parse(columns[2]);

                taxes.Add(tax);
            }
            return taxes;
        }
    }
}
