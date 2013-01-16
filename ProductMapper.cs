using System;

namespace TDDMistakes
{
    public class ProductMapper
    {
        internal Product Map(ProductDto productDto)
        {
            var product = new Product()
            { 
                ID = productDto.ID,
                Name = productDto.ProductName,
                BasePrice = productDto.Price
            };

            return product;
        }
    }
}
