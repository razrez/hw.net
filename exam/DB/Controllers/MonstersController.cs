using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DB.Controllers;

public class MonstersController
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly MonstersContext _context;

        public SuperHeroController(MonstersContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Monster>>> Get()
        {
            return Ok(await _context.Monsters.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Monster>> Get(int id)
        {
            var hero = await _context.Monsters.FindAsync(id);
            if (hero == null)
                return BadRequest("Hero not found.");
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<Monster>>> AddHero(Monster hero)
        {
            _context.Monsters.Add(hero);
            await _context.SaveChangesAsync();

            return Ok(await _context.Monsters.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Monster>>> UpdateHero(Monster request)
        {
            var dbHero = await _context.Monsters.FindAsync(request.Name);
            if (dbHero == null)
                return BadRequest("Hero not found.");

            dbHero.DamageModifier = request.DamageModifier;
            /*dbHero.FirstName = request.FirstName;
            dbHero.LastName = request.LastName;
            dbHero.Place = request.Place;*/

            await _context.SaveChangesAsync();

            return Ok(await _context.Monsters.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Monster>>> Delete(int id)
        {
            var dbHero = await _context.Monsters.FindAsync(id);
            if (dbHero == null)
                return BadRequest("Hero not found.");

            _context.Monsters.Remove(dbHero);
            await _context.SaveChangesAsync();

            return Ok(await _context.Monsters.ToListAsync());
        }

    }
}