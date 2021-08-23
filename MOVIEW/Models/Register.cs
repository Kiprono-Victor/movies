using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MOVIEW.Models
{
    public class Register
    {
        [Key]
        public int id { get; set; }
        public string FullName { get; set; }
        public string Location { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

    }
}
