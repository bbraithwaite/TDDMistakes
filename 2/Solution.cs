using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;

namespace TDDMistakes._2
{
    [TestClass]
    public class Solution
    {
        [TestMethod]
        public void InitializeWithValidProductIDReturnsView()
        {
            // Arrange   
            var view = Mock.Create<IProductView>();
            Mock.Arrange(() => view.ProductID).Returns("spr-product");

            var mock = new MockProductPresenter(view);

            // Act
            mock.Presenter.Initialize();

            // Assert
            Assert.IsNotNull(mock.Presenter.View.Product);
            Assert.IsTrue(mock.Presenter.View.IsInBasket);
        }

        [TestMethod]
        public void InitializeWithInvalidProductIDRedirectsToNotFound()
        {
            // Arrange
            var view = Mock.Create<IProductView>();
            Mock.Arrange(() => view.ProductID).Returns("invalid-product");

            var mock = new MockProductPresenter(view);

            // Act
            mock.Presenter.Initialize();

            // Assert
            Mock.Assert(mock.Presenter.NavigationService);
        }

        public class MockProductPresenter
        {
            public ProductPresenter Presenter { get; private set; }
            public IProductService ProductService { get; set; }
            public IBasketService BasketService { get; set; }

            public MockProductPresenter(IProductView view)
            {
                var productService = Mock.Create<IProductService>();
                var navigationService = Mock.Create<INavigationService>();
                var basketService = Mock.Create<IBasketService>();

                // Setup for private methods
                Mock.Arrange(() => productService.GetByID("spr-product")).Returns(new Product());
                Mock.Arrange(() => basketService.ProductExists("spr-product")).Returns(true);
                Mock.Arrange(() => navigationService.GoTo("/not-found")).OccursOnce();

                Presenter = new ProductPresenter(
                                                view,
                                                navigationService,
                                                productService,
                                                basketService);
            }
        }
    }
}
