using Microsoft.EntityFrameworkCore;
using AddressBookWeb.Models;

namespace AddressBookWeb.Repository.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<AddressBook> Addressbooks { get; set; }
    }
}
