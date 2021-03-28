using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceAPI.Models
{
    public class User
    {
        public int userid { get; set; }
        [Required]
        [StringLength(20)]
        public string firstname { get; set; }
        [Required]
        [StringLength(20)]
        public string lastname { get; set; }
        public string middlename { get; set; }
        public string username { get; set; }
        public string passwd { get; set; }
        public DateTime created_on { get; set; }
        public DateTime updated_on { get; set; }
    }
}
