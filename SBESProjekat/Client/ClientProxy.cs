using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Common;

namespace Client
{
    public class ClientProxy : ChannelFactory<IServiceContract>, IServiceContract, IDisposable
    {
        IServiceContract factory;


        //Jedan proxi
        public ClientProxy(NetTcpBinding binding, EndpointAddress address) : base(binding,address) {

            factory = this.CreateChannel();
            //Gadjati windows auth
        }

        //Drugi proxi
        public ClientProxy(NetTcpBinding binding, EndpointAddress address,string x) : base (binding,address) 
        {
            //Gadjati cert auth
            factory = this.CreateChannel();
        }

        public void ispisi(string poruka)
        {
            factory.ispisi(poruka);
        }
    }
}
