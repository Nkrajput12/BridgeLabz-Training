using EntityContactApp.Models;
using EntityContactApp.Repositories;

namespace EntityContactApp.Services;

public class ContactService : IContactService
{
    private readonly IContactRepository _repo;

    public ContactService(IContactRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<Contact>> GetAllContactsAsync()
    {
        return await _repo.GetAllAsync();
    }

    public async Task<Contact?> GetContactAsync(int id)
    {
        return await _repo.GetByIdAsync(id);
    }

    public async Task<Contact> CreateContactAsync(Contact contact)
    {
        contact.CreatedAt = DateTime.UtcNow;
        return await _repo.AddAsync(contact);
    }

    public async Task<bool> UpdateContactAsync(int id, Contact contact)
    {
        contact.Id = id;
        return await _repo.UpdateAsync(contact);
    }

    public async Task<bool> DeleteContactAsync(int id)
    {
        return await _repo.DeleteAsync(id);
    }
}
