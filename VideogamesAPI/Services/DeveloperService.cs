using Microsoft.EntityFrameworkCore;
using VideogamesAPI.Data;
using VideogamesAPI.Model.Entities;
using VideogamesAPI.Model.Repositories;

namespace VideogamesAPI.Services;

public class DeveloperService(ApplicationDbContext context) : IDeveloperRepository
{
    public async Task<bool> PostDeveloper(Developer developer)
    {
        try
        {
            context.Add(developer);
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
            return false;
        }
    }

    public async Task<IEnumerable<Developer>> GetDevelopers()
    {
        return await context.Developers.ToListAsync();
    }

    public async Task<Developer?> GetDeveloperById(int id)
    {
        return await context.Developers.FirstOrDefaultAsync(dev => dev.Id == id);
    }

    public async Task<bool> PutDeveloper(int id, Developer developer)
    {
        try
        {
            if (id != developer.Id)
            {
                return false;
            }
            
            context.Update(developer);
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
            return false;
        }
    }

    public async Task<bool> DeleteDeveloper(Developer developer)
    {
        try
        {
            context.Remove(developer);
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
            return false;
        }
    }
}