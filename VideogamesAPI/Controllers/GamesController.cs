using Microsoft.AspNetCore.Mvc;
using VideogamesAPI.Model.Entities;
using VideogamesAPI.Model.Repositories;

namespace VideogamesAPI.Controllers;

[ApiController]
[Route("api/games")]
public class GamesController(IGameRepository gameService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> Post(Game game)
    {
        var developerExist = await gameService.CheckGameDeveloper(game);

        if (!developerExist)
        {
            return BadRequest($"El desarrollador de id {game.DeveloperId} no existe");
        }
        
        var canPost = await gameService.PostGame(game);

        if (!canPost)
        {
            return BadRequest();
        }

        return Ok();
    }

    [HttpGet]
    public async Task<IEnumerable<Game>> Get()
    {
        return await gameService.GetGames();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Game>> Get(int id)
    {
        var game = await gameService.GetGameById(id);

        if (game is null)
        {
            return NotFound();
        }

        return game;
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, Game game)
    {
        if (id != game.Id)
        {
            return BadRequest("Los ids deben coincidir");
        }

        var developerExist = await gameService.CheckGameDeveloper(game);

        if (!developerExist)
        {
            return BadRequest($"El desarrollador de id {game.DeveloperId} no existe");
        }
        
        var canUpdate = await gameService.PutGame(id, game);
        
        if (!canUpdate)
        {
            return BadRequest();
        }

        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var game = await gameService.GetGameById(id);

        if (game is null)
        {
            return NotFound();
        }

        var canDelete = await gameService.DeleteGame(game);

        if (!canDelete)
        {
            return BadRequest();
        }

        return Ok();
    }
}