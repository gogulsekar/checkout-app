using checkoutconsole.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace checkoutconsole.Common.Interfaces
{
    public interface IDataLoader
    {
        IEnumerable<Product> LoadProducts();
        IEnumerable<PromotionRule> LoadPromotionRules();
    }
}
