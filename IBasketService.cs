using System;

namespace TDDMistakes
{
    public interface IBasketService
    {
        bool ProductExists(string productID);
    }
}
