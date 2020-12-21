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
            //windows auth
        }

        //Drugi proxi
        public ClientProxy(NetTcpBinding binding, EndpointAddress address,string x) : base (binding,address) 
        {
            //cert auth
            factory = this.CreateChannel();
        }

        public void AddAutor(string id,string ime, string prezime)
        {
            factory.AddAutor(id,ime,prezime);
        }

        public void AddKnjiga(string id, string naziv,string zanr,string id_autora)
        {
            factory.AddKnjiga(id,naziv,zanr,id_autora);
        }

        public void AddUser(string username,string ime, string prezime, bool active)
        {
            factory.AddUser(username,ime,prezime,active);
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

        public void IzmjeniAutor(string id, string ime, string prezime)
        {
            factory.IzmjeniAutor(id, ime, prezime);
        }

        public void IzmjeniKnjiga(string id, string naziv, string zanr)
        {
            factory.IzmjeniKnjiga(id,naziv,zanr);
        }

        public void IzmjeniUser(string username, string ime, string prezime, bool active)
        {
            factory.IzmjeniUser(username,ime,prezime,active);
        }

        public string ShowAutors()
        {
            return factory.ShowAutors();
        }

        public string ShowBooks()
        {
            return factory.ShowBooks();
        }

        public string ShowUsers()
        {
         return   factory.ShowUsers();
        }
    }
}
