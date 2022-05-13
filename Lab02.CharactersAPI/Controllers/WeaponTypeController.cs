using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab02.CharactersAPI.Models;
using Lab02.CharactersAPI.Interfaces;
using AutoMapper;
using Lab02.CharactersAPI.Dtos.WeaponTypes;

namespace Lab02.CharactersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeaponTypeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WeaponTypeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/WeaponType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetWeaponTypeDto>>> GetWeaponTypes()
        {
            var weaponTypes = await _unitOfWork.WeaponTypeRepository.GetAllAsync();
            var records = _mapper.Map<List<GetWeaponTypeDto>>(weaponTypes);
            return Ok(records);
        }

        // GET: api/WeaponType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WeaponTypeDto>> GetWeaponType(int id)
        {
            var weaponType = await _unitOfWork.WeaponTypeRepository.GetDetailsAsync(id);

            if (weaponType == null)
            {
                return NotFound();
            }
            var weaponTypeDto = _mapper.Map<WeaponTypeDto>(weaponType);
            return Ok(weaponTypeDto);
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

            _unitOfWork.WeaponTypeRepository.Update(weaponType);

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
        public async Task<ActionResult<Weapon>> PostWeaponType(CreateWeaponTypeDto createWeaponTypeDto)
        {
            var weaponType = _mapper.Map<WeaponType>(createWeaponTypeDto);
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
