using System.ComponentModel.DataAnnotations;

namespace HairCareBackend.Models;

public class AppointmentServices
{
  public int Id { get; set; }
  [Required]
  public int AppointmentId { get; set; }
  public Appointment Appointment { get; set; }
  [Required]
  public int ServiceId { get; set; }
  public Service Service { get; set; }
}
