using Microsoft.EntityFrameworkCore;
using VideogamesAPI.Model.Entities;

namespace VideogamesAPI.Data;

public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Developer> Developers { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<Platform> Platforms { get; set; }
}