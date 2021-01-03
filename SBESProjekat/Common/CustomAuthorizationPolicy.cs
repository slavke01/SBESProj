using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Claims;
using System.IdentityModel.Policy;
using System.Security.Principal;

namespace Common
{
    public class CustomAuthorizationPolicy : IAuthorizationPolicy
    {
        public CustomAuthorizationPolicy()
        {
            Id = Guid.NewGuid().ToString();
        }

        public ClaimSet Issuer
        {
            get { return ClaimSet.System; }
        }
        public string Id
        {
            get;
        }



        public bool Evaluate(EvaluationContext evaluationContext, ref object state)
        {
            if (!evaluationContext.Properties.TryGetValue("Identities", out object list))
            {
                return false;
            }

            IList<IIdentity> identities = list as IList<IIdentity>;
            if (list == null || identities.Count <= 0)
            {
                return false;
            }

            WindowsIdentity windowsIdentity = identities[0] as WindowsIdentity;

            try
            {
                string text = $"User {windowsIdentity.Name} is successfully  authenticated.";
                FileHelper.WriteInTxt(text);
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

            /*
            if ()
            {
                evaluationContext.Properties["Principal"] =
                   new CustomPrincipal((GenericIdentity)identities[0]);
                return true;


            }
            else
            {
            */


                evaluationContext.Properties["Principal"] =
                    new CustomPrincipal((WindowsIdentity)identities[0]);
                return true;

          //  }
        }
    }
}
