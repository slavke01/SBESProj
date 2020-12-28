using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Common;
using System.ServiceModel.Description;
using System.IdentityModel.Policy;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {

            DataIO data = new DataIO();
            DataBase.admins = data.DeSerializeObject<List<AdminKorisnik>>("..\\..\\..\\admins.xml");
            NetTcpBinding binding = new NetTcpBinding();
            string address = "net.tcp://localhost:9999/ServiceContract";
            ServiceHost host = new ServiceHost(typeof(ServiceContract));
            host.AddServiceEndpoint(typeof(IServiceContract), binding, address);


            host.Authorization.PrincipalPermissionMode = PrincipalPermissionMode.Custom;

            List<IAuthorizationPolicy> policies = new List<IAuthorizationPolicy>();
            policies.Add(new CustomAuthorizationPolicy());
            host.Authorization.ExternalAuthorizationPolicies = policies.AsReadOnly();

            host.Open();

            Console.WriteLine("Servis je pokrenut.");

            Console.ReadLine();
        }
    }
}
