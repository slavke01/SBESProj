using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    [DataContract]
    public class Knjiga
    {

        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Naziv { get; set; }
        [DataMember]
        public string Zanr { get; set; }
        [DataMember]
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
