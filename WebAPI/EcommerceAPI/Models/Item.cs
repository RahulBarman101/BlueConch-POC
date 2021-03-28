using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.Models
{
    public class Item
    {
        public int itemid { get; set; }
        [Required]
        [StringLength(20)]
        public string itemName { get; set; }
        [Required]
        [StringLength(20)]
        public string description { get; set; }
        public string itemFrom { get; set; }
        public decimal itemPrice { get; set; }
        public Int16 itemRating { get; set; }
        public int itemratingCount { get; set; }
    }
}
