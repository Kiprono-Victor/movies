using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MOVIEW.Models
{
    public class Movies
    {
        [Key]
        [MaxLength(50)]
        public string strId { get; set; }
        [Required]
        public string strMovieName { get; set; }
        [Required]
        public string strPrice { get; set; }
        [Required]
        public string strDescription { get; set; }
        
        public string strimageurl { get; set; }
       
        [NotMapped]
        [DisplayName("image")]
        // [Required(ErrorMessage = "Category Image cannot be null")]

        public IFormFile ImageFile { get; set; }

    }
}
