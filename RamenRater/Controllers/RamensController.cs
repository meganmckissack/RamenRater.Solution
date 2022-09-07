using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
// using Microsoft.AspNetCore.Mvc.Versioning;
using RamenRater.Models;

namespace RamenRater.Controllers
{
  [ApiVersion("1.0")]
  [Route("api/Ramens")]
  // [Route("api/[controller]")]
  // [ApiController]
  public class RamensV1Controller : ControllerBase
  {
    private readonly RamenRaterContext _db;

    public RamensV1Controller(RamenRaterContext db)
    {
      _db = db;
    }

    // GET api/Ramens
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Ramen>>> Get()
    {
      return await _db.Ramens.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Ramen>> Post(Ramen ramen)
    {
      _db.Ramens.Add(ramen);
      await _db.SaveChangesAsync();

      return CreatedAtAction("Post", new { id = ramen.RamenId }, ramen);
    }
  }
}


namespace RamenRater.Controllers
{
  [ApiVersion("2.0")]
  [Route("api/{v:apiVersion}Ramens")]
  // [Route("api/{v:apiVersion}[controller]")]
  // [ApiController]
  public class RamensV2Controller : ControllerBase
  {
    private readonly RamenRaterContext _db;

    public RamensV2Controller(RamenRaterContext db)
    {
      _db = db;
    }

    // GET api/Ramens
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Ramen>>> Get(string location, string type, int starRating)
    {
      var query = _db.Ramens.AsQueryable();

      if(location != null)
      {
        query = query.Where(entry => entry.Location == location);
      }

      if(type != null)
      {
        query = query.Where(entry => entry.Type == type);
      }

      if(starRating > 0 && starRating == 5)
      {
        query = query.Where(entry => entry.Rating == starRating);
      }

      if(starRating > 0 && starRating == 4)
      {
        query = query.Where(entry => entry.Rating == starRating);
      }

      if(starRating > 0 && starRating == 3)
      {
        query = query.Where(entry => entry.Rating == starRating);
      }

      if(starRating > 0 && starRating == 2)
      {
        query = query.Where(entry => entry.Rating == starRating);
      }

      if(starRating > 0 && starRating == 1)
      {
        query = query.Where(entry => entry.Rating == starRating);
      }

      return await query.ToListAsync();
      
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
    public async Task<ActionResult<Ramen>> GetRamen(int id)
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