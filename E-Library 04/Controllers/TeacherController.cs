using E_Library_04.Model;
using IdentityServer3.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace E_Library_04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly DataContext _context;
       

        public TeacherController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Teacher>>> GetTeacher()
        {
            return Ok(await _context.Teacher.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Teacher>>> AddTeacher(Teacher teacher)
        {
            _context.Teacher.Add(teacher);
            await _context.SaveChangesAsync();

            return Ok(await _context.Teacher.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Teacher>>> UpdateTeacher(Teacher request)
        {
            var dbTeacher = await _context.Teacher.FindAsync(request.teacherID);
            if (dbTeacher == null)
                return BadRequest("Teacher not found.");

            dbTeacher.teacher_name = request.teacher_name;

            await _context.SaveChangesAsync();

            return Ok(await _context.Teacher.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Teacher>>> DeleteTeacher(int id)
        {
            var dbTeacher = await _context.Teacher.FindAsync(id);
            if (dbTeacher == null)
                return BadRequest("Teacher not found.");

            _context.Teacher.Remove(dbTeacher);
            await _context.SaveChangesAsync();

            return Ok(await _context.Teacher.ToListAsync());
        }
    }
}

