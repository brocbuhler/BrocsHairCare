using System.ComponentModel.DataAnnotations;

namespace HairCareBackend.Models.DTOs;

public class ServiceDTO
{
  public int Id { get; set; }
  [Required]
  public string Type { get; set; }
  [Required]
  public decimal Price { get; set; }
  public List<AppointmentDTO> Appointments { get; set; }
  public List<AppointmentServicesDTO> AppointmentServices { get; set; }

}
