using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common;

namespace Client
{
    public class SecurityMeni
    {
        //
        // Create generic identity based on values from the current
        // WindowsIdentity.
        private static GenericIdentity GetGenericIdentity()
        {
            // Get values from the current WindowsIdentity.
            WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();

            // Construct a GenericIdentity object based on the current Windows
            // identity name and authentication type.
            string authenticationType = windowsIdentity.AuthenticationType;
            string userName = windowsIdentity.Name;
            GenericIdentity authenticatedGenericIdentity =
                new GenericIdentity(userName, authenticationType);

            return authenticatedGenericIdentity;
        }


        public static void ShowSecMen() {
            ClientProxy ret = null;
            Console.WriteLine("Izaberite nazic autentifikacije: ");

            int izbor;
            do
            {
                Console.WriteLine("1. Windows Identitet.");
                Console.WriteLine("2. Certifikati.");
                Console.WriteLine("0. Izlaz.");

                izbor = Int32.Parse(Console.ReadLine());


                if (izbor == 1) {



                    NetTcpBinding binding = new NetTcpBinding();
                    string address = "net.tcp://localhost:9999/ServiceContract";
                    EndpointAddress endpointAddress = new EndpointAddress(new Uri(address));


                    ret = new ClientProxy(binding, endpointAddress);
                    Thread.CurrentPrincipal = new CustomPrincipal(new GenericIdentity("MirkoMika"));
                    using (ret)
                    {


                        Meni.ShowMeni(ret);
                    }

                } else if(izbor==2){
                    //cert sta god 
                    //custom principal cert
                    //da iscupamo sertifikat usera koji je pokrenuo 

                    NetTcpBinding binding = new NetTcpBinding();
                    string address = "net.tcp://localhost:9990/ServiceContract";

                    binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Certificate;

                    string srvCertCN = "Slavisa";
                    X509Certificate2 srvCert = CertManager.GetCertificateFromStorage(StoreName.TrustedPeople, StoreLocation.LocalMachine, srvCertCN);


                    EndpointAddress endpointAddress = new EndpointAddress(new Uri(address), new X509CertificateEndpointIdentity(srvCert));


                    ret = new ClientProxy(binding, endpointAddress, "cert");

                    Thread.CurrentPrincipal = new CustomPrincipal(new GenericIdentity("Mirko"));

                    using (ret)
                    {


                        Meni.ShowMeni(ret);
                    }




                }

            } while (izbor != 0);

        }



    }
}
