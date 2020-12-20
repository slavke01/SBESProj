using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class DataBase
    {
        public static Dictionary<string, Korisnik> users = new Dictionary<string, Korisnik>();

        public static Dictionary<string, Knjiga> knjige = new Dictionary<string, Knjiga>();

        public static Dictionary<string, Autor> autori = new Dictionary<string, Autor>();
    }
}
