using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TDDMistakes._3
{
    [TestClass]
    public class Problem
    {
        [TestMethod]
        public void ProductPriceTests()
        {
            // Arrange
            var product = new Product()
            {
                BasePrice = 10m
            };

            // Act
            decimal basePrice = product.CalculatePrice(CalculationRules.None);
            decimal discountPrice = product.CalculatePrice(CalculationRules.Discounted);
            decimal standardPrice = product.CalculatePrice(CalculationRules.Standard);

            // Assert
            Assert.AreEqual(10m, basePrice);
            Assert.AreEqual(11m, discountPrice);
            Assert.AreEqual(12m, standardPrice);
        }
    }
}
