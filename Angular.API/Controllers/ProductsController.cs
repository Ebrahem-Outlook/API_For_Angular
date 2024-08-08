using Angular.API.Database;
using Angular.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Angular.API.Controllers;

[Route("api/v1/[Controller]")]
[ApiController]
public class ProductsController(AppDbContext dbContext) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetAll() 
    {
        return Ok(await dbContext.Products.ToListAsync());
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await dbContext.Products.FindAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {
        await dbContext.Products.AddAsync(product);
        await dbContext.SaveChangesAsync();
        return Ok(product);
    }
}
