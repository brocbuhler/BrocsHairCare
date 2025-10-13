
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

//
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

app.Run();
