using E_Library_04.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Library_04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly DataContext _context;

        public AdminController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Admin>>> GetAdmin()
        {
            return Ok(await _context.Admin.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Admin>>> AddAdmin(Admin admin)
        {
            _context.Admin.Add(admin);
            await _context.SaveChangesAsync();

            return Ok(await _context.Admin.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Admin>>> UpdateAdmin(Admin request)
        {
            var dbAdmin = await _context.Admin.FindAsync(request.adminID);
            if (dbAdmin == null)
                return BadRequest("Admin not found.");

            dbAdmin.admin_name = request.admin_name;

            await _context.SaveChangesAsync();

            return Ok(await _context.Admin.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Admin>>> DeleteAdmin(int id)
        {
            var dbAdmin = await _context.Admin.FindAsync(id);
            if (dbAdmin == null)
                return BadRequest("Admin not found.");

            _context.Admin.Remove(dbAdmin);
            await _context.SaveChangesAsync();

            return Ok(await _context.Admin.ToListAsync());
        }
    }
}
