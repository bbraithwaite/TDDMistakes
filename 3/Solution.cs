using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TDDMistakes._3
{
    [TestClass]
    public class Solution
    {
        [TestMethod]
        public void CalculateDiscountedPriceReturnsAmountOf11()
        {
            // Arrange
            var product = new Product()
            {
                BasePrice = 10m
            };

            // Act
            decimal discountPrice = product.CalculatePrice(CalculationRules.Discounted);

            // Assert
            Assert.AreEqual(11m, discountPrice);
        }

        [TestMethod]
        public void CalculateStandardPriceReturnsAmountOf12()
        {
            // Arrange
            var product = new Product()
            {
                BasePrice = 10m
            };

            // Act
            decimal standardPrice = product.CalculatePrice(CalculationRules.Standard);

            // Assert
            Assert.AreEqual(12m, standardPrice);
        }

        [TestMethod]
        public void NoDiscountRuleReturnsBasePrice()
        {
            // Arrange
            var product = new Product()
            {
                BasePrice = 10m
            };

            // Act
            decimal basePrice = product.CalculatePrice(CalculationRules.None);

            // Assert
            Assert.AreEqual(10m, basePrice);
        }

        [TestMethod]
        public void ProductMapperMapsToExpectedProperties()
        {
            // Arrange
            var mapper = new ProductMapper();
            var productDto = new ProductDto()
            {
                ID = "sp-001",
                Price = 10m,
                ProductName = "Super Product"
            };

            // Act
            Product product = mapper.Map(productDto);

            // Assert
            Assert.AreEqual(10m, product.BasePrice);
            Assert.AreEqual("sp-001", product.ID);
            Assert.AreEqual("Super Product", product.Name);
        }
    }
}
