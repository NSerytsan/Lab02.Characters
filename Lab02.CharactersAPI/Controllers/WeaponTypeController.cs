using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab02.CharactersAPI.Models;
using Lab02.CharactersAPI.Interfaces;

namespace Lab02.CharactersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeaponTypeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public WeaponTypeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/WeaponType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeaponType>>> GetWeaponTypes()
        {
            return await _unitOfWork.WeaponTypeRepository.GetAllAsync();
        }

        // GET: api/WeaponType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WeaponType>> GetWeaponType(int id)
        {
            var weaponType = await _unitOfWork.WeaponTypeRepository.GetAsync(id);

            if (weaponType == null)
            {
                return NotFound();
            }

            return weaponType;
        }

        // PUT: api/WeaponTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeaponType(int id, WeaponType weaponType)
        {
            if (id != weaponType.Id)
            {
                return BadRequest();
            }

            await _unitOfWork.WeaponTypeRepository.UpdateAsync(weaponType);

            try
            {
                await _unitOfWork.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await WeaponTypeExistsAsync(id))
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

        // POST: api/WeaponTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Weapon>> PostWeaponType(WeaponType weaponType)
        {
            await _unitOfWork.WeaponTypeRepository.AddAsync(weaponType);
            await _unitOfWork.SaveAsync();

            return CreatedAtAction("GetWeaponType", new { id = weaponType.Id }, weaponType);
        }

        // DELETE: api/WeaponTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeaponType(int id)
        {
            var weaponType = await _unitOfWork.WeaponTypeRepository.GetAsync(id);
            if (weaponType is null)
            {
                return NotFound();
            }

            await _unitOfWork.WeaponTypeRepository.DeleteAsync(id);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }

        private async Task<bool> WeaponTypeExistsAsync(int id)
        {
            return await _unitOfWork.WeaponTypeRepository.Exists(id);
        }
    }
}
