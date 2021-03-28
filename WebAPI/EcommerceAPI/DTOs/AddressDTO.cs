using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.DTOs
{
    public class AddressDTO
    {
        public int addressid { get; set; }
        public int userid { get; set; }
        public long phno { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public int pincode { get; set; }
        public string description { get; set; }
        public string landmark { get; set; }
        public DateTime created_on { get; set; }
        public DateTime updated_on { get; set; }
    }
}
