using FlooringApp.Models;
using System.Collections.Generic;

namespace FlooringApp.Data
{
    public interface ITaxFileRepository
    {
        List<Tax> GetAllTaxRates();

    }
}
