using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;

namespace TDDMistakes._2
{
    [TestClass]
    public class Problem
    {
        [TestMethod]
        public void InitializeWithValidProductIDReturnsView()
        {
            // Arrange
            IProductView productView = Mock.Create<IProductView>();
            Mock.Arrange(() => productView.ProductID).Returns("spr-product");

            IProductService productService = Mock.Create<IProductService>();
            Mock.Arrange(() => productService.GetByID("spr-product")).Returns(new Product()).OccursOnce();

            INavigationService navigationService = Mock.Create<INavigationService>();
            Mock.Arrange(() => navigationService.GoTo("/not-found"));

            IBasketService basketService = Mock.Create<IBasketService>();
            Mock.Arrange(() => basketService.ProductExists("spr-product")).Returns(true);
            
            var productPresenter = new ProductPresenter(
                                                    productView,
                                                    navigationService,
                                                    productService, 
                                                    basketService);

            // Act
            productPresenter.Initialize();

            // Assert
            Assert.IsNotNull(productView.Product);
            Assert.IsTrue(productView.IsInBasket);
        }

        [TestMethod]
        public void InitializeWithInvalidProductIDRedirectsToNotFound()
        {
            // Arrange
            IProductView productView = Mock.Create<IProductView>();
            Mock.Arrange(() => productView.ProductID).Returns("invalid-product");

            IProductService productService = Mock.Create<IProductService>();

            INavigationService navigationService = Mock.Create<INavigationService>();
            Mock.Arrange(() => navigationService.GoTo("/not-found")).OccursOnce();
          
            IBasketService basketService = Mock.Create<IBasketService>();

            var productPresenter = new ProductPresenter(
                                                    productView,
                                                    navigationService,
                                                    productService,
                                                    basketService);

            // Act
            productPresenter.Initialize();

            // Assert
            Mock.Assert(navigationService);
        }
    }
}