using E_Library_04.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Library_04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Teacher")]
    public class HelpController : ControllerBase
    {
        private readonly DataContext _context;

        public HelpController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<HelpManagement>>> GetHelp()
        {
            return Ok(await _context.HelpManagement.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<HelpManagement>>> AddHelp(HelpManagement help)
        {
            _context.HelpManagement.Add(help);
            await _context.SaveChangesAsync();

            return Ok(await _context.HelpManagement.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<HelpManagement>>> UpdateHelp(HelpManagement request)
        {
            var dbHelp = await _context.HelpManagement.FindAsync(request.helpID);
            if (dbHelp == null)
                return BadRequest("Help not found.");

            dbHelp.help_name = request.help_name;
            dbHelp.help_description = request.help_description;

            await _context.SaveChangesAsync();

            return Ok(await _context.HelpManagement.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<HelpManagement>>> DeleteHelp(int id)
        {
            var dbHelp = await _context.HelpManagement.FindAsync(id);
            if (dbHelp == null)
                return BadRequest("Help not found.");

            _context.HelpManagement.Remove(dbHelp);
            await _context.SaveChangesAsync();

            return Ok(await _context.HelpManagement.ToListAsync());
        }
    }
}
