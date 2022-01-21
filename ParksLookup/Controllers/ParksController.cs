using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParksLookup.Models;

namespace ParksLookup.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ParksController : ControllerBase
  {
    private readonly ParksLookupContext _db;
    
    public ParksController(ParksLookupContext db)
    {
      _db = db;
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<Park>> Get(string natOrState, string name, string state, int rating)
    {
      var query = _db.Parks.AsQueryable();
      
      if (natOrState != null)
      {
        query = query.Where(entry => entry.NatOrState == natOrState);
      }

      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }

      if (state != null)
      {
        query = query.Where(entry => entry.State == state);
      }

      if (rating != null)
      {
        query = query.Where(entry => entry.Rating == rating);
      }

      

      return query.ToList();
    }

    [HttpPost]
    public async Task<ActionResult<Park>> Post(Park park)
    {
      _db.Parks.Add(park);
      await _db.SaveChangesAsync();

      return CreatedAtAction("Post", new { id = park.ParkId }, park);
    }
  }
}