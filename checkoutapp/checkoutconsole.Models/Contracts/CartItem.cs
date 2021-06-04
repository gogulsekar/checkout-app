using System;
using System.Collections.Generic;
using System.Text;

namespace checkoutconsole.Common.Contracts
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public int ProductId { get; set; }
        public int Units { get; set; }
        public Decimal FinalPrice { get; set; }
    }
}
