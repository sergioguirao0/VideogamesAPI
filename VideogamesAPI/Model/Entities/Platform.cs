using System.ComponentModel.DataAnnotations;

namespace VideogamesAPI.Model.Entities;

public class Platform
{
    public int Id { get; set; }
    [Required]
    public required string Name { get; set; }
    public int ReleaseYear { get; set; }
    public List<Game> Games { get; set; } = new List<Game>();
}