using VideogamesAPI.Model.Entities;

namespace VideogamesAPI.Model.Repositories;

public interface IDeveloperRepository
{
    Task<bool> PostDeveloper(Developer developer);
    Task<IEnumerable<Developer>> GetDevelopers();
    Task<Developer?> GetDeveloperById(int id);
    Task<bool> PutDeveloper(int id, Developer developer);
    Task<bool> DeleteDeveloper(Developer developer);
}