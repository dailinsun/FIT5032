using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChineseBridge.Models
{
    public class BookEvent
    {
        public int Id { get; set; }
        public ClassinCampus ClassinCampus { get; set; }
        public int ClassinCampusId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }
    }
}