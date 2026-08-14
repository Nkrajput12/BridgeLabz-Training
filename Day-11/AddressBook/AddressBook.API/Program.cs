using Microsoft.EntityFrameworkCore;
using AddressBookWeb.Repository.Data;
using AddressBookWeb.Repository.Repositories;
using AddressBookWeb.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext configuration
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AddressBookDb")));

// Dependency Injection registrations
builder.Services.AddScoped<IAddressBookRepository, AddressBookRepository>();
builder.Services.AddScoped<IAddressBookService, AddressBookService>();

var app = builder.Build();

// Automatically apply any pending EF Core migrations on startup
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "AddressBook API v1");
        c.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
