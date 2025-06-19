using Microsoft.EntityFrameworkCore;
using VideogamesAPI.Data;
using VideogamesAPI.Model.Entities;
using VideogamesAPI.Model.Repositories;

namespace VideogamesAPI.Services;

public class GameService(ApplicationDbContext context) : IGameRepository
{
    public async Task<IEnumerable<Game>> GetGames()
    {
        return await context.Games.ToListAsync();
    }

    public async Task<Game?> GetGameById(int id)
    {
        return await context.Games.FirstOrDefaultAsync(g => g.Id == id);
    }

    public async Task<bool> PostGame(Game game)
    {
        try
        {
            context.Add(game);
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
            return false;
        }
    }

    public async Task<bool> CheckGameDeveloper(Game game)
    {
        return await context.Developers.AnyAsync(dev => dev.Id == game.DeveloperId);
    }

    public async Task<bool> PutGame(int id, Game game)
    {
        try
        {
            if (id != game.Id)
            {
                return false;
            }

            context.Update(game);
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
            return false;
        }
    }

    public async Task<bool> DeleteGame(Game game)
    {
        try
        {
            context.Remove(game);
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