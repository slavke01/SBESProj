using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Server
{
    public class ServiceContract : IServiceContract
    {
        public void ispisi(string poruka)
        {
            Console.WriteLine(poruka);
        }
    }
}
