using System.ComponentModel.DataAnnotations;
using HairCareBackend.Models.DTOs;

namespace HairCareBackend.Models;

public class AppointmentServicesDTO
{
  public int Id { get; set; }
  [Required]
  public int AppointmentId { get; set; }
  public AppointmentDTO Appointment { get; set; }
  [Required]
  public int ServiceId { get; set; }
  public ServiceDTO Service { get; set; }
}
