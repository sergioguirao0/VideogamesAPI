using VideogamesAPI.Model.Entities;

namespace VideogamesAPI.Model.Repositories;

public interface IGameRepository
{
    Task<IEnumerable<Game>> GetGames();
    Task<Game?> GetGameById(int id);
    Task<bool> PostGame(Game game);
    Task<bool> CheckGameDeveloper(Game game);
    Task<bool> PutGame(int id, Game game);
    Task<bool> DeleteGame(Game game);
}