using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;

namespace TDDMistakes._1
{
    [TestClass]
    public class Solution
    {
        [TestMethod]
        public void GetProductWithValidIDReturnsProduct()
        {
            // Arrange
            IProductRepository productRepository = Mock.Create<IProductRepository>();
            Mock.Arrange(() => productRepository.GetByID("spr-product")).Returns(new Product());
            ProductService productService = new ProductService(productRepository);

            // Act
            Product product = productService.GetByID("spr-product");

            // Assert
            Assert.IsNotNull(product);
        }

        [TestMethod]
        public void GetProductWithInValidIDReturnsNull()
        {
            // Arrange
            IProductRepository productRepository = Mock.Create<IProductRepository>();
            ProductService productService = new ProductService(productRepository);

            // Act
            Product product = productService.GetByID("invalid-id");

            // Assert
            Assert.IsNull(product);
        }
    }
}