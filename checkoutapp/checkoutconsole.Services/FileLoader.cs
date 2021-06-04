using checkoutconsole.Common.Contracts;
using checkoutconsole.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace checkoutconsole.Services
{
    public class FileLoader : IDataLoader
    {
        public IEnumerable<Product> LoadProducts()
        {
            List<Product> products = new List<Product>();
            string line = string.Empty;
            StreamReader reader = new StreamReader("products.csv");
            while ((line = reader.ReadLine()) != null)
            {
                var product = new Product();
                var content = line.Split(',');
                product.ProductId = Convert.ToInt32(content[0]);
                product.Name = Convert.ToString(content[1]);
                product.Price = Convert.ToDecimal(content[2]);
                products.Add(product);
            }
            return products;
        }

        public IEnumerable<PromotionRule> LoadPromotionRules()
        {
            List<PromotionRule> promoRules = new List<PromotionRule>();
            string line = string.Empty;
            StreamReader reader = new StreamReader("promorules.csv");
            while ((line = reader.ReadLine()) != null)
            {
                var rule = new PromotionRule();
                var content = line.Split(',');
                rule.PromotionRuleId = Convert.ToInt32(content[0]);
                rule.ProductId = Convert.ToInt32(content[1]);
                rule.ApplicableUnits = Convert.ToInt32(content[2]);
                rule.PromotionPrice = Convert.ToDecimal(content[3]);
                promoRules.Add(rule);
            }
            return promoRules;
        }
    }
}
