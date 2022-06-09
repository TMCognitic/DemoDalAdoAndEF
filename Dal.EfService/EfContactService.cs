using Dal.Contexts;
using Dal.Entities;
using Dal.Repository;

namespace Dal.EfService
{
    public class EfContactService : IContactRepository
    {
        private readonly ContactDbContext _contactDbContext;
        public EfContactService(ContactDbContext contactDbContext)
        {
            _contactDbContext = contactDbContext;
        }

        public IEnumerable<Contact> Get()
        {
            return _contactDbContext.Contacts;
        }

        public Contact? Get(int id)
        {
            return _contactDbContext.Find<Contact>(id);
        }

        public Contact Insert(Contact contact)
        {
            _contactDbContext.Contacts.Add(contact);
            _contactDbContext.SaveChanges();
            _contactDbContext.Entry(contact).Reload();
            return contact;
        }

        public bool Update(int id, Contact contact)
        {
            _contactDbContext.Attach(contact);
            return _contactDbContext.SaveChanges() == 1;
        }
        public bool Delete(int id)
        {
            Contact? contact = _contactDbContext.Find<Contact>(id);

            if (contact is null)
                return false;

            _contactDbContext.Contacts.Remove(contact);
            return _contactDbContext.SaveChanges() == 1;
        }
    }
}