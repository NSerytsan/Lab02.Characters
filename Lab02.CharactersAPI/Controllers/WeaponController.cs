using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab02.CharactersAPI.Data;
using Lab02.CharactersAPI.Models;
using Lab02.CharactersAPI.Dtos.Weapon;
using Lab02.CharactersAPI.Dtos.WeaponType;

namespace Lab02.CharactersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeaponController : ControllerBase
    {
        private readonly CharactersDbContext _context;

        public WeaponController(CharactersDbContext context)
        {
            _context = context;
        }

        // GET: api/Weapon
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetWeaponDto>>> GetWeapons()
        {
            if (_context.Weapons == null)
            {
                return NotFound();
            }

            var weapons = await _context.Weapons.ToListAsync();
            var weaponDtos = from weapon in weapons
                             select new GetWeaponDto
                             {
                                 Id = weapon.Id,
                                 Name = weapon.Name,
                                 Attack = weapon.Attack,
                                 WeaponTypeId = weapon.WeaponTypeId
                             };

            return Ok(weaponDtos);
        }

        // GET: api/Weapon/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WeaponDto>> GetWeapon(int id)
        {
            if (_context.Weapons == null)
            {
                return NotFound();
            }

            var weapon = await _context.Weapons.Include(w => w.WeaponType).FirstOrDefaultAsync(w => w.Id == id);

            if (weapon == null)
            {
                return NotFound();
            }

            var weaponType = new GetWeaponTypeDto()
            {
                Id = weapon.WeaponType.Id,
                Name = weapon.WeaponType.Name
            };

            var weaponDto = new WeaponDto()
            {
                Id = weapon.Id,
                Name = weapon.Name,
                Attack = weapon.Attack,
                WeaponTypeId = weapon.WeaponTypeId,
                WeaponType = weaponType
            };

            return Ok(weaponDto);
        }

        // PUT: api/Weapon/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeapon(int id, UpdateWeaponDto updateWeaponDto)
        {
            if (id != updateWeaponDto.Id)
            {
                return BadRequest();
            }

            var weapon = await _context.Weapons.FindAsync(id);
            if (weapon == null)
            {
                return NotFound();
            }

            weapon.Name = updateWeaponDto.Name;
            weapon.Attack = updateWeaponDto.Attack;
            weapon.WeaponTypeId = updateWeaponDto.WeaponTypeId;

            _context.Update(weapon);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeaponExists(id))
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

        // POST: api/Weapon
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CreateWeaponDto>> PostWeapon(CreateWeaponDto createWeaponDto)
        {
            if (_context.Weapons == null)
            {
                return Problem("Entity set 'CharactersDbContext.Weapons'  is null.");
            }

            var weapon = new Weapon()
            {
                Name = createWeaponDto.Name,
                Attack = createWeaponDto.Attack,
                WeaponTypeId = createWeaponDto.WeaponTypeId
            };

            _context.Weapons.Add(weapon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWeapon", new { id = weapon.Id }, new WeaponDto { Id = weapon.Id, Name = weapon.Name, Attack = weapon.Attack });
        }

        // DELETE: api/Weapon/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeapon(int id)
        {
            if (_context.Weapons == null)
            {
                return NotFound();
            }
            var weapon = await _context.Weapons.FindAsync(id);
            if (weapon == null)
            {
                return NotFound();
            }

            _context.Weapons.Remove(weapon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WeaponExists(int id)
        {
            return (_context.Weapons?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
