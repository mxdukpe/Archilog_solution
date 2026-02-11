using Archi.API.Data;
using Archi.Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Archi.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TacosController : ControllerBase
{
    private readonly ArchiDbContext _context;

    public TacosController(ArchiDbContext context)
    {
        _context = context;
    }

    // GET: api/Tacos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TacosModel>>> GetAll()
    {
        return await _context.Tacos.ToListAsync();
    }

    // GET: api/Tacos/5
    [HttpGet("{id}")]
    public async Task<ActionResult<TacosModel>> GetById(int id)
    {
        var taco = await _context.Tacos.FindAsync(id);

        if (taco == null)
        {
            return NotFound();
        }

        return taco;
    }

    // POST: api/Tacos
    [HttpPost]
    public async Task<ActionResult<TacosModel>> Post(TacosModel tacos)
    {
        _context.Tacos.Add(tacos);
        await _context.SaveChangesAsync();

        // Used nameof(GetById) to match the renamed method
        return CreatedAtAction(nameof(GetById), new { id = tacos.Id }, tacos);
    }

    // PUT: api/Tacos/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, TacosModel tacos)
    {
        if (id != tacos.Id)
        {
            return BadRequest();
        }

        _context.Entry(tacos).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TacosExists(id))
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

    // DELETE: api/Tacos/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var taco = await _context.Tacos.FindAsync(id);
        if (taco == null)
        {
            return NotFound();
        }

        _context.Tacos.Remove(taco);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool TacosExists(int id)
    {
        return _context.Tacos.Any(e => e.Id == id);
    }
}
