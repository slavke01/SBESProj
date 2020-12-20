using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Common
{
    [ServiceContract]
    public interface IServiceContract
    {
        [OperationContract]
        void AddUser(Korisnik korisnik);

        [OperationContract]
        void AddAutor(Autor autor);

        [OperationContract]
        void AddKnjiga(Knjiga knjiga);

        [OperationContract]
        void DeleteUser(string username);

        [OperationContract]
        void DeleteAutor(string id);

        [OperationContract]
        void DeleteKnjiga(string id);

    }
}
