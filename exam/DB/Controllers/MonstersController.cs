using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DB.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class MonsterController : ControllerBase
{
    private readonly MonstersContext _context;
    public MonsterController(MonstersContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<Monster?> GetById(int id) => await _context.Monsters.FindAsync(id);
    
    [HttpGet]
    public async Task<IEnumerable<Monster?>> GetAllMonsters() => await _context.Monsters.ToListAsync();

    [HttpGet]
    public async Task<Monster?> GetMonster()
    {
        var countAsync = await _context.Monsters.CountAsync();
        if (countAsync <= 0) return null;
        var randomizer = new Random((int) DateTime.Now.Ticks).Next(countAsync);
        return await _context.Monsters.Skip(randomizer).FirstOrDefaultAsync();
    }
}

/*public class MonstersController 
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
            dbHero.Place = request.Place;#1#

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
}*/