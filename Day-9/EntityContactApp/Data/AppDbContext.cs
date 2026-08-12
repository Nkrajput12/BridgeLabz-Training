using EntityContactApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityContactApp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Contact> Contacts { get; set; }
}
