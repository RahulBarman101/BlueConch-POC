using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.DTOs
{
    public class UserDTO
    {
        public int userid { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string middlename { get; set; }
        public string username { get; set; }
        public string passwd { get; set; }
        public DateTime created_on { get; set; }
        public DateTime updated_on { get; set; }
    }
}
