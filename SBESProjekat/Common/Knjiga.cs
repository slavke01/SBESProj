using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Knjiga
    {
        public string Id { get; set; }
        public string Naziv { get; set; }
        public string Zanr { get; set; }
        public Autor Pisac { get; set; }

        public Knjiga() { }

        public Knjiga(string id,string naziv, string zanr, string id_autora) {
            this.Id = id;
            this.Naziv= naziv;
            this.Zanr = zanr;

            this.Pisac = DataBase.autori[id_autora];
    }
    
    }
}
