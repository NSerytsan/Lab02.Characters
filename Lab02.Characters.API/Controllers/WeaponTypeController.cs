using Lab02.Characters.API.Data;
using Lab02.Characters.API.Entities;
using Lab02.Characters.API.Extensions;
using Lab02.Characters.Models.Dtos.WeaponType;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab02.Characters.API.Controllers
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
        public async Task<ActionResult<IEnumerable<GetWeaponTypeDto>>> GetWeaponTypes()
        {
            if (_context.WeaponTypes == null)
            {
                return NotFound();
            }

            var weaponTypes = await _context.WeaponTypes.ToListAsync();

            return Ok(weaponTypes.ConvertToDto());
        }

        // GET: api/WeaponType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WeaponTypeDto>> GetWeaponType(int id)
        {
            if (_context.WeaponTypes == null)
            {
                return NotFound();
            }
            var weaponType = await _context.WeaponTypes.Include(wt => wt.Weapons).SingleOrDefaultAsync(wt => wt.Id == id);

            if (weaponType == null)
            {
                return NotFound();
            }

            return Ok(weaponType.ConvertToDto());
        }

        // PUT: api/WeaponType/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeaponType(int id, UpdateWeaponTypeDto updateWeaponTypeDto)
        {
            if (id != updateWeaponTypeDto.Id)
            {
                return BadRequest();
            }

            var weaponType = await _context.WeaponTypes.FindAsync(id);

            if (weaponType == null)
            {
                return NotFound();
            }

            weaponType.Name = updateWeaponTypeDto.Name;

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
        public async Task<ActionResult<CreateWeaponTypeDto>> PostWeaponType(CreateWeaponTypeDto createWeaponTypeDto)
        {
            if (_context.WeaponTypes == null)
            {
                return Problem("Entity set 'CharactersDbContext.WeaponTypes'  is null.");
            }

            var weaponType = new WeaponType()
            {
                Name = createWeaponTypeDto.Name
            };

            _context.WeaponTypes.Add(weaponType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWeaponType", new { id = weaponType.Id }, new WeaponTypeDto { Id = weaponType.Id, Name = weaponType.Name });
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
