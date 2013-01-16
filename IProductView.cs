using System;

namespace TDDMistakes
{
    public interface IProductView
    {
        string ProductID { get; }
        Product Product { get; set; }
        bool IsInBasket { get; set; }
    }
}
