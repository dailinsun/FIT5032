using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChineseBridge.Models
{
    public class ClassinCampus
    {
        public int Id{ get; set; }
        public Campus Campus{ get; set; }
        public int CampusId { get; set; }
        public Classtype Classtype { get; set; }
        public int ClasstypeId { get; set; }

        public DateTime StartTime { get; set; }
    }
}