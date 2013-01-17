using System;

namespace TDDMistakes
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public Product GetByID(string id)
        {
            Product product =  _productRepository.GetByID(id);

            if (product == null)
            {
                throw new ProductNotFoundException();
            }

            return product;
        }
    }
}
