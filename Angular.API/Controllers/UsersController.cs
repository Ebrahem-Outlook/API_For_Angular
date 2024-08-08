using Angular.API.Database;
using Angular.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Angular.API.Controllers;

[Route("api/v1/[Controller]")]
[ApiController]
public sealed class UsersController(AppDbContext dbContext) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await dbContext.Users.ToListAsync());
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await dbContext.Users.FindAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> Create(User user)
    {
        await dbContext.Users.AddAsync(user);
        await dbContext.SaveChangesAsync();
        return Ok(user);
    }
}
