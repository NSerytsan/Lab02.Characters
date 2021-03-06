using Lab02.Characters.API.Data;
using Lab02.Characters.API.Entities;
using Lab02.Characters.API.Extensions;
using Lab02.Characters.Models.Dtos.Skill;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab02.Characters.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly CharactersDbContext _context;

        public SkillController(CharactersDbContext context)
        {
            _context = context;
        }

        // GET: api/Skill
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SkillDto>>> GetSkills()
        {
            if (_context.Skills == null)
            {
                return NotFound();
            }

            var skills = await _context.Skills.Include(s => s.Characters).ThenInclude(c => c.Weapon).ToListAsync();

            return Ok(skills.ToSkillDtos());
        }

        // GET: api/Skill/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SkillDto>> GetSkill(int id)
        {
            if (_context.Skills == null)
            {
                return NotFound();
            }

            var skill = await _context.Skills.Include(s => s.Characters).ThenInclude(c => c.Weapon).FirstOrDefaultAsync(s => s.Id == id);

            if (skill == null)
            {
                return NotFound();
            }

            return skill.ToSkillDto();
        }

        // PUT: api/Skill/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSkill(int id, UpdateSkillDto updateSkillDto)
        {
            if (id != updateSkillDto.Id)
            {
                return BadRequest();
            }

            var skill = await _context.Skills.FindAsync(id);

            if (skill == null)
            {
                return NotFound();
            }

            skill.Name = updateSkillDto.Name;
            skill.Description = updateSkillDto.Description;

            _context.Update(skill);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkillExists(id))
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

        // POST: api/Skill
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CreateSkillDto>> PostSkill(CreateSkillDto createSkillDto)
        {
            if (_context.Skills == null)
            {
                return Problem("Entity set 'CharactersDbContext.Skills'  is null.");
            }

            var skill = new Skill()
            {
                Name = createSkillDto.Name,
                Description = createSkillDto.Description
            };

            _context.Skills.Add(skill);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSkill", new { id = skill.Id }, new GetSkillDto() { Id = skill.Id, Name = skill.Name, Description = skill.Description });
        }

        // DELETE: api/Skill/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkill(int id)
        {
            if (_context.Skills == null)
            {
                return NotFound();
            }
            var skill = await _context.Skills.FindAsync(id);
            if (skill == null)
            {
                return NotFound();
            }

            _context.Skills.Remove(skill);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SkillExists(int id)
        {
            return (_context.Skills?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
