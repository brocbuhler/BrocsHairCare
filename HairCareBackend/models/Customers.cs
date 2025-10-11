using System.ComponentModel.DataAnnotations;

namespace HairCareBackend.Models;

public class Customer
{
  public int Id { get; set; }
  [Required]
  public string Name { get; set; }
  [Required]
  public string Password { get; set; }
}
