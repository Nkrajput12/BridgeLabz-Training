using AddressBookWeb.Models;
using AddressBookWeb.Repository.Repositories;

namespace AddressBookWeb.Service.Services
{
    public class AddressBookService : IAddressBookService
    {
        private readonly IAddressBookRepository _repository;

        public AddressBookService(IAddressBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<AddressBook>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<AddressBook?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<AddressBook> AddAsync(AddressBook addressBook)
        {
            return await _repository.AddAsync(addressBook);
        }

        public async Task<AddressBook?> UpdateAsync(AddressBook addressBook)
        {
            return await _repository.UpdateAsync(addressBook);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<AddressBook>> SearchByStateAsync(string state)
        {
            return await _repository.SearchByStateAsync(state);
        }

        public async Task<IEnumerable<AddressBook>> SearchByCityAsync(string city)
        {
            return await _repository.SearchByCityAsync(city);
        }
    }
}
