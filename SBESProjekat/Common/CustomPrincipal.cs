using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class CustomPrincipal : IPrincipal
    {

        WindowsIdentity identity = null;
        string UserName = null;
        public CustomPrincipal(WindowsIdentity windowsIdentity)
        {
            identity = windowsIdentity;

            this.UserName = Formater.ParseName(identity.Name);
        }

        public IIdentity Identity
        {
            get { return identity; }
        }


        public bool IsInRole(string permission)
        {

            string username = this.UserName;

            foreach (AdminKorisnik a in DataBase.admins) {

                if (a.UserName == username) {
                    string[] permisije;
                    RolesConfig.GetPermissions(a.UserName,out permisije);

                    return permisije.Contains(permission);
                }
            }

            return false;
        }
      



    }
}
