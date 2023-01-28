using System.Threading.Tasks;
using DesafioDotNet.Domain.Models;
using DesafioDotNet.Infra.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafioDotNet.Application.Controllers;

[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly DesafioDotNetDbContext _context;

    public ProductController(DesafioDotNetDbContext context) =>
        _context = context;


    [HttpGet]
    public async Task<List<Products>> GetAll() =>
        await _context.Products.ToListAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Products>> Get(int id)
    {
        var product = await _context.Products.FindAsync(id);

        if (product is null)
        {
            return NotFound();
        }

        return product;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Products product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Products product)
    {
        await _context.Products.FindAsync(id);

        if (product is null)
        {
            return NotFound();
        }

        _context.Products.Update(product);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var product = await _context.Products.FindAsync(id);

        if (product is null)
        {
            return NotFound();
        }

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}