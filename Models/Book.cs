using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChineseBridge.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Name { get; set; }
        public Campus Campus { get; set; }
        public int CampusId { get; set; }
        public Boolean Status { get; set; }

    }
}