using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
   public class Autor
    {
        public string Id { get; set; }
        public string Ime { get; set; }

        public string Prezime { get; set; }

        public Autor() { }

        public Autor(string id,string ime, string prezime) {

            this.Id = id;
            this.Ime = ime;
            this.Prezime = prezime;

        }
    }
}
