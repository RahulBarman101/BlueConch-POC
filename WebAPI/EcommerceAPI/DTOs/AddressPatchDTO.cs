using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.DTOs
{
    public class AddressPatchDTO
    {
        public long phno { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public int pincode { get; set; }
        public string description { get; set; }
        public string landmark { get; set; }
    }
}
