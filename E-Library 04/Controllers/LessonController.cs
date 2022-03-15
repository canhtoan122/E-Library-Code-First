using E_Library_04.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Library_04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin,Teacher")]
    public class LessonController : ControllerBase
    {

        private readonly DataContext _context;

        public LessonController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<LessionManagement>>> GetLession()
        {
            return Ok(await _context.LessionManagement.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<LessionManagement>>> AddLession(LessionManagement lession)
        {
            _context.LessionManagement.Add(lession);
            await _context.SaveChangesAsync();

            return Ok(await _context.LessionManagement.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<LessionManagement>>> UpdateLession(LessionManagement request)
        {
            var dbLession = await _context.LessionManagement.FindAsync(request.lessionID);
            if (dbLession == null)
                return BadRequest("Lession not found.");

            dbLession.lession_name = request.lession_name;
            dbLession.lession_description = request.lession_description;

            await _context.SaveChangesAsync();

            return Ok(await _context.LessionManagement.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<LessionManagement>>> DeleteLession(int id)
        {
            var dbLession = await _context.LessionManagement.FindAsync(id);
            if (dbLession == null)
                return BadRequest("Lession not found.");

            _context.LessionManagement.Remove(dbLession);
            await _context.SaveChangesAsync();

            return Ok(await _context.LessionManagement.ToListAsync());
        }
    }
}
