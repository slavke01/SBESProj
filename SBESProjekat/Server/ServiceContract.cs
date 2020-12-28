using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using Common;


namespace Server
{
    public class ServiceContract : IServiceContract
    {
        [PrincipalPermission(SecurityAction.Demand, Role = "Read")]

        public void AddAutor(string id,string ime,string prezime)
        {
            Autor autor = new Autor(id,ime,prezime);
            if(autor != null)
            {
                if(DataBase.autori.ContainsKey(autor.Id))
                {
                    Console.WriteLine("Autor vec postoji!");
                }
                else
                {
                    DataBase.autori.Add(autor.Id, autor);
                    Console.WriteLine("Autor dodan.");
                }
            }
        }
        [PrincipalPermission(SecurityAction.Demand, Role = "Read")]

        public void AddKnjiga(string id,string naziv,string zanr,string id_autora)
        {
            Knjiga knjiga = new Knjiga(id,naziv,zanr,id_autora);
            if (knjiga != null)
            {
                if (DataBase.knjige.ContainsKey(knjiga.Id))
                {
                    Console.WriteLine("Knjiga vec postoji!");
                }
                else
                {

                    DataBase.knjige.Add(knjiga.Id, knjiga);
                    Console.WriteLine("Knjiga dodana");
                }
            }
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Read")]

        public void AddUser(string username,string ime,string prezime ,bool active)
        {
            
                Korisnik korisnik = new Korisnik(username, ime, prezime, active);
                if (korisnik != null)
                {
                    if (DataBase.users.ContainsKey(korisnik.Username))
                    {
                        Console.WriteLine("Korisnik vec postoji!");
                    }
                    else
                    {
                        DataBase.users.Add(korisnik.Username, korisnik);
                        Console.WriteLine("Korisnik dodan");
                    }
                }
            
           
        }
        [PrincipalPermission(SecurityAction.Demand, Role = "Delete")]

        public void DeleteAutor(string id)
        {
            if (DataBase.autori.ContainsKey(id))
            {
                DataBase.autori.Remove(id);
                Console.WriteLine("Autor obrisan.");
            }
            else {
                Console.WriteLine("Autor ne postoji.");
            }
        }
        [PrincipalPermission(SecurityAction.Demand, Role = "Delete")]
        public void DeleteKnjiga(string id)
        {
            if (DataBase.knjige.ContainsKey(id))
            {
                DataBase.knjige.Remove(id);
                Console.WriteLine("Knjiga obrisana.");
            }
            else {
                Console.WriteLine("Knjiga ne postoji.");
            }
        }
        [PrincipalPermission(SecurityAction.Demand, Role = "Delete")]
        public void DeleteUser(string username)
        {
            if (DataBase.users.ContainsKey(username))
            {
                DataBase.autori.Remove(username);
                Console.WriteLine("Korisnik obrisan.");
            }
            else {
                Console.WriteLine("Korisnik ne postoji.");
            }
        }
        [PrincipalPermission(SecurityAction.Demand, Role = "Modify")]
        public void IzmjeniAutor(string id, string ime, string prezime)
        {

            if (DataBase.autori.ContainsKey(id))
            {
                DataBase.autori[id].Ime = ime;
                DataBase.autori[id].Prezime = prezime;
                Console.WriteLine("Autor izmnjenjen.");
                //Vrv pozivati audit komponentu kada bude postojala
            }
            else {
                //zamjeniti sa custom exceptions mozda
                Console.WriteLine("Autor sa ovim ID-em ne postoji");
            }
        }
        [PrincipalPermission(SecurityAction.Demand, Role = "Modify")]
        public void IzmjeniKnjiga(string id, string naziv, string zanr)
        {
            if (DataBase.knjige.ContainsKey(id))
            {
                DataBase.knjige[id].Naziv = naziv;
                DataBase.knjige[id].Zanr = zanr;
                Console.WriteLine("Knjiga izmjenjena.");
            }
            else
            {
                //zamjeniti sa custom exceptions mozda
                Console.WriteLine("Knjiga sa ovim ID-em ne postoji");
            }
        }
        [PrincipalPermission(SecurityAction.Demand, Role = "Modify")]
        public void IzmjeniUser(string username, string ime, string prezime, bool active)
        {
            if (DataBase.users.ContainsKey(username))
            {
                DataBase.users[username].Ime = ime;
                DataBase.users[username].Prezime = prezime;
                DataBase.users[username].Aktivan = active;
                Console.WriteLine("Korisnik izmjenjen.");
            }
            else
            {
                //zamjeniti sa custom exceptions mozda
                Console.WriteLine("Korisnik sa ovim ID-em ne postoji");
            }
        }

        public string ShowAutors()
        {
            string retVal = "";
            foreach (Autor a in DataBase.autori.Values) {

                string x = string.Format("ID autora: {0} , Ime: {1} , Prezime: {2}",a.Id,a.Ime,a.Prezime);
                retVal = retVal + x + "\n";
            }
            Console.WriteLine("Autori prikazani.");
            return retVal;

        }

        public string ShowBooks()
        {
            string retVal = "";

            foreach (Knjiga k in DataBase.knjige.Values) {

                string x = string.Format("ID knjige: {0} , Naziv knjige: {1} , Zanr knjige {2}, Ime pisca: {3}  ",k.Id,k.Naziv,k.Zanr,k.Pisac.Ime);
                retVal = retVal + x + "\n"; 
            }
            Console.WriteLine("Knjige prikazanje.");
            return retVal;
        }

        public string ShowUsers()
        {
            string retVal = "";
            foreach (Korisnik k in DataBase.users.Values) {

                string x = string.Format("Username : {0} , Ime korisnika: {1} , Prezime korisnika: {2} ",k.Username,k.Ime,k.Prezime);
                retVal = retVal + x + "\n";
            }
            Console.WriteLine("Korisnici prikazani.");
            return retVal;
        }
    }
}
