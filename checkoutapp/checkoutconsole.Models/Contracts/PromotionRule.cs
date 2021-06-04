using System;
using System.Collections.Generic;
using System.Text;

namespace checkoutconsole.Common.Contracts
{
    public class PromotionRule
    {
        public int PromotionRuleId { get; set; }
        public int ProductId { get; set; }
        public int ApplicableUnits { get; set; }
        public decimal PromotionPrice { get; set; }
    }
}
