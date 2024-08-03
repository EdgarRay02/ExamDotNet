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
    public class MagazinesApiController : ControllerBase
    {
        private readonly ContosoDbContext _context;

        public MagazinesApiController(ContosoDbContext context)
        {
            _context = context;
        }

        // GET: api/Magazines/5
        [HttpGet("{id}")]

        public async Task<ActionResult<MagazineRecord>> GetMagazineById(int id)
        {
            var match = _context.Magazines.FirstOrDefault(e => e.Id == id);

            MagazineRecord magazine = new MagazineRecord();
            magazine.Id = match.Id;
            magazine.Title = match.Title;
            magazine.FileUrl = match.FileUrl;
            return magazine;
        }


        // GET: api/Magazines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Magazine>>> GetMagazines()
        {
            return await _context.Magazines.ToListAsync();
        }

        

        // PUT: api/Magazines/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRevista(int id, Magazine magazine)
        {
            if (id != magazine.Id)
            {
                return BadRequest();
            }

            _context.Entry(magazine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RevistaExists(id))
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


        [HttpPost("Upload")]
        public async Task<IActionResult> Upload(UploadJornal dto)
        {
            Researcher researcher = new Researcher();

            var result = _context.Researchers.FirstOrDefault(e => e.Email == dto.Email);
            if(result != null)
            {
                researcher = result;
            }
            
            Magazine magazine = new Magazine();
            researcher.Name = dto.Name;
            researcher.Email = dto.Email;
            researcher.LastName = dto.LastName;
            if(researcher.Magazines == null)
            {
                researcher.Magazines = new List<Magazine>();
            }
            magazine.FileUrl = dto.FilePath;
            magazine.Title = dto.Title;
            researcher.Magazines.Add(magazine);
            if(researcher == null)
            {
                _context.Researchers.Add(researcher);
            }
            else
            {
                _context.Researchers.Update(researcher);
            }
            
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                var s = ex.Message;
            }
            return Ok();
        }

        // DELETE: api/Magazines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletemMagazine(int id)
        {
            var magazine = await _context.Magazines.FindAsync(id);
            if (magazine == null)
            {
                return NotFound();
            }

            _context.Magazines.Remove(magazine);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RevistaExists(int id)
        {
            return _context.Magazines.Any(e => e.Id == id);
        }


    }
}
