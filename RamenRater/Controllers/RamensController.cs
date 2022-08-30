using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RamenRater.Models;

namespace RamenRater.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class RamensController : ControllerBase
  {
    private readonly RamenRaterContext _db;

    public RamensController(RamenRaterContext db)
    {
      _db = db;
    }

    // GET api/Ramens
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Ramen>>> Get()
    {
      return await _db.Ramens.ToListAsync();
    }

    // POST api/Ramens
    [HttpPost]
    public async Task<ActionResult<Ramen>> Post(Ramen ramen)
    {
      _db.Ramens.Add(ramen);
      await _db.SaveChangesAsync();

      return CreatedAtAction("Post", new { id = ramen.RamenId }, ramen);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Animal>> GetRamen(int id)
    {
      var ramen = await _db.Ramens.FindAsync(id);

      if (ramen == null)
      {
        return NotFound();
      }

      return ramen;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Ramen ramen)
    {
      if (id != ramen.RamenId)
      {
        return BadRequest();
      }

      _db.Entry(ramen).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!RamenExists(id))
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

    private bool RamenExists(int id)
    {
      return _db.Ramens.Any(e => e.RamenId == id);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRamen(int id)
    {
      var ramen = await _db.Ramens.FindAsync(id);
      if (ramen == null)
      {
        return NotFound();
      }

      _db.Ramens.Remove(ramen);
      await _db.SaveChangesAsync();

      return NoContent();
    }

  }
}