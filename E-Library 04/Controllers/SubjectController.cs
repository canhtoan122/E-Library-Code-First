using E_Library_04.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Library_04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,Teacher")]
    public class SubjectController : ControllerBase
    {
        private readonly DataContext _context;

        public SubjectController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SubjectManagement>>> GetSubject()
        {
            return Ok(await _context.SubjectManagement.ToListAsync());
        }


        [HttpPost]
        public async Task<ActionResult<List<SubjectManagement>>> AddSubject(SubjectManagement subject)
        {
            _context.SubjectManagement.Add(subject);
            await _context.SaveChangesAsync();

            return Ok(await _context.SubjectManagement.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<SubjectManagement>>> UpdateSubject(SubjectManagement request)
        {
            var dbSubject = await _context.SubjectManagement.FindAsync(request.subjectID);
            if (dbSubject == null)
                return BadRequest("Subject not found.");

            dbSubject.subject_name = request.subject_name;
            dbSubject.subject_description = request.subject_description;

            await _context.SaveChangesAsync();

            return Ok(await _context.SubjectManagement.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SubjectManagement>>> DeleteSubject(int id)
        {
            var dbSubject = await _context.SubjectManagement.FindAsync(id);
            if (dbSubject == null)
                return BadRequest("Subject not found.");

            _context.SubjectManagement.Remove(dbSubject);
            await _context.SaveChangesAsync();

            return Ok(await _context.SubjectManagement.ToListAsync());
        }
    }
}
