using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Knjiga
    {

        public string Naziv { get; set; }
        public string Zanr { get; set; }
        public Autor Pisac { get; set; }

        public Knjiga() { }

        public Knjiga(string naziv, string zanr, Autor autor) {

            this.Naziv= naziv;
            this.Zanr = zanr;
            this.Pisac = autor;
    }
    
    }
}
