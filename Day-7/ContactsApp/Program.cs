using ContactsApp.Models;
using ContactsApp.Repositories;
using ContactsApp.Services;

// ── Builder ───────────────────────────────────────────────────────────────────
var builder = WebApplication.CreateBuilder(args);

// Read connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("ContactDb")!;

// Register Repository and Service in DI container
builder.Services.AddSingleton(new ContactRepository(connectionString));
builder.Services.AddSingleton<ContactService>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ── App ───────────────────────────────────────────────────────────────────────
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();



// GET /contacts — get all contacts
app.MapGet("/contacts", (ContactService service) =>
{
    var contacts = service.GetAllContacts();
    return Results.Ok(contacts);
});

// GET /contacts/{id} — get one contact by Id
app.MapGet("/contacts/{id}", (int id, ContactService service) =>
{
    var contact = service.GetContact(id);
    return contact is not null
        ? Results.Ok(contact)
        : Results.NotFound(new { message = $"Contact with Id {id} not found." });
});

// POST /contacts — add a new contact
app.MapPost("/contacts", (Contact contact, ContactService service) =>
{
    int newId = service.AddContact(contact);
    return Results.Created($"/contacts/{newId}", new { id = newId });
});

// PUT /contacts/{id} — update an existing contact
app.MapPut("/contacts/{id}", (int id, Contact contact, ContactService service) =>
{
    contact.Id = id;    // make sure the Id matches the route
    bool updated = service.UpdateContact(contact);
    return updated
        ? Results.Ok(new { message = "Contact updated successfully." })
        : Results.NotFound(new { message = $"Contact with Id {id} not found." });
});

// DELETE /contacts/{id} — delete a contact
app.MapDelete("/contacts/{id}", (int id, ContactService service) =>
{
    bool deleted = service.DeleteContact(id);
    return deleted
        ? Results.Ok(new { message = "Contact deleted successfully." })
        : Results.NotFound(new { message = $"Contact with Id {id} not found." });
});

app.Run();
