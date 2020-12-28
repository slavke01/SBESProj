using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
namespace Common
{
    [DataContract]
    public class Korisnik
    {

        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Ime { get; set; }
        [DataMember]
        public string Prezime { get; set; }
        [DataMember]
        public List<Knjiga> Iznajmljene { get; set; }
        [DataMember]
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
