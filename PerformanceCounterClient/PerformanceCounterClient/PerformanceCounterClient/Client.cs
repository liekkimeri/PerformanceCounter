using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.IO;

namespace Client
{
    class Client
    {
        protected static PerformanceCounter cpuCounter;
        protected static PerformanceCounter ramCounter;
        protected static PerformanceCounterClient client;

        static void Main(string[] args)
        {
            client = new PerformanceCounterClient();

            cpuCounter = new PerformanceCounter();
            cpuCounter.CategoryName = "Processor";
            cpuCounter.CounterName = "% Processor Time";
            cpuCounter.InstanceName = "_Total";

            ramCounter = new PerformanceCounter("Memory", "Available MBytes");

            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            client.AddHostNameAndIP(Environment.MachineName, Convert.ToString(ipHostInfo.AddressList.FirstOrDefault(address => address.AddressFamily == AddressFamily.InterNetwork)));

            try
            {
                System.Timers.Timer t = new System.Timers.Timer(1200);
                t.Elapsed += new ElapsedEventHandler(TimerElapsed);
                t.Start();
                Thread.Sleep(10000);
            }
            catch (Exception e)
            {
                Console.WriteLine("catched exception");
            }

            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate client.");
            Console.ReadLine();
            client.Close();

        }

        public static void TimerElapsed(object source, ElapsedEventArgs e)
        {

            client.AddRamAndCpuvalue(cpuCounter.NextValue(), ramCounter.NextValue(), Environment.MachineName);
            
            Dictionary<string, long> driveInfo = new Dictionary<string, long>();

            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo d in allDrives)
            {

                if (d.IsReady == true)
                {
                    driveInfo.Add(d.Name, d.TotalFreeSpace);
                }
            }

            client.AddDriveInfo(driveInfo, Environment.MachineName);
            
        }

    }
}
