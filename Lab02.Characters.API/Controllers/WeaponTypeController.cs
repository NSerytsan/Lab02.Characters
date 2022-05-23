using Lab02.Characters.API.Data;
using Lab02.Characters.API.Entities;
using Lab02.Characters.API.Extensions;
using Lab02.Characters.Models.Dtos.WeaponType;
using Microsoft.AspNetCore.Mvc;

namespace Lab02.Characters.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeaponTypeController : ControllerBase
    {
        private readonly IWeaponTypeRepository _weaponTypeRepository;

        public WeaponTypeController(IWeaponTypeRepository weaponTypeRepository)
        {
            this._weaponTypeRepository = weaponTypeRepository;
        }

        // GET: api/WeaponType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeaponTypeDto>>> GetWeaponTypes()
        {
            var weaponTypes = await _weaponTypeRepository.GetAllAsync();

            return Ok(from weaponType in weaponTypes select weaponType.ToWeaponTypeDto());
        }

        // GET: api/WeaponType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WeaponTypeDto>> GetWeaponType(int id)
        {
            var weaponType = await _weaponTypeRepository.GetAsync(id);

            if (weaponType == null)
            {
                return NotFound();
            }

            return Ok(weaponType.ToWeaponTypeDto());
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

            var weaponType = await _weaponTypeRepository.GetAsync(id);

            if (weaponType == null)
            {
                return NotFound();
            }

            weaponType.Name = updateWeaponTypeDto.Name;

            await _weaponTypeRepository.UpdateAsync(weaponType);

            return NoContent();
        }

        // POST: api/WeaponType
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CreateWeaponTypeDto>> PostWeaponType(CreateWeaponTypeDto createWeaponTypeDto)
        {
            var weaponType = new WeaponType()
            {
                Name = createWeaponTypeDto.Name
            };

            await _weaponTypeRepository.AddAsync(weaponType);

            return CreatedAtAction("GetWeaponType", new { id = weaponType.Id }, new WeaponTypeDto { Id = weaponType.Id, Name = weaponType.Name });
        }

        // DELETE: api/WeaponType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeaponType(int id)
        {
            await _weaponTypeRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}
