using Microsoft.AspNetCore.Mvc;
using VideogamesAPI.Model.Entities;
using VideogamesAPI.Model.Repositories;

namespace VideogamesAPI.Controllers;

[ApiController]
[Route("api/developers")]
public class DevelopersController(IDeveloperRepository developerService) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<Developer>> Get()
    {
        return await developerService.GetDevelopers();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Developer>> Get(int id)
    {
        var developer = await developerService.GetDeveloperById(id);

        if (developer is null)
        {
            return NotFound();
        }

        return developer;
    }
    
    [HttpPost]
    public async Task<ActionResult> Post(Developer developer)
    {
        var canPost = await developerService.PostDeveloper(developer);

        if (!canPost)
        {
            return BadRequest();
        }

        return Ok();
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, Developer developer)
    {
        if (id != developer.Id)
        {
            return BadRequest("Los ids deben coincidir");
        }

        var canUpdate = await developerService.PutDeveloper(id, developer);
        
        if (!canUpdate)
        {
            return BadRequest();
        }

        return Ok();
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var developer = await developerService.GetDeveloperById(id);

        if (developer is null)
        {
            return NotFound();
        }

        var canDelete = await developerService.DeleteDeveloper(developer);

        if (!canDelete)
        {
            return BadRequest();
        }

        return Ok();
    }
}