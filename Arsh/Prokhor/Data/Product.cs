using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Prokhor.Data
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal Cost { get; set; }

        public List<Order> Orders { get; set; }
    }
}