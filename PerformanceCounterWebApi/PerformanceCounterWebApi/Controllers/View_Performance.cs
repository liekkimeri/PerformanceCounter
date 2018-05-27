using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PerformanceCounterWebApi.Controllers
{
    public class View_Performance
    {
        public double cpu { get; set; }
        public int ram { get; set; }
        public System.DateTime timeStamp { get; set; }
    }
}