using System.ComponentModel.DataAnnotations;

namespace HairCareBackend.Models;

public class Appointment
{
  public int Id { get; set; }
  [Required]
  public int StylistId { get; set; }
  public Stylist stylist { get; set; }
  [Required]
  public int CustomerId { get; set; }
  public Customer customer { get; set; }
  [Required]
  public List<Service> Services { get; set; } = new List<Service>();
  public DateTime AppointmentTime { get; set; }
}
