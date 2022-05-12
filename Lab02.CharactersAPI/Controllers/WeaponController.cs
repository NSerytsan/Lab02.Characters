using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab02.CharactersAPI.Data;
using Lab02.CharactersAPI.Models;

namespace Lab02.CharactersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeaponsController : ControllerBase
    {
        private readonly UnitOfWork _uow;

        public WeaponsController(UnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Weapon
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Weapon>>> GetWeapons()
        {
            return await _uow.WeaponRepository.GetAllAsync();
        }

        // GET: api/Weapon/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Weapon>> GetWeapon(int id)
        {
            var weapon = await _uow.WeaponRepository.GetAsync(id);

            if (weapon == null)
            {
                return NotFound();
            }

            return weapon;
        }

        // PUT: api/Weapon/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeapon(int id, Weapon weapon)
        {
            if (id != weapon.Id)
            {
                return BadRequest();
            }

            await _uow.WeaponRepository.UpdateAsync(weapon);
            try
            {
                await _uow.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                bool exists = await WeaponExists(id);
                if (!exists)
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
        public async Task<ActionResult<Weapon>> PostWeapon(Weapon weapon)
        {
            await _uow.WeaponRepository.AddSync(weapon);
            await _uow.SaveAsync();

            return CreatedAtAction("GetWeapon", new { id = weapon.Id }, weapon);
        }

        // DELETE: api/Weapon/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeapon(int id)
        {
            await _uow.WeaponRepository.DeleteAsync(id);
            await _uow.SaveAsync();

            return NoContent();
        }

        private async Task<bool> WeaponExists(int id)
        {
            return await _uow.WeaponRepository.Exists(id);
        }
    }
}