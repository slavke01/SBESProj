using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Meni
    {

        public static void ShowMeni(ClientProxy proxy) {

            int input;
            int kor;
            int autor;
            int knjiga;
            do
            {
                Console.WriteLine("Unesite redni broj operacija koje zelite:");
                Console.WriteLine("1. Rad sa korisnikom.");
                Console.WriteLine("2. Rad sa autorima.");
                Console.WriteLine("3. Rad sa knjigama.");
                Console.WriteLine("0. Izlaz");
                input = Int32.Parse(Console.ReadLine());
                switch (input) {

                    case 1:
                        do
                        {
                            Console.WriteLine("Unesite redni broj operacija koje zelite:");
                            Console.WriteLine("1. Dodavanje korisnika.");
                            Console.WriteLine("2. Izmjena korisnika.");
                            Console.WriteLine("3. Brisanje Korisnika.");
                            Console.WriteLine("4. Ispisi sve korisnike.");
                            Console.WriteLine("0. Izlaz");
                            kor = Int32.Parse(Console.ReadLine());

                            switch (kor) {
                                case 1:
                                    
                                    Console.WriteLine("Dodavanje novog korinika");

                                    Console.WriteLine("Unesite korisnicko ime korisnika: ");
                                    string username = Console.ReadLine();
                                    Console.WriteLine("Unesite ime korisnika: ");
                                    string ime =Console.ReadLine();
                                    Console.WriteLine("Unesite prezime korisnika:");
                                    string prezime = Console.ReadLine();
                                    Console.WriteLine("Da li je korisnik aktivan: T/F");
                                    string aktivan = Console.ReadLine();
                                    bool active;
                                    if (aktivan == "T") active = true;
                                    else active = false;
                                    try
                                    {
                                        proxy.AddUser(username, ime, prezime, active);
                                    }
                                    catch (Exception e) {
                                        Console.WriteLine("Eror uhvacen");
                                    }
                                    break;
                                case 2:
                                    Console.WriteLine("Izmjena korisnika.");
                                    Console.WriteLine("Unesite korisnicko ime korisnika koji se mjenja: ");
                                    username = Console.ReadLine();
                                    Console.WriteLine("Unesite novo ime korisnika: ");
                                    ime = Console.ReadLine();
                                    Console.WriteLine("Unesite novo prezime korisnika:");
                                    prezime = Console.ReadLine();
                                    Console.WriteLine("Da li je korisnik i dalje aktivan: T/F");
                                    aktivan = Console.ReadLine();
                                   
                                    if (aktivan == "T") active = true;
                                    else active = false;
                                    proxy.IzmjeniUser(username,ime,prezime,active);


                                    break;
                                case 3:

                                    Console.WriteLine("Unesite korisnicko ime korisnika koji se brise.");
                                    username = Console.ReadLine();
                                    proxy.DeleteUser(username);
                                    break;

                                case 4:
                                    Console.WriteLine(proxy.ShowUsers());
                                    break;
                            }


                        } while (kor != 0);
                        break;
                    case 2:
                        do {
                            Console.WriteLine("Unesite redni broj operacija koje zelite:");
                            Console.WriteLine("1. Dodavanje autora.");
                            Console.WriteLine("2. Izmjena autora.");
                            Console.WriteLine("3. Brisanje autora.");
                            Console.WriteLine("4. Prikazi sve autore.");
                            Console.WriteLine("0. Izlaz");
                            autor = Int32.Parse(Console.ReadLine());

                            switch (autor)
                            {
                                case 1:

                                    Console.WriteLine("Dodavanje novog autora");

                                    Console.WriteLine("Unesite id autora: ");
                                    string id = Console.ReadLine();
                                    Console.WriteLine("Unesite ime autora: ");
                                    string ime = Console.ReadLine();
                                    Console.WriteLine("Unesite prezime autora:");
                                    string prezime = Console.ReadLine();
                                    
                                    proxy.AddAutor(id, ime, prezime);
                                    break;
                                case 2:
                                    Console.WriteLine("Izmjena autora.");
                                    Console.WriteLine("Unesite id autora koji se mjenja.");
                                    id = Console.ReadLine();
                                    Console.WriteLine("Unesite novo ime autora: ");
                                    ime = Console.ReadLine();
                                    Console.WriteLine("Unesite novo prezime autora:");
                                    prezime = Console.ReadLine();
                                    proxy.IzmjeniAutor(id,ime,prezime);
                                    break;
                                case 3:

                                    Console.WriteLine("Unesite id autora koji se brise.");
                                     id = Console.ReadLine();
                                    proxy.DeleteAutor(id);
                                    break;
                                case 4:
                                    Console.WriteLine(proxy.ShowAutors());

                                    break;
                            }



                        } while (autor!=0);


                        break;
                    case 3:
                        do
                        {
                            Console.WriteLine("Unesite redni broj operacija koje zelite:");
                            Console.WriteLine("1. Dodavanje knjige.");
                            Console.WriteLine("2. Izmjena knjige.");
                            Console.WriteLine("3. Brisanje knjige.");
                            Console.WriteLine("4. Prikazi sve knjige.");
                            Console.WriteLine("0. Izlaz");
                            knjiga = Int32.Parse(Console.ReadLine());

                            switch (knjiga)
                            {
                                case 1:

                                    Console.WriteLine("Dodavanje nove knjige");

                                    Console.WriteLine("Unesite id knjige: ");
                                    string id = Console.ReadLine();
                                    Console.WriteLine("Unesite naziv knjige: ");
                                    string naziv = Console.ReadLine();
                                    Console.WriteLine("Unesite zanr knjige:");
                                    string zanr = Console.ReadLine();
                                    Console.WriteLine("Unesite id autora knjige:");
                                    string id_autora = Console.ReadLine();
                                    proxy.AddKnjiga(id,naziv,zanr,id_autora);
                                    break;
                                case 2:
                                    Console.WriteLine("Izmjena knjige");
                                    Console.WriteLine("Unesite ID knjige koja se mijenja.");
                                    id = Console.ReadLine();
                                    Console.WriteLine("Unesite novi naziv knjige: ");
                                    naziv = Console.ReadLine();
                                    Console.WriteLine("Unesite novi zanr knjige:");
                                    zanr = Console.ReadLine();
                                    proxy.IzmjeniKnjiga(id,naziv,zanr);

                                    break;
                                case 3:

                                    Console.WriteLine("Unesite id knjige koja se brise.");
                                    id = Console.ReadLine();
                                    proxy.DeleteKnjiga(id);
                                    break;
                                case 4:
                                    Console.WriteLine(proxy.ShowBooks()); 
                                    break;
                            }



                        } while (knjiga != 0);


                        break;

                }




            } while (input != 0);

        }

        

    }
}
