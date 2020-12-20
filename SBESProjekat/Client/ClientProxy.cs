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

        public void AddAutor(Autor autor)
        {
            factory.AddAutor(autor);
        }

        public void AddKnjiga(Knjiga knjiga)
        {
            factory.AddKnjiga(knjiga);
        }

        public void AddUser(Korisnik korisnik)
        {
            factory.AddUser(korisnik);
        }

        public void DeleteAutor(string id)
        {
            factory.DeleteAutor(id);
        }

        public void DeleteKnjiga(string id)
        {
            factory.DeleteKnjiga(id);
        }

        public void DeleteUser(string username)
        {
            factory.DeleteUser(username);
        }

       
    }
}
