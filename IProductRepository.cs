using System;
using System.Collections.Generic;

namespace TDDMistakes
{
    public interface IProductRepository
    {
       Product GetByID(string id);
       IEnumerable<Product> GetProducts();
    }
}
