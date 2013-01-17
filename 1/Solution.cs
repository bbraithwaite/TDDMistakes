using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;
using MSTestExtensions;

namespace TDDMistakes._1
{
    [TestClass]
    public class Solution : BaseTest
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
        public void GetProductWithInValidIDThrowsException()
        {
            // Arrange
            IProductRepository productRepository = Mock.Create<IProductRepository>();
            ProductService productService = new ProductService(productRepository);

            // Act & Assert
            Assert.Throws<ProductNotFoundException>(() => productService.GetByID("invalid-id"));
        }
    }
}