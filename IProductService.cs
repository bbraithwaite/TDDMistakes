using System;

namespace TDDMistakes
{
    public interface IProductService
    {
        Product GetByID(string id);
    }
}
