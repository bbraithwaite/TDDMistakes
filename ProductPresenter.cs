using System;

namespace TDDMistakes
{
    public class ProductPresenter
    {
        private IProductView _view;
        private INavigationService _navigationService;
        private IProductService _productService;
        private IBasketService _basketService;

        public IProductView View
        {
            get
            {
                return _view;
            }
        }

        public INavigationService NavigationService
        {
            get
            {
                return _navigationService;
            }
        }

        public ProductPresenter(IProductView view, INavigationService navigationService, IProductService productService, IBasketService basketService)
        {
            _view = view;
            _navigationService = navigationService;
            _productService = productService;
            _basketService = basketService;
        }

        internal void Initialize()
        {
            string productID = View.ProductID;
            Product product = _productService.GetByID(productID);

            if (product != null)
            {
                View.Product = product;
                View.IsInBasket = _basketService.ProductExists(productID);
            }
            else
            {
               NavigationService.GoTo("/not-found");
            }
        }
    }
}
