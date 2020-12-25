using System.Collections.Generic;

namespace Prokhor.Data
{
    public class ShopBag
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public List<Order> Orders {get; set;}

        public bool IsItPaid { get; set; }

        public string Status { get; set; }
    }
}