using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChineseBridge.Models
{
    public class Classtype
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [MaxLength(200)]
        public string Color { get; set; }
        public string Image { get; set; }
        public string Teacher { get; set; }

    }
}