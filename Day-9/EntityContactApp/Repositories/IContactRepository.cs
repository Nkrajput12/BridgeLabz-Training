using EntityContactApp.Models;

namespace EntityContactApp.Repositories;

public interface IContactRepository
{
    Task<IEnumerable<Contact>> GetAllAsync();
    Task<Contact?> GetByIdAsync(int id);
    Task<Contact> AddAsync(Contact contact);
    Task<bool> UpdateAsync(Contact contact);
    Task<bool> DeleteAsync(int id);
}
