﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.Models
{
    public class Order
    {
        public int order_id { get; set; }
        public int userid { get; set; }
        [Required]
        [StringLength(20)]
        public string orderItem { get; set; }
        public Int16 quantity { get; set; }
        public decimal price { get; set; }
        public int itemid { get; set; }
    }
}
