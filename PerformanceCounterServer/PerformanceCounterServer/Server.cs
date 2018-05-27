using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Data.SqlClient;

namespace PerformanceCounterServer
{
    [ServiceContract(Namespace = "http://PerformanceCounterServer")]
    public interface IPerformanceCounter
    {
        [OperationContract]
        bool AddHostNameAndIP(string HostName,string IP);
        [OperationContract]
        bool AddRamAndCpuvalue(float cpu, float ram, string HostName);
        [OperationContract]
        bool AddDriveInfo(Dictionary<string, long> DriveInfo, string HostName);

    }

    public class PerformanceCounterService : IPerformanceCounter
    {
        public string networkDBName = "PerformanceCounter";
        public string networkDBInstance = "DESKTOP-PGIRBC1";
        

        public bool AddHostNameAndIP(string HostName, string IP)
        {
            try
            {

                string connectionString = "server=" + networkDBInstance + ";database=" + networkDBName + ";integrated Security=SSPI;";

                SqlDataReader reader = null;

                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                String query = "SELECT HostName, IP FROM dbo.Host WHERE HostName =  '" + HostName + "'";

                SqlCommand ReadCommand = new SqlCommand(query, con);
                //ReadCommand.Parameters.Add(data.MachineName);
                reader = ReadCommand.ExecuteReader();

                string hostName = "";
                string ip = "";

                while (reader.Read())
                {
                    hostName = reader.GetString(0);
                    ip = reader.GetString(1);
                }

                con.Close();

                if (hostName != HostName)
                {
                    query = "INSERT INTO dbo.Host (HostName,IP) VALUES (@HostName,@ip)";
                    SqlCommand addHostTablecommand = new SqlCommand(query, con);

                    addHostTablecommand.Parameters.AddWithValue("@ip", IP);
                    addHostTablecommand.Parameters.AddWithValue("@HostName", HostName);
                    con.Open();
                    addHostTablecommand.ExecuteNonQuery();
                    con.Close();
                }
                else if (ip != IP)
                {
                    query = "UPDATE dbo.Host SET IP = @ip WHERE HostName =  '" + HostName + "'";
                    SqlCommand addHostTablecommand = new SqlCommand(query, con);
                    addHostTablecommand.Parameters.AddWithValue("@ip", IP);
                    con.Open();
                    addHostTablecommand.ExecuteNonQuery();
                    con.Close();

                }
            }
            catch (Exception eX)
            {
                Console.WriteLine(eX.Message);
                return false;
            }

            return true;
        }

        public bool AddRamAndCpuvalue(float cpu, float ram, string HostName)
        {
            try
            {

                string connectionString = "server=" + networkDBInstance + ";database=" + networkDBName + ";integrated Security=SSPI;";

                SqlDataReader reader = null;

                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                String query = "SELECT ID FROM dbo.Host WHERE HostName =  '" + HostName + "'";

                SqlCommand ReadCommand = new SqlCommand(query, con);
                //ReadCommand.Parameters.Add(data.MachineName);
                reader = ReadCommand.ExecuteReader();

                int ID = 0;

                while (reader.Read())
                {
                    ID = reader.GetInt32(0);
                }

                con.Close();

                query = "INSERT INTO dbo.Performance(cpu,ram,timestamp,ID) VALUES (@cpu,@ram,@timestamp,@ID)";

                SqlCommand command = new SqlCommand(query, con);

                command.Parameters.AddWithValue("@cpu", cpu);
                command.Parameters.AddWithValue("@ram", ram);
                command.Parameters.AddWithValue("@timestamp", DateTime.Now);
                command.Parameters.AddWithValue("@ID", ID);

                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception eX)
            {
                Console.WriteLine(eX.Message);
                return false;
            }

            Console.WriteLine("succesfull inserting data into Database! ");
            return true;
        }
        public bool AddDriveInfo(Dictionary<string, long> DriveInfo, string HostName)
        {
            long temp = 0;

            try
            {
                string connectionString = "server=" + networkDBInstance + ";database=" + networkDBName + ";integrated Security=SSPI;";

                SqlDataReader reader = null;

                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                String query = "SELECT ID FROM dbo.Host WHERE HostName =  '" + HostName + "'";

                SqlCommand ReadID = new SqlCommand(query, con);
                
                reader = null;
                reader = ReadID.ExecuteReader();

                int ID = 0;

                while (reader.Read())
                {
                    ID = reader.GetInt32(0);
                }

                con.Close();
                
                foreach (var pair in DriveInfo)
                {

                    query = "INSERT INTO dbo.DriveInfo(name,TotalFreeSpace,timestamp,ID) VALUES (@name,@TotalFreeSpace,@timestamp,@ID)";
                    SqlCommand addDriveInfoCommand = new SqlCommand(query, con);

                    addDriveInfoCommand.Parameters.AddWithValue("@name", pair.Key);
                    addDriveInfoCommand.Parameters.AddWithValue("@TotalFreeSpace", pair.Value);
                    addDriveInfoCommand.Parameters.AddWithValue("@timestamp", DateTime.Now);
                    addDriveInfoCommand.Parameters.AddWithValue("@ID", ID);

                    con.Open();
                    addDriveInfoCommand.ExecuteNonQuery();
                    con.Close();
                    temp = pair.Value;
            }

            }

            catch (Exception eX)
            {
                Console.WriteLine(eX.Message);
                return false;
            }

            Console.WriteLine("succesfull inserting data into Database! ");
            return true;
        }
    }

    class Server
    {
        static void Main(string[] args)
        {
            Uri BaseAddress = new Uri("http://192.168.1.36:8000/PerformanceCounter/Service");

            ServiceHost SelfHost = new ServiceHost(typeof(PerformanceCounterService), BaseAddress);
            try
            {
                SelfHost.AddServiceEndpoint(
                        typeof(IPerformanceCounter),
                        new WSHttpBinding(),
                        "CalculatorService");

                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                SelfHost.Description.Behaviors.Add(smb);

                SelfHost.Open();
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                // Close the ServiceHostBase to shutdown the service.
                SelfHost.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("An exception occured: {0}", ce.Message);
                SelfHost.Abort();
            }
        }

    }
    
}
