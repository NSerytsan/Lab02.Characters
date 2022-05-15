using Lab02.Characters.API.Data;
using Lab02.Characters.API.Entities;
using Lab02.Characters.API.Extensions;
using Lab02.Characters.Models.Dtos.Character;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab02.Characters.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly CharactersDbContext _context;

        public CharacterController(CharactersDbContext context)
        {
            _context = context;
        }

        // GET: api/Character
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterDto>>> GetCharacters()
        {
            if (_context.Characters == null)
            {
                return NotFound();
            }

            var characters = await _context.Characters.Include(c => c.Skills).Include(c => c.Weapon).ThenInclude(w => w.WeaponType).ToListAsync();

            return Ok(characters.ToCharacterDtos());
        }

        // GET: api/Character/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterDto>> GetCharacter(int id)
        {
            if (_context.Characters == null)
            {
                return NotFound();
            }

            var character = await _context.Characters.Include(c => c.Skills).Include(c => c.Weapon).ThenInclude(w => w.WeaponType).FirstOrDefaultAsync(c => c.Id == id);

            if (character == null)
            {
                return NotFound();
            }

            return Ok(character.ToCharacterDto());
        }

        // PUT: api/Character/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(int id, Character character)
        {
            if (id != character.Id)
            {
                return BadRequest();
            }

            _context.Entry(character).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterExists(id))
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

        // POST: api/Character
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CreateCharacterDto>> PostCharacter(CreateCharacterDto createCharacterDto)
        {
            if (_context.Characters == null)
            {
                return Problem("Entity set 'CharactersDbContext.Characters'  is null.");
            }

            var character = createCharacterDto.FromCreateCharacterDto(_context.Skills);

            _context.Characters.Add(character);
            await _context.SaveChangesAsync();

            CharacterDto responseDto = character.ToCharacterDto();

            return CreatedAtAction("GetCharacter", new { id = responseDto.Id }, responseDto);
        }

        // DELETE: api/Character/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            if (_context.Characters == null)
            {
                return NotFound();
            }
            var character = await _context.Characters.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }

            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CharacterExists(int id)
        {
            return (_context.Characters?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
