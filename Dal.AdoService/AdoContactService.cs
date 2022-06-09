using Dal.AdoService.Mappers;
using Dal.Entities;
using Dal.Repository;
using Tools.Connections;

namespace Dal.AdoService
{
    public class AdoContactService : IContactRepository
    {
        private readonly Connection _connection;

        public AdoContactService(Connection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Contact> Get()
        {
            Command command = new Command("Select Id, LastName, FirstName FROM Contact", false);
            IEnumerable<Contact> contacts = _connection.ExecuteReader(command, dr => dr.ToContact(), true);

            return contacts;
        }

        public Contact? Get(int id)
        {
            Command command = new Command("Select Id, LastName, FirstName FROM Contact WHERE Id = @Id", false);
            command.AddParameter("Id", id);

            return _connection.ExecuteReader(command, dr => dr.ToContact(), true).SingleOrDefault();
        }

        public Contact Insert(Contact contact)
        {
            Command command = new Command("Insert into Contact (LastName, FirstName) OUTPUT Inserted.Id VALUES (@LastName, @FirstName)", false);
            command.AddParameter("LastName", contact.LastName);
            command.AddParameter("FirstName", contact.FirstName);

            contact.Id = (int)_connection.ExecuteScalar(command)!;
            return contact;
        }

        public bool Update(int id, Contact contact)
        {
            Command command = new Command("Update Contact Set LastName = @LastName, FirstName = @FirstName WHERE Id = @Id", false);
            command.AddParameter("Id", id);
            command.AddParameter("LastName", contact.LastName);
            command.AddParameter("FirstName", contact.FirstName);

            return _connection.ExecuteNonQuery(command) == 1;
        }

        public bool Delete(int id)
        {
            Command command = new Command("Delete From Contact WHERE Id = @Id", false);
            command.AddParameter("Id", id);

            return _connection.ExecuteNonQuery(command) == 1;
        }
    }
}