using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PerformanceCounterWebApi.Controllers
{
    public class View_Host
    {
        public int ID { get; set; }
        public string HostName { get; set; }
        public string IP { get; set; }
        public List<View_Performance> Performances { get; set; }
        public List<View_DriveInfo> driveInfoes { get; set; }
    }
}