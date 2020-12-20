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
        public void AddAutor(Autor autor)
        {
            if(autor != null)
            {
                if(DataBase.autori.ContainsKey(autor.Id))
                {
                    Console.WriteLine("Autor vec postoji!");
                }
                else
                {
                    DataBase.autori.Add(autor.Id, autor);
                }
            }
        }

        public void AddKnjiga(Knjiga knjiga)
        {
            if (knjiga != null)
            {
                if (DataBase.knjige.ContainsKey(knjiga.Id))
                {
                    Console.WriteLine("Knjiga vec postoji!");
                }
                else
                {
                    DataBase.knjige.Add(knjiga.Id, knjiga);
                }
            }
        }

        public void AddUser(Korisnik korisnik)
        {
            if (korisnik != null)
            {
                if (DataBase.users.ContainsKey(korisnik.Username))
                {
                    Console.WriteLine("Autor vec postoji!");
                }
                else
                {
                    DataBase.users.Add(korisnik.Username, korisnik);
                }
            }
        }

        public void DeleteAutor(string id)
        {
           if(DataBase.autori.ContainsKey(id))
            {
                DataBase.autori.Remove(id);
            }
        }

        public void DeleteKnjiga(string id)
        {
            if (DataBase.knjige.ContainsKey(id))
            {
                DataBase.knjige.Remove(id);
            }
        }

        public void DeleteUser(string username)
        {
            if (DataBase.users.ContainsKey(username))
            {
                DataBase.autori.Remove(username);
            }
        }

      
    }
}
