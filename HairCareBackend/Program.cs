
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

//Get Appointment Price ~ hard
app.MapGet("/api/appointments/{id}", (HairCareDbContext db, int id) =>
{
    return db.Appointments
    .Include(a => a.stylist)
    .Include(a => a.customer)
    .Include(a => a.AppointmentServices)
        .ThenInclude(app => app.Service)
    .Where(a => a.Id == id)
    .Select(a => new AppointmentDTO
    {
        Id = a.Id,
        StylistId = a.StylistId,
        stylist = new StylistDTO
        {
            Id = a.stylist.Id,
            Name = a.stylist.Name,
            IsActive = a.stylist.IsActive
        },
        CustomerId = a.CustomerId,
        customer = new CustomerDTO
        {
            Id = a.customer.Id,
            Name = a.customer.Name,
            Password = a.customer.Password
        },
        AppointmentServices = a.AppointmentServices
        .Select(s => new ServiceDTO
        {
            Id = s.Service.Id,
            Type = s.Service.Type,
            Price = s.Service.Price
        }).ToList(),
        AppointmentTime = a.AppointmentTime,
        TotalPrice = a.AppointmentServices.Sum(app => app.Service.Price)
    }).FirstOrDefault();
});
//

// Appointment Create ~ hard
// app.MapPost("/api/appointments", (HairCareDbContext db, Appointment appointment) =>
// {
//     var serviceIds = appointment.Services.Select(s => s.Id).ToList();
//     var existingServices = db.Services
//         .Where(s => serviceIds.Contains(s.Id))
//         .ToList();
//     appointment.Services = existingServices;
//     db.Appointments.Add(appointment);
//     db.SaveChanges();
//     return Results.Created($"/api/appointments/{appointment.Id}", appointment);
// });
//

// Appointment Edit Service List ~ medium
// app.MapPatch("/api/appointments/{id}", (HairCareDbContext db, int id, Appointment Update) =>
// {
//     Appointment appointment = db.Appointments.FirstOrDefault(a => a.Id == id);
//     if (appointment == null)
//     {
//         return Results.NotFound();
//     }
//     appointment.Services = Update.Services;
//     db.SaveChanges();
//     return Results.NoContent();
// });
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
