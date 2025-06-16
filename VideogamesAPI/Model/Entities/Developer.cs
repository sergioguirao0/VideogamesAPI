using System.ComponentModel.DataAnnotations;

namespace VideogamesAPI.Model.Entities;

public class Developer
{
    public int Id { get; set; }
    [Required]
    public required string Name { get; set; }
    [Required]
    public required string Country { get; set; }
}