using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
   public class AdminKorisnik
    {

        public string  UserName { get; set; }

        public string Permisije { get; set; }

        public AdminKorisnik() { }

        public AdminKorisnik(string user,string permisije) {


            this.UserName = user;

            this.Permisije = permisije;
        }
    }
}
