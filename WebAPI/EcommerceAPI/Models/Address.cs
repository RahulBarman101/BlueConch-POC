using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.Models
{
    public class Address
    {
        public int addressid { get; set; }
        public int userid { get; set; }
        public long phno { get; set; }
        [Required]
        [StringLength(20)]
        public string city { get; set; }
        [Required]
        [StringLength(20)]
        public string state { get; set; }
        [Required]
        [StringLength(20)]
        public string country { get; set; }
        [Required]
        public int pincode { get; set; }
        [StringLength(50)]
        public string description { get; set; }
        [StringLength(20)]
        public string landmark { get; set; }
        public DateTime created_on { get; set; }
        public DateTime updated_on { get; set; }

    }
}
