using E_Library_04.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Library_04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class SystemController : ControllerBase
    {
        private readonly DataContext _context;

        public SystemController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<SystemManagement>>> GetResource()
        {
            return Ok(await _context.SystemManagement.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<SystemManagement>>> AddSystem(SystemManagement system)
        {
            _context.SystemManagement.Add(system);
            await _context.SaveChangesAsync();

            return Ok(await _context.SystemManagement.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<SystemManagement>>> UpdateSystem(SystemManagement request)
        {
            var dbSystem = await _context.SystemManagement.FindAsync(request.systemID);
            if (dbSystem == null)
                return BadRequest("System not found.");

            dbSystem.system_name = request.system_name;

            await _context.SaveChangesAsync();

            return Ok(await _context.SystemManagement.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SystemManagement>>> DeleteSystem(int id)
        {
            var dbSystem = await _context.SystemManagement.FindAsync(id);
            if (dbSystem == null)
                return BadRequest("System not found.");

            _context.SystemManagement.Remove(dbSystem);
            await _context.SaveChangesAsync();

            return Ok(await _context.SystemManagement.ToListAsync());
        }
    }
}
