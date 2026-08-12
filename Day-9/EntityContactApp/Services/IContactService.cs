using EntityContactApp.Models;

namespace EntityContactApp.Services;

public interface IContactService
{
    Task<IEnumerable<Contact>> GetAllContactsAsync();
    Task<Contact?> GetContactAsync(int id);
    Task<Contact> CreateContactAsync(Contact contact);
    Task<bool> UpdateContactAsync(int id, Contact contact);
    Task<bool> DeleteContactAsync(int id);
}
