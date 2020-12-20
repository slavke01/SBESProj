using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Korisnik
    {

        public string Username { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public List<Knjiga> Iznajmljene { get; set; }
        public bool Aktivan { get; set; }


        public Korisnik() { }

        public Korisnik(string user, string ime, string prezime , bool active) {
            this.Username = user;
            this.Ime = ime;
            this.Prezime = prezime;
            this.Aktivan = active;
            this.Iznajmljene = new List<Knjiga>();

        }
    }
}
