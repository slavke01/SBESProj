using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Common;


namespace Server
{
    public class ServiceContract : IServiceContract
    {
       // [PrincipalPermission(SecurityAction.Demand, Role = "Read")]

        public void AddAutor(string id,string ime,string prezime)
        {
            CustomPrincipal principal = Thread.CurrentPrincipal as CustomPrincipal;
            if(Thread.CurrentPrincipal.IsInRole("Read"))
            {
                Autor autor = new Autor(id, ime, prezime);
                if (autor != null)
                {
                    if (DataBase.autori.ContainsKey(autor.Id))
                    {
                        Console.WriteLine("Autor vec postoji!");
                        // da li i ovde treba??? think!
                    }
                    else
                    {
                        DataBase.autori.Add(autor.Id, autor);
                        Console.WriteLine("Autor uspesno dodan.");


                        //logovanje
                        try
                        {
                            
                            string createText = $"User {principal.Identity.Name} successfully accessed to AddAuthor method.";
                            FileHelper.WriteInTxt(createText);
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        }

                    }
                }

            }
            else
            {
                try
                {
                    
                    string createText = $"User {principal.Identity.Name} can not access to AddAuthor method. No Read permission.";
                    FileHelper.WriteInTxt(createText);

                }
                catch(ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }

                string userName = Formater.ParseName(Thread.CurrentPrincipal.Identity.Name);
                throw new Exception("User" + userName + "try to call AddAutor method need Read permission.");
            }
           
        }
       // [PrincipalPermission(SecurityAction.Demand, Role = "Read")]

