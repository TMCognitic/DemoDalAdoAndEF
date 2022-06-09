using Dal.Entities;

namespace Dal.Repository
{
    public interface IContactRepository
    {
        IEnumerable<Contact> Get();
        Contact? Get(int id);
        Contact Insert(Contact contact);
        bool Update(int id, Contact contact);
        bool Delete(int id);
    }
}