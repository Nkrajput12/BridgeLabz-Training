using Microsoft.EntityFrameworkCore;
using AddressBookWeb.Models;
using AddressBookWeb.Repository.Data;

namespace AddressBookWeb.Repository.Repositories
{
    public class AddressBookRepository : IAddressBookRepository
    {
        private readonly AppDbContext _context;

        public AddressBookRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AddressBook>> GetAllAsync()
        {
            return await _context.Addressbooks.ToListAsync();
        }

        public async Task<AddressBook?> GetByIdAsync(int id)
        {
            return await _context.Addressbooks.FindAsync(id);
        }

        public async Task<AddressBook> AddAsync(AddressBook addressBook)
        {
            await _context.Addressbooks.AddAsync(addressBook);
            await _context.SaveChangesAsync();
            return addressBook;
        }

        public async Task<AddressBook?> UpdateAsync(AddressBook addressBook)
        {
            var existing = await _context.Addressbooks.FindAsync(addressBook.Id);
            if (existing == null)
            {
                return null;
            }

            existing.Name = addressBook.Name;
            existing.PhoneNumber = addressBook.PhoneNumber;
            existing.Email = addressBook.Email;
            existing.Address = addressBook.Address;
            existing.City = addressBook.City;
            existing.State = addressBook.State;
            existing.ZipCode = addressBook.ZipCode;

            _context.Addressbooks.Update(existing);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Addressbooks.FindAsync(id);
            if (entity == null)
            {
                return false;
            }

            _context.Addressbooks.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<AddressBook>> SearchByStateAsync(string state)
        {
            if (string.IsNullOrWhiteSpace(state))
            {
                return Enumerable.Empty<AddressBook>();
            }

            return await _context.Addressbooks
                .Where(a => a.State != null && a.State.Contains(state))
                .ToListAsync();
        }

        public async Task<IEnumerable<AddressBook>> SearchByCityAsync(string city)
        {
            if (string.IsNullOrWhiteSpace(city))
            {
                return Enumerable.Empty<AddressBook>();
            }

            return await _context.Addressbooks
                .Where(a => a.City != null && a.City.Contains(city))
                .ToListAsync();
        }
    }
}
