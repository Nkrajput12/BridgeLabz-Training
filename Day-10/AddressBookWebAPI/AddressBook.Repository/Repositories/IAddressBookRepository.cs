using AddressBookWeb.Models;

namespace AddressBookWeb.Repository.Repositories
{
    public interface IAddressBookRepository
    {
        Task<IEnumerable<AddressBook>> GetAllAsync();
        Task<AddressBook?> GetByIdAsync(int id);
        Task<AddressBook> AddAsync(AddressBook addressBook);
        Task<AddressBook?> UpdateAsync(AddressBook addressBook);
        Task<bool> DeleteAsync(int id);
    }
}
