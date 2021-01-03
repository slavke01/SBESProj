using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Common;
using System.Security.Principal;
using System.Security.Cryptography.X509Certificates;

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
            string cltCertCN = Formater.ParseName(WindowsIdentity.GetCurrent().Name);


            this.Credentials.ServiceCertificate.Authentication.CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.Custom;
            this.Credentials.ServiceCertificate.Authentication.CustomCertificateValidator = new ClientCertValidator();
            this.Credentials.ServiceCertificate.Authentication.RevocationMode = X509RevocationMode.NoCheck;

            this.Credentials.ClientCertificate.Certificate = CertManager.GetCertificateFromStorage(StoreName.My, StoreLocation.LocalMachine, cltCertCN);
            factory = this.CreateChannel();
        }


        public void AddAutor(string id,string ime, string prezime)
        {
            try
            {
                factory.AddAutor(id, ime, prezime);
            }
            catch(Exception e)
            {
                Console.WriteLine("Greska prilikom dodavanja autora.");
            }
            
        }

        public void AddKnjiga(string id, string naziv,string zanr,string id_autora)
        {
            try
            {
                factory.AddKnjiga(id, naziv, zanr, id_autora);
            }
            catch(Exception e)
            {
                Console.WriteLine("Greska prilikom dodavanja knjige.");
            }
            
        }
        public void AddBookToUser(string id, string username)
        {
            try
            {

                factory.AddBookToUser(id, username);

            }
            catch (Exception e)
            {

                Console.WriteLine("Greska prilikom iznajmljivanja.");
            }
        }
        public void AddUser(string username,string ime, string prezime, bool active)
        {
            try
            {
                factory.AddUser(username, ime, prezime, active);
            }
          catch (Exception e){

                Console.WriteLine("Greska prilikom dodavanja koirsnika.");
            }
        }

        public void DeleteAutor(string id)
        {
            try
            {
                factory.DeleteAutor(id);
            }
            catch(Exception e)
            {
                Console.WriteLine("Greska prilikom brisanja autora.");
            }
            
        }

        public void DeleteKnjiga(string id)
        {
            try
            {
                factory.DeleteKnjiga(id);

            }
            catch(Exception e)
            {
                Console.WriteLine("Greska prilikom brisanja knjige.");
            }
            
        }

        public void DeleteUser(string username)
        {
            try
            {
                factory.DeleteUser(username);
            }
            catch(Exception e)
            {
                Console.WriteLine("Greska prilikom brisanja koirisnika.");
            }
            
        }

        public void IzmjeniAutor(string id, string ime, string prezime)
        {
            try
            {
                factory.IzmjeniAutor(id, ime, prezime);
            } 
            catch(Exception e)
            {
                Console.WriteLine("Greska prilikom izmene autora.");
            }
        }

        public void IzmjeniKnjiga(string id, string naziv, string zanr)
        {
            try
            {
                factory.IzmjeniKnjiga(id, naziv, zanr);
            }
            catch(Exception e)
            {
                Console.WriteLine("Greska prilikom izmene knjige.");
            }
            
        }

        public void IzmjeniUser(string username, string ime, string prezime, bool active)
        {

            try
            {
                factory.IzmjeniUser(username, ime, prezime, active);
            }
            catch(Exception e)
            {
                Console.WriteLine("Greska prilikom izmene korisnika.");
            }
           
        }

        public string ShowAutors()
        {

           
            
                return factory.ShowAutors();
            
        }
        public string ShowIznajmljene(string username)
        {

            return factory.ShowIznajmljene(username);
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
