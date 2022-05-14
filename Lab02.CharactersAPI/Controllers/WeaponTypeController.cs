using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab02.CharactersAPI.Data;
using Lab02.CharactersAPI.Models;

namespace Lab02.CharactersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeaponTypeController : ControllerBase
    {
        private readonly CharactersDbContext _context;

        public WeaponTypeController(CharactersDbContext context)
        {
            _context = context;
        }

        // GET: api/WeaponType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeaponType>>> GetWeaponTypes()
        {
          if (_context.WeaponTypes == null)
          {
              return NotFound();
          }
            return await _context.WeaponTypes.ToListAsync();
        }

        // GET: api/WeaponType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WeaponType>> GetWeaponType(int id)
        {
          if (_context.WeaponTypes == null)
          {
              return NotFound();
          }
            var weaponType = await _context.WeaponTypes.FindAsync(id);

            if (weaponType == null)
            {
                return NotFound();
            }

            return weaponType;
        }

        // PUT: api/WeaponType/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeaponType(int id, WeaponType weaponType)
        {
            if (id != weaponType.Id)
            {
                return BadRequest();
            }

            _context.Entry(weaponType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeaponTypeExists(id))
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

        // POST: api/WeaponType
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WeaponType>> PostWeaponType(WeaponType weaponType)
        {
          if (_context.WeaponTypes == null)
          {
              return Problem("Entity set 'CharactersDbContext.WeaponTypes'  is null.");
          }
            _context.WeaponTypes.Add(weaponType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWeaponType", new { id = weaponType.Id }, weaponType);
        }

        // DELETE: api/WeaponType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeaponType(int id)
        {
            if (_context.WeaponTypes == null)
            {
                return NotFound();
            }
            var weaponType = await _context.WeaponTypes.FindAsync(id);
            if (weaponType == null)
            {
                return NotFound();
            }

            _context.WeaponTypes.Remove(weaponType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WeaponTypeExists(int id)
        {
            return (_context.WeaponTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
