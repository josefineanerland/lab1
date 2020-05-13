using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Joane_Labb1.Models
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
