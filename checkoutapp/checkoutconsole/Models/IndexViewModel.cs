using checkoutconsole.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace checkoutconsole.Models
{
    public class IndexViewModel
    {
        public List<Product> Products { get; set; }
        public List<CartItem> Items { set; get; }
    }
}
