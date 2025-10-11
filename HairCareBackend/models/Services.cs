using System.ComponentModel.DataAnnotations;

namespace HairCareBackend.Models;

public class Service
{
  public int Id { get; set; }
  [Required]
  public string Type { get; set; }
  [Required]
  public decimal Price { get; set; }
}
