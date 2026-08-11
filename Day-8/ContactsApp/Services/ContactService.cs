using ContactsApp.Models;
using ContactsApp.Repositories;

namespace ContactsApp.Services;

public class ContactService
{
    private readonly ContactRepository _repo;

    public ContactService(ContactRepository repo)
    {
        _repo = repo;
    }

    public List<Contact> GetAllContacts()
    {
        return _repo.GetAll();
    }

    public Contact? GetContact(int id)
    {
        return _repo.GetById(id);
    }

    public int AddContact(Contact contact)
    {
        return _repo.Add(contact);
    }

    public bool UpdateContact(Contact contact)
    {
        return _repo.Update(contact);
    }

    public bool DeleteContact(int id)
    {
        return _repo.Delete(id);
    }
}
