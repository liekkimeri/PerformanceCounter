using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PerformanceCounterWebApi.Models;

namespace PerformanceCounterWebApi.Controllers
{
    public class PerformanceCounterController : ApiController
    {
        private PerformanceCounterEntities db = new PerformanceCounterEntities();

        // GET: api/PerformanceCounter
        public List<View_Host> GetHosts()
        {
            var query = "SELECT * from Host";
            var hostList = db.Hosts.SqlQuery(query).ToList();

            List<View_Host> view_hostList = new List<View_Host>();

            foreach (var host in hostList)
            {
                View_Host view_host = new View_Host();
                view_host.IP = host.IP;
                view_host.ID = host.ID;
                view_host.HostName = host.HostName;

                view_host.Performances = new List<View_Performance>();

                var queryPerformance = "SELECT TOP 1  * FROM Performance where ID = " + host.ID + " ORDER BY timeStamp DESC";
                var performanceList = db.Performances.SqlQuery(queryPerformance).ToList();

                foreach (var performance in performanceList)
                {
                    View_Performance view_Performance = new View_Performance();
                    view_Performance.cpu = performance.cpu;
                    view_Performance.ram = performance.ram;
                    view_Performance.timeStamp = performance.timeStamp;
                    view_host.Performances.Add(view_Performance);

                }

                var queryDriveInfo = "SELECT TOP 1 * FROM DriveInfo WHERE ID = " + host.ID + "  ORDER BY timeStamp DESC";
                var driveInfoList = db.DriveInfoes.SqlQuery(queryDriveInfo).ToList();

                view_host.driveInfoes = new List<View_DriveInfo>();
                foreach (var driveInfo in driveInfoList)
                {
                    View_DriveInfo view_DriveInfo = new View_DriveInfo();
                    view_DriveInfo.name = driveInfo.name;
                    view_DriveInfo.TotalFreeSpace = driveInfo.TotalFreeSpace;
                    view_DriveInfo.timeStamp = driveInfo.timeStamp;
                    view_host.driveInfoes.Add(view_DriveInfo);

                }

                view_hostList.Add(view_host);
            }
            return view_hostList;
        }

        // GET: api/PerformanceCounter/5
        [ResponseType(typeof(View_Host))]
        public IHttpActionResult GetHost(int id)
        {
            Host host = db.Hosts.Find(id);
            if (host == null)
            {
                return NotFound();
            }

            //one day performance
            var query = "SELECT TOP 71600 * FROM Performance WHERE ID = " + host.ID;
            var performanceList = db.Performances.SqlQuery(query).ToList();

            View_Host view_Host = new View_Host();
            view_Host.Performances = new List<View_Performance>();
            foreach (var performance in performanceList)
            {
                View_Performance view_Performance = new View_Performance();
                view_Performance.cpu = performance.cpu;
                view_Performance.ram = performance.ram;
                view_Performance.timeStamp = performance.timeStamp;
                view_Host.Performances.Add(view_Performance);

            }

            //one day driveInfo
            var queryDriveInfo = "SELECT TOP 71600 * FROM DriveInfo WHERE ID = " + host.ID;
            var driveInfoList = db.DriveInfoes.SqlQuery(queryDriveInfo).ToList();

            view_Host.driveInfoes = new List<View_DriveInfo>();
            foreach (var driveInfo in driveInfoList)
            {
                View_DriveInfo view_DriveInfo = new View_DriveInfo();
                view_DriveInfo.name = driveInfo.name;
                view_DriveInfo.TotalFreeSpace = driveInfo.TotalFreeSpace;
                view_DriveInfo.timeStamp = driveInfo.timeStamp;
                view_Host.driveInfoes.Add(view_DriveInfo);

            }


            view_Host.ID = host.ID;
            view_Host.HostName = host.HostName;
            view_Host.IP = host.IP;
            return Ok(view_Host);
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HostExists(int id)
        {
            return db.Hosts.Count(e => e.ID == id) > 0;
        }
    }
}