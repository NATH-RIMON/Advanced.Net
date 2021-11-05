using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models.VM
{
    public class HomeModel
    {
        public int SendMessages { get; set; }
        public int FailedMessages { get; set; }
        public int SuccessMessages { get; set; }
        public double Balance { get; set; }
        public int Groups { get; set; }
        public int Templates { get; set; }
    }
}