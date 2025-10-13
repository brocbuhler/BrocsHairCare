using Microsoft.EntityFrameworkCore;
using HairCareBackend.Models;

public class HairCareDbContext : DbContext
{

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Stylist> Stylists { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Appointment> Appointments { get; set; }

  public HairCareDbContext(DbContextOptions<HairCareDbContext> context) : base(context) { }

  public HairCareDbContext() { }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    if (!optionsBuilder.IsConfigured)
    {
      optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=coman1209;Database=HairCare");
    }
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Customer>().HasData(new Customer[]
    {
      new Customer { Id = 1, Name = "Aaron", Password = "ClonesAreCool"},
      new Customer { Id = 2, Name = "Julia", Password = "AaronsHot"},
    });
    modelBuilder.Entity<Stylist>().HasData(new Stylist[]
    {
      new Stylist {Id = 1, IsActive = true, Name = "Matt"},
      new Stylist {Id = 2, IsActive = true, Name = "Jonah"},
      new Stylist {Id = 3, IsActive = true, Name = "Ben"},
      new Stylist {Id = 4, IsActive = true, Name = "Odie"},
    });
    modelBuilder.Entity<Service>().HasData(new Service[]
    {
      new Service {Id = 1, Price = 1, Type = "Haircut"},
      new Service {Id = 2, Price = 2, Type = "Coloring"},
      new Service {Id = 3, Price = 3, Type = "Beard Trim"},
    });
    modelBuilder.Entity<Appointment>().HasData(new Appointment[]
    {
      new Appointment {Id = 1, AppointmentTime = new DateTime(2025,12,12), CustomerId = 1, StylistId = 1 }
    });
  }
}
