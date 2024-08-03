using AlsetLibrary;
using AlsetLibrary.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlsetWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResearchersApiController : ControllerBase
    {
        private readonly ContosoDbContext _context;

        public ResearchersApiController(ContosoDbContext context)
        {
            _context = context;
        }

        // GET: api/Researchers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResearcherRecord>>> GetResearchers()
        {
            List<ResearcherRecord> list = new List<ResearcherRecord>();  
            var results = _context.Researchers.Include(e => e.Magazines).ToList();
            foreach( var element in results)
            {
                ResearcherRecord researcher = new ResearcherRecord();
                researcher.Id = element.Id;
                researcher.Name = element.Name;
                researcher.LastName = element.LastName;
                researcher.Email = element.Email;
                researcher.MagazinesRecords = new List<MagazineRecord>();
                
                foreach(var item in element.Magazines)
                {
                    MagazineRecord magazine = new MagazineRecord();
                    magazine.Id = item.Id;
                    magazine.Title = item.Title;
                    magazine.FileUrl = item.FileUrl;
                    researcher.MagazinesRecords.Add(magazine);
                }
                list.Add(researcher);
            }
            return list;
        }
        // GET: api/Researchers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Researcher>> GetResearcher(int id)
        {
            var researcher = await _context.Researchers.FindAsync(id);

            if (researcher == null)
            {
                return NotFound();
            }

            return researcher;
        }

        // PUT: api/Researchers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResearcher(int id, Researcher researcher)
        {
            if (id != researcher.Id)
            {
                return BadRequest();
            }

            _context.Entry(researcher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResearcherExists(id))
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

        // POST: api/Researchers
        [HttpPost]
        public async Task<ActionResult<Researcher>> PostResearcher(Researcher researcher)
        {
            _context.Researchers.Add(researcher);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetResearcher), new { id = researcher.Id }, researcher);
        }

        // DELETE: api/Researchers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResearcher(int id)
        {
            var researcher = await _context.Researchers.FindAsync(id);
            if (researcher == null)
            {
                return NotFound();
            }

            _context.Researchers.Remove(researcher);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResearcherExists(int id)
        {
            return _context.Researchers.Any(e => e.Id == id);
        }
    }
}
