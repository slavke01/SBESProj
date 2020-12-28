using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Common
{

    [DataContract]
   public class Autor
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Ime { get; set; }
        [DataMember]
        public string Prezime { get; set; }

        public Autor() { }

        public Autor(string id,string ime, string prezime) {

            this.Id = id;
            this.Ime = ime;
            this.Prezime = prezime;

        }
    }
}
