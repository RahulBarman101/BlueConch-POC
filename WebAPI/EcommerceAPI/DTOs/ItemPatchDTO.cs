﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.DTOs
{
    public class ItemPatchDTO
    { 
        public string itemName { get; set; }
        public string description { get; set; }
        public string itemFrom { get; set; }
        public decimal itemprice { get; set; }
        public Int16 itemRating { get; set; }
        public int itemRatingCount { get; set; }
    }
}
