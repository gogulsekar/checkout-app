using checkoutconsole.Common.Contracts;
using checkoutconsole.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace checkoutconsole.Services
{
    public class PromotionEngine : IPromotionEngine
    {
        private IDataLoader _loader;
        public PromotionEngine(IDataLoader loader)
        {
            _loader = loader;
        }

        public decimal CalculatePrice(IEnumerable<CartItem> items)
        {
            decimal totalAmount = 0;
            var rules = _loader.LoadPromotionRules();
            var prods = _loader.LoadProducts();
            foreach (var item in items)
            {
                var prod = prods.Where(p => p.ProductId == item.ProductId).FirstOrDefault();
                if (prod == null)
                {
                    throw new ValidationException($"product - {item.ProductId} not found");
                }

                var rule = rules.Where(r => r.ProductId == item.ProductId).FirstOrDefault();
                if (rule != null)
                {
                    if (item.Units >= rule.ApplicableUnits)
                    {
                        int mod = item.Units % rule.ApplicableUnits;
                        int mul = (item.Units - mod) / rule.ApplicableUnits;
                        decimal offerAmount = mul * rule.PromotionPrice + mod * prod.Price;
                        item.FinalPrice = offerAmount;
                    }
                    else
                    {
                        item.FinalPrice = prod.Price * item.Units;
                    }
                }
                else
                {
                    item.FinalPrice = prod.Price * item.Units;
                }
                totalAmount += item.FinalPrice;
            }
            return totalAmount;
        }
    }
}
