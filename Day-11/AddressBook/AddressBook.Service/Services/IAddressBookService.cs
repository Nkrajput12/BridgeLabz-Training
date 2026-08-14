using AddressBookWeb.Models;

namespace AddressBookWeb.Service.Services
{
    public interface IAddressBookService
    {
        Task<IEnumerable<AddressBook>> GetAllAsync();
        Task<AddressBook?> GetByIdAsync(int id);
        Task<AddressBook> AddAsync(AddressBook addressBook);
        Task<AddressBook?> UpdateAsync(AddressBook addressBook);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<AddressBook>> SearchByStateAsync(string state);
        Task<IEnumerable<AddressBook>> SearchByCityAsync(string city);
    }
}
