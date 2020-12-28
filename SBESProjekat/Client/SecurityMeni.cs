using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Client
{
    public class SecurityMeni
    {
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

                } else if(izbor==2){
                    //cert sta god 
                    //custom principal cert

                }

            } while (izbor != 0);

        }



    }
}