        public void AddKnjiga(string id,string naziv,string zanr,string id_autora)
        {
            CustomPrincipal principal = Thread.CurrentPrincipal as CustomPrincipal;
            if (Thread.CurrentPrincipal.IsInRole("Read"))
            {
                Knjiga knjiga = new Knjiga(id, naziv, zanr, id_autora);
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


                        try
                        {
                            string createText = $"User {principal.Identity.Name} successfully accessed to AddKnjiga method.";
                            FileHelper.WriteInTxt(createText);
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        }

                    }
                }

            }
            else
            {
                try
                {
                    string createText = $"User {principal.Identity.Name} can not access to AddKnjiga method. No Read permission.";
                    FileHelper.WriteInTxt(createText);

                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }

                string userName = Formater.ParseName(Thread.CurrentPrincipal.Identity.Name);
                throw new FaultException("User " + userName +
                    " try to call AddKnjiga method. AddKnjiga method need  Read permission.");
            }
               
        }

        //[PrincipalPermission(SecurityAction.Demand, Role = "Read")]

        public void AddUser(string username,string ime,string prezime ,bool active)
        {
            CustomPrincipal principal = Thread.CurrentPrincipal as CustomPrincipal;
           if(Thread.CurrentPrincipal.IsInRole("Read"))
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
                        Console.WriteLine("Korisnik uspesno dodan");

                        try
                        {
                            // Audit.AuthorizationSuccess(principal.Identity.Name, OperationContext.Current.IncomingMessageHeaders.Action);
                            string createText = $"User {principal.Identity.Name} successfully accessed to AddUser method.";
                            FileHelper.WriteInTxt(createText);

                        }
                        catch(ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        }


                    }


                }

           }
           else
           {
                try
                {
                    // Audit.AuthorizationFailed(principal.Identity.Name, OperationContext.Current.IncomingMessageHeaders.Action, "No read permission.");
                    string createText = $"User {principal.Identity.Name} can not access to AddUser method. No Read permission.";
                    FileHelper.WriteInTxt(createText);


                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }

                string userName = Formater.ParseName(Thread.CurrentPrincipal.Identity.Name);
                throw new FaultException("User " + userName +
                    " try to call AddUser method. AddUser method need  Read permission.");
           }

           
            
           
        }
        //[PrincipalPermission(SecurityAction.Demand, Role = "Delete")]

        public void DeleteAutor(string id)
        {
            CustomPrincipal principal = Thread.CurrentPrincipal as CustomPrincipal;
            if(Thread.CurrentPrincipal.IsInRole("Delete"))
            {
                if (DataBase.autori.ContainsKey(id))
                {
                    DataBase.autori.Remove(id);
                    Console.WriteLine("Autor uspesno obrisan.");


                    try
                    {
                        string createText = $"User {principal.Identity.Name} successfully accessed to DeleteAutor method.";
                        FileHelper.WriteInTxt(createText);
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Autor ne postoji.");

                }

            }
            else
            {
                try
                {
                    string createText = $"User {principal.Identity.Name} can not access to DeleteAuthor method. No Delete permission.";
                    FileHelper.WriteInTxt(createText);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }

                string userName = Formater.ParseName(Thread.CurrentPrincipal.Identity.Name);
                throw new FaultException("User " + userName +
                    " try to call DeleteAutor method. DeleteAutor method need  Delete permission.");
            }
           
        }
       // [PrincipalPermission(SecurityAction.Demand, Role = "Delete")]
        public void DeleteKnjiga(string id)
        {
            CustomPrincipal principal = Thread.CurrentPrincipal as CustomPrincipal;
            if (Thread.CurrentPrincipal.IsInRole("Delete"))
            {


                if (DataBase.knjige.ContainsKey(id))
                {
                    DataBase.knjige.Remove(id);
                    Console.WriteLine("Knjiga uspesno obrisana.");

                    try
                    {
                        string createText = $"User {principal.Identity.Name} successfully accessed to DeleteKnjiga method.";
                        FileHelper.WriteInTxt(createText);
                    }
                    catch(ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Knjiga ne postoji.");
                    //??
                }

            }
            else
            {
                try
                {
                    string createText = $"User {principal.Identity.Name} can not access to DeleteKnjiga method. No Delete permission.";
                    FileHelper.WriteInTxt(createText);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }

                string userName = Formater.ParseName(Thread.CurrentPrincipal.Identity.Name);
                throw new FaultException("User " + userName +
                    " try to call DeleteKnjiga method. DeleteKnjiga method need  Delete permission.");
            }
        }
        // [PrincipalPermission(SecurityAction.Demand, Role = "Delete")]
        public void DeleteUser(string username)
        {
            CustomPrincipal principal = Thread.CurrentPrincipal as CustomPrincipal;
            if (Thread.CurrentPrincipal.IsInRole("Delete"))
            {
                if (DataBase.users.ContainsKey(username))
                {
                    DataBase.autori.Remove(username);
                    Console.WriteLine("Korisnik uspesno obrisan.");

                    try
                    {
                        string createText = $"User {principal.Identity.Name} successfully accessed to DeleteUser method.";
                        FileHelper.WriteInTxt(createText);
                    }
                    catch(ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Korisnik ne postoji.");
                    //korisnik kada dodje ovde on ima permisju za brisanje sto znaci da se moze logovati  je l tako?
                    //znaci i ovde pisemo try catch kao i gore ili samo ako je operacija uspesno izvrsena?
                }

            }
            else
            {
                try
                {
                    
                    string createText = $"User {principal.Identity.Name} can not access to DeleteUser method. No Delete permission.";
                    FileHelper.WriteInTxt(createText);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }

                string userName = Formater.ParseName(Thread.CurrentPrincipal.Identity.Name);
                throw new FaultException("User " + userName +
                    " try to call DeleteUser method. DeleteUser method need  delete permission.");
            }
          
        }
       // [PrincipalPermission(SecurityAction.Demand, Role = "Modify")]
        public void IzmjeniAutor(string id, string ime, string prezime)
        {
            CustomPrincipal principal = Thread.CurrentPrincipal as CustomPrincipal;
            if(Thread.CurrentPrincipal.IsInRole("Modify"))
            {
                if (DataBase.autori.ContainsKey(id))
                {
                    DataBase.autori[id].Ime = ime;
                    DataBase.autori[id].Prezime = prezime;
                    Console.WriteLine("Autor uspesno izmnjenjen.");
                    //Vrv pozivati audit komponentu kada bude postojala
                    //tako je rodjace,sad ce nadica to odraditi
                    try
                    {
                        string createText = $"User {principal.Identity.Name} successfully accessed to IzmjeniAutor method.";
                        FileHelper.WriteInTxt(createText);
                    }
                    catch(ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else
                {
                    //zamjeniti sa custom exceptions mozda
                    Console.WriteLine("Autor sa ovim ID-em ne postoji");
                }

            }
            else
            {
                try
                {
                    string createText = $"User {principal.Identity.Name} can not access to IzmjeniAutor method. No modify permission.";
                    FileHelper.WriteInTxt(createText);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }

                string userName = Formater.ParseName(Thread.CurrentPrincipal.Identity.Name);
                throw new FaultException("User " + userName +
                    " try to call IzmjeniAutor method. IzmjeniAutor method need  Modify permission.");
            }

           
        }
       // [PrincipalPermission(SecurityAction.Demand, Role = "Modify")]
        public void IzmjeniKnjiga(string id, string naziv, string zanr)
        {
            CustomPrincipal principal = Thread.CurrentPrincipal as CustomPrincipal;
            if(Thread.CurrentPrincipal.IsInRole("Modify"))
            {
                if (DataBase.knjige.ContainsKey(id))
                {
                    DataBase.knjige[id].Naziv = naziv;
                    DataBase.knjige[id].Zanr = zanr;
                    Console.WriteLine("Knjiga uspesno izmjenjena.");

                    try
                    {
                        string createText = $"User {principal.Identity.Name} successfully accessed to IzmjeniKnjiga method.";
                        FileHelper.WriteInTxt(createText);
                    }
                    catch(ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else
                {
                    //zamjeniti sa custom exceptions mozda
                    Console.WriteLine("Knjiga sa ovim ID-em ne postoji");
                }
            }
            else
            {
                try
                {
                    string createText = $"User {principal.Identity.Name} can not access to IzmjeniKnjiga method. No modify permission.";
                    FileHelper.WriteInTxt(createText);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }

                string userName = Formater.ParseName(Thread.CurrentPrincipal.Identity.Name);
                throw new FaultException("User " + userName +
                    " try to call IzmjeniKnjiga method. IzmjeniKnjiga method need  Modify permission.");
            }
           
        }
        //[PrincipalPermission(SecurityAction.Demand, Role = "Modify")]
        public void IzmjeniUser(string username, string ime, string prezime, bool active)
        {
            CustomPrincipal principal = Thread.CurrentPrincipal as CustomPrincipal;
            if(Thread.CurrentPrincipal.IsInRole("Modify"))
            {
                if (DataBase.users.ContainsKey(username))
                {
                    DataBase.users[username].Ime = ime;
                    DataBase.users[username].Prezime = prezime;
                    DataBase.users[username].Aktivan = active;
                    Console.WriteLine("Korisnik uspesno izmjenjen.");
                    try
                    {
                        string createText = $"User {principal.Identity.Name} successfully accessed to IzmjeniUser method.";
                        FileHelper.WriteInTxt(createText);
                    }
                    catch(ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else
                {
                    //zamjeniti sa custom exceptions mozda
                    Console.WriteLine("Korisnik sa ovim ID-em ne postoji");
                }
            }
            else
            {
                try
                {
                    string createText = $"User {principal.Identity.Name} can not access to IzmjeniUser method. No modify permission.";
                    FileHelper.WriteInTxt(createText);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }

                string userName = Formater.ParseName(Thread.CurrentPrincipal.Identity.Name);
                throw new FaultException("User " + userName +
                    " try to call IzmjeniUser method. IzmjeniUser method need  Modify permission.");
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
