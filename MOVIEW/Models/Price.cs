using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MOVIEW.Models
{
    public class Price
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string strMovieName { get; set; }
    }
}
