using checkoutconsole.Common.Contracts;
using checkoutconsole.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace checkoutconsole.Services
{
    public class CheckoutService : ICheckoutService
    {
        private readonly IDataLoader _loader;
        private readonly IPromotionEngine _promoEngine;

        public CheckoutService(IDataLoader loader, IPromotionEngine promoEngine)
        {
            _loader = loader;
            _promoEngine = promoEngine;
        }

        public decimal CalculatePromotionOffer(IEnumerable<CartItem> cartItems)
        {
            //additional validation
            return _promoEngine.CalculatePrice(cartItems);
        }

        public IEnumerable<Product> LoadProducts()
        {
            return _loader.LoadProducts();
        }
    }
}
