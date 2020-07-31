using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Joane_Labb1.Models
{
    public class OrderModel
    {
        [Key]
        public int OrderId { get; set; }
        public Guid UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Adress { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set;
        }
    }
}
