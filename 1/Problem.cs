using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MSTestExtensions;

namespace TDDMistakes._1
{
    [TestClass]
    public class Problem : BaseTest
    {
        [TestMethod]
        public void GetProductWithValidIDReturnsProduct()
        {
            // Arrange
            IProductRepository productRepository = new FakeProductRepository();
            ProductService productService = new ProductService(productRepository);

            // Act
            Product product = productService.GetByID("spr-product");

            // Assert
            Assert.IsNotNull(product);
        }

        [TestMethod]
        public void GetProductWithInValidIDThrowsException()
        {
            // Arrange
            IProductRepository productRepository = new FakeProductRepository();
            ProductService productService = new ProductService(productRepository);

            // Act & Assert
            Assert.Throws<ProductNotFoundException>(() => productService.GetByID("invalid-id"));
        }

        class ValidProductRepository : IProductRepository
        {
            public Product GetByID(string id)
            {
                return new Product()
                {
                    ID = "spr-product",
                    Name = "Nice Product"
                };
            }

            public IEnumerable<Product> GetProducts()
            {
                throw new NotImplementedException();
            }
        }

        class InValidProductRepository : IProductRepository
        {
            public Product GetByID(string id)
            {
                return null;
            }

            public IEnumerable<Product> GetProducts()
            {
                throw new NotImplementedException();
            }
        }

        class FakeProductRepository : IProductRepository
        {
            public Product GetByID(string id)
            {
                if (id == "spr-product")
                {
                    return new Product()
                    {
                        ID = "spr-product",
                        Name = "Nice Product"
                    };
                }

                return null;
            }

            public IEnumerable<Product> GetProducts()
            {
                throw new NotImplementedException();
            }
        }
    }
}