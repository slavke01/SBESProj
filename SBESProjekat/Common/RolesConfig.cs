using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
   public class RolesConfig
    {



        public static bool GetPermissions(string username, out string[] permissions)
        {
            permissions = new string[10];
            string permissionString = string.Empty;

            foreach (AdminKorisnik a in DataBase.admins) {

                if (a.UserName == username) {
                    permissionString = a.Permisije;
                }
            }


            if (permissionString != null)
            {
                permissions = permissionString.Split(',');
                return true;
            }
            return false;

        }
    }
}
