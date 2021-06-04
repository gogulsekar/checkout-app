using checkoutconsole.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace checkoutconsole.Common.Interfaces
{
    public interface ICheckoutService
    {
        IEnumerable<Product> LoadProducts();
        decimal CalculatePromotionOffer(IEnumerable<CartItem> cartItems);
    }
}
