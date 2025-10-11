using System.ComponentModel.DataAnnotations;

namespace HairCareBackend.Models.DTOs;
public class CustomerDTO
{
 public int Id { get; set; }
  [Required]
  public string Name { get; set; }
  [Required]
  public string Password { get; set; }
}
