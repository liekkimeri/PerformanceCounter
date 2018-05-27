using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PerformanceCounterWebApi.Controllers
{
    public class View_DriveInfo
    {
        public string name { get; set; }
        public long TotalFreeSpace { get; set; }
        public System.DateTime timeStamp { get; set; }
    }
}