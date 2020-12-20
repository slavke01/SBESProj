using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Common;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            NetTcpBinding binding = new NetTcpBinding();
            string address = "net.tcp://localhost:9999/ServiceContract";
            ServiceHost host = new ServiceHost(typeof(ServiceContract));
            host.AddServiceEndpoint(typeof(IServiceContract), binding, address);

            host.Open();
            Console.WriteLine("Servis je pokrenut.");

            Console.ReadLine();
        }
    }
}
