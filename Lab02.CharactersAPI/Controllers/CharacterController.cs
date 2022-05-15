using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab02.CharactersAPI.Data;
using Lab02.CharactersAPI.Models;
using Lab02.CharactersAPI.Dtos.Character;
using Lab02.CharactersAPI.Extensions;

namespace Lab02.CharactersAPI.Controllers
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
        public async Task<ActionResult<IEnumerable<GetCharacterDto>>> GetCharacters()
        {
            if (_context.Characters == null)
            {
                return NotFound();
            }
            var characters = await _context.Characters.Include(c => c.Skills).ToListAsync();

            return Ok(characters.ConvertToDto());
        }

        // GET: api/Character/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCharacterDto>> GetCharacter(int id)
        {
            if (_context.Characters == null)
            {
                return NotFound();
            }

            var character = await _context.Characters.Include(c => c.Skills).FirstOrDefaultAsync(c => c.Id == id);

            if (character == null)
            {
                return NotFound();
            }

            return Ok(character.ConvertToDto());
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

            var character = new Character()
            {
                Name = createCharacterDto.Name,
                HealthPoints = createCharacterDto.HealthPoints,
                Attack = createCharacterDto.Attack,
                Defense = createCharacterDto.Defense,
                WeaponId = createCharacterDto.WeaponId,
                Biography = createCharacterDto.Biography,
                Skills = new HashSet<Skill>()
            };

            foreach (var skillId in createCharacterDto.Skills)
            {
                var skill = await _context.Skills.FindAsync(skillId);
                if (skill != null)
                {
                    character.Skills.Add(skill);
                }
            }

            _context.Characters.Add(character);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCharacter", new { id = character.Id }, character);
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
