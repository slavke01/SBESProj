using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
   public class Autor
    {

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public Autor() { }

        public Autor(string ime, string prezime) {

            this.Ime = ime;
            this.Prezime = prezime;

        }
    }
}
