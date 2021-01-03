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
        void AddUser(string username,string ime,string prezime, bool active);

        [OperationContract]
        void AddAutor(string id,string ime,string prezme);

        [OperationContract]
        void AddKnjiga(string id,string naziv,string zanr,string id_autora);

        [OperationContract]
        void DeleteUser(string username);

        [OperationContract]
        void DeleteAutor(string id);

        [OperationContract]
        void DeleteKnjiga(string id);

        [OperationContract]
        string ShowUsers();

        [OperationContract]
        string ShowAutors();

        [OperationContract]
        string ShowBooks();

        [OperationContract]
        void IzmjeniUser(string username,string ime, string prezime, bool active);

        [OperationContract]
        void IzmjeniAutor(string id, string ime, string prezime);

        [OperationContract]
        void IzmjeniKnjiga(string id, string naziv, string zanr);

        [OperationContract]
        void AddBookToUser(string id, string username);

        [OperationContract]
        string ShowIznajmljene(string username);
    }
}
