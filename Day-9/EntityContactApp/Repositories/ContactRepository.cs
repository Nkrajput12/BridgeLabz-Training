using EntityContactApp.Data;
using EntityContactApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityContactApp.Repositories;

public class ContactRepository : IContactRepository
{
    private readonly AppDbContext _db;

    public ContactRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Contact>> GetAllAsync()
    {
        return await _db.Contacts
                        .OrderBy(c => c.LastName)
                        .ThenBy(c => c.FirstName)
                        .ToListAsync();
    }

    public async Task<Contact?> GetByIdAsync(int id)
    {
        return await _db.Contacts.FindAsync(id);
    }

    public async Task<Contact> AddAsync(Contact contact)
    {
        _db.Contacts.Add(contact);
        await _db.SaveChangesAsync();
        return contact;
    }

    public async Task<bool> UpdateAsync(Contact contact)
    {
        var existing = await _db.Contacts.FindAsync(contact.Id);
        if (existing is null) return false;

        existing.FirstName   = contact.FirstName;
        existing.LastName    = contact.LastName;
        existing.Email       = contact.Email;
        existing.PhoneNumber = contact.PhoneNumber;

        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var contact = await _db.Contacts.FindAsync(id);
        if (contact is null) return false;

        _db.Contacts.Remove(contact);
        await _db.SaveChangesAsync();
        return true;
    }
}
