using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.DTOs
{
    public class ItemDTO
    {
        public int itemid { get; set; }
        public string itemName { get; set; }
        public string description { get; set; }
        public string itemFrom { get; set; }
        public decimal itemPrice { get; set; }
        public Int16 itemRating { get; set; }
        public int itemRatingCount { get; set; }
    }
}
