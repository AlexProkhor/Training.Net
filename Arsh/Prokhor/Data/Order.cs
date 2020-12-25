using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prokhor.Data
{
    public class Order
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int ProductCount { get; set; }
        public int ShopBagId { get; set; }
        public ShopBag ShopBag { get; set; }

    }
}
