using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Security.Principal;
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

            Console.WriteLine("Izaberite nazic autentifikacije: ");

            int izbor;
            do
            {
                Console.WriteLine("1. Windows Identitet.");
                Console.WriteLine("2. Certifikati.");
                Console.WriteLine("0. Izlaz.");

                izbor = Int32.Parse(Console.ReadLine());


                if (izbor == 1) {



                    //cupamo sa treda 
                    //custom principla windows 
                  //  string WindIdentity = WindowsIdentity.GetCurrent().Name;
                    //CustomPrincipal cu = new CustomPrincipal(WindIdentity);

                } else if(izbor==2){
                    //cert sta god 
                    //custom principal cert
                    //da iscupamo sertifikat usera koji je pokrenuo 
                   
                    
                    string WinIdentity = WindowsIdentity.GetCurrent().Name;
                    WinIdentity = null;
                   // IIdentity identity = Thread.CurrentPrincipal.Identity;
                    GenericIdentity genericIdentity = GetGenericIdentity();
                    string identityName = genericIdentity.Name;
                    //CustomPrincipal cp = new CustomPrincipal(genericIdentity);
                    string srvCertCN = Formater.ParseName(WindowsIdentity.GetCurrent().Name);
                    Thread.CurrentPrincipal = new CustomPrincipal(new GenericIdentity(srvCertCN));
                    

                    

                }

            } while (izbor != 0);

        }



    }
}
