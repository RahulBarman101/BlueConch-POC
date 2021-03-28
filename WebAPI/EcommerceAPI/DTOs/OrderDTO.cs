using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.DTOs
{
    public class OrderDTO
    {
        public int order_id { get; set; }
        public int userid { get; set; }
        public string orderItem { get; set; }
        public Int16 quantity { get; set; }
        public decimal price { get; set; }
        public int itemid { get; set; }
    }
}
