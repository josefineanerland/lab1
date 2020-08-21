using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Model
{
    public class Order
    {

        public int OrderId { get; set; }
        public Guid UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Adress { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }
        public DateTime Orderdate { get; set; }
        public string Products { get; set; }

    }
}
