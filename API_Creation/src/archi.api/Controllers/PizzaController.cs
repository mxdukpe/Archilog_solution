using Archi.API.Data;
using Archi.Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Archi.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PizzaController : ControllerBase
{
    private readonly ArchiDbContext _context;

    public PizzaController(ArchiDbContext context)
    {
        _context = context;
    }

    // GET: api/Pizza
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PizzaModel>>> GetAll()
    {
        return await _context.Pizzas.ToListAsync();
    }

    // GET: api/Pizza/5
    [HttpGet("{id}")]
    public async Task<ActionResult<PizzaModel>> GetById(int id)
    {
        var pizza = await _context.Pizzas.FindAsync(id);

        if (pizza == null)
        {
            return NotFound();
        }

        return pizza;
    }

    // POST: api/Pizza
    [HttpPost]
    public async Task<ActionResult<PizzaModel>> Post(PizzaModel pizza)
    {
        _context.Pizzas.Add(pizza);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = pizza.Id }, pizza);
    }

    // PUT: api/Pizza/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, PizzaModel pizza)
    {
        if (id != pizza.Id)
        {
            return BadRequest();
        }

        _context.Entry(pizza).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PizzaExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/Pizza/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var pizza = await _context.Pizzas.FindAsync(id);
        if (pizza == null)
        {
            return NotFound();
        }

        _context.Pizzas.Remove(pizza);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PizzaExists(int id)
    {
        return _context.Pizzas.Any(e => e.Id == id);
    }
}
