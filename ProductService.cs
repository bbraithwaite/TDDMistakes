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
            return _productRepository.GetByID(id);
        }
    }
}
