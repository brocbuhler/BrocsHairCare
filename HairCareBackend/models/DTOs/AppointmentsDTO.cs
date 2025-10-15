using System.ComponentModel.DataAnnotations;

namespace HairCareBackend.Models.DTOs;

public class AppointmentDTO
{
  public int Id { get; set; }
  [Required]
  public int StylistId { get; set; }
  public StylistDTO stylist { get; set; }
  [Required]
  public int CustomerId { get; set; }
  public CustomerDTO customer { get; set; }
  [Required]
    public List<ServiceDTO> AppointmentServices { get; set; }
  public DateTime AppointmentTime { get; set; }
  public decimal TotalPrice { get; set; }

}
