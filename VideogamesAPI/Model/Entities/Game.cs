using System.ComponentModel.DataAnnotations;

namespace VideogamesAPI.Model.Entities;

public class Game
{
    public int Id { get; set; }
    [Required]
    public required string Name { get; set; }
    public int ReleaseYear { get; set; }
    
    public int DeveloperId { get; set; }
    public Developer? Developer { get; set; }

    public int PlatformId { get; set; }
    public Platform? Platform { get; set; }
}