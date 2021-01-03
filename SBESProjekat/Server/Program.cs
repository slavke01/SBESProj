using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Common;
using System.ServiceModel.Description;
using System.IdentityModel.Policy;
using System.Security.Principal;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Security;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {

            DataIO data = new DataIO();
            DataBase.admins = data.DeSerializeObject<List<AdminKorisnik>>("..\\..\\..\\admins.xml");


            NetTcpBinding bindingWin = new NetTcpBinding();
            string addressWin = "net.tcp://localhost:9999/ServiceContract";
            ServiceHost hostWin = new ServiceHost(typeof(ServiceContract));
            hostWin.AddServiceEndpoint(typeof(IServiceContract), bindingWin, addressWin);
            hostWin.Authorization.PrincipalPermissionMode = PrincipalPermissionMode.Custom;

            List<IAuthorizationPolicy> policies = new List<IAuthorizationPolicy>();
            policies.Add(new CustomAuthorizationPolicy());



            hostWin.Authorization.ExternalAuthorizationPolicies = policies.AsReadOnly();


            string srvCertCN = Formater.ParseName(WindowsIdentity.GetCurrent().Name);

            NetTcpBinding bindingCert = new NetTcpBinding();
            bindingCert.Security.Transport.ClientCredentialType = TcpClientCredentialType.Certificate;
            string addressCert = "net.tcp://localhost:9990/ServiceContract";
            ServiceHost hostCert = new ServiceHost(typeof(ServiceContract));
            hostCert.AddServiceEndpoint(typeof(IServiceContract), bindingCert, addressCert);
            hostCert.Authorization.PrincipalPermissionMode = PrincipalPermissionMode.Custom;

            hostCert.Authorization.ExternalAuthorizationPolicies = policies.AsReadOnly();
            hostCert.Credentials.ServiceCertificate.Certificate = CertManager.GetCertificateFromStorage(StoreName.My, StoreLocation.LocalMachine, srvCertCN);
            hostCert.Credentials.ClientCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.Custom;
            hostCert.Credentials.ClientCertificate.Authentication.CustomCertificateValidator = new ServerCertValidator();


            hostCert.Open();
            hostWin.Open();

            Console.WriteLine("Servis je pokrenut.");

            Console.ReadLine();
        }
    }
}
