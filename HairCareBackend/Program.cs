
using HairCareBackend.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using HairCareBackend.Models.DTOs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddNpgsql<HairCareDbContext>(builder.Configuration["HairCareDbConnectionString"]);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Home Page
app.MapGet("/api/stylists", (HairCareDbContext db) =>
{
    return db.Stylists
    .Where(s => s.IsActive == true)
    .Select(s => new StylistDTO
    {
        Id = s.Id,
        Name = s.Name,
        IsActive = s.IsActive
    }).ToList();
});
//

// Appointment View ~ hard
//

//Get Appointment Price ~ hard 
//

// Appointment Create ~ hard
//

// Appointment Edit Service List ~ medium
//

// Appointment Delete ~ easy
app.MapDelete("/api/appointments/{id}", (HairCareDbContext db, int id) =>
{
    Appointment appointment = db.Appointments.FirstOrDefault(a => a.Id == id);
    if (appointment == null)
    {
        return Results.NotFound();
    }
    db.Appointments.Remove(appointment);
    db.SaveChanges();
    return Results.NoContent();
});
//

//Customer Create ~ easy
app.MapPost("/api/customers", (HairCareDbContext db, Customer customer) =>
{
    db.Customers.Add(customer);
    db.SaveChanges();
    return Results.Created($"/api/customers/{customer.Id}", customer);
});
//

// Services Get ~ easy
app.MapGet("/api/services/{id}", (HairCareDbContext db, int id) =>
{
    return db.Services
    .Where(s => s.Id == id)
    .Select(s => new ServiceDTO
    {
        Id = s.Id,
        Type = s.Type,
        Price = s.Price
    }).ToList();
});
//

// Add Stylist ~ easy
app.MapPost("/api/stylists", (HairCareDbContext db, Stylist stylist) =>
{
    db.Stylists.Add(stylist);
    db.SaveChanges();
    return Results.Created($"/api/stylist/{stylist.Id}", stylist);
});
//

// Deactivate Stylist ~ easy
app.MapPatch("/api/stylists/{id}", (HairCareDbContext db, int id, Stylist Update) =>
{
    Stylist stylist = db.Stylists.FirstOrDefault(s => s.Id == id);
    stylist.IsActive = Update.IsActive;
    db.SaveChanges();
    return Results.NoContent();
});
//

//Customer Get ~ easy
app.MapGet("/api/customers/{id}", (HairCareDbContext db, int id) =>
{
    return db.Customers
    .Where(c => c.Id == id)
    .Select(c => new CustomerDTO
    {
        Id = c.Id,
        Name = c.Name,
        Password = c.Password
    }).ToList();
});
app.Run();
