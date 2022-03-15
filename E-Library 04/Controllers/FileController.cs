using E_Library_04.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Library_04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize (Roles = "Admin")]
    public class FileController : ControllerBase
    {
        private readonly DataContext _context;

        public FileController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<FileManagement>>> GetResource()
        {
            return Ok(await _context.FileManagement.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<FileManagement>>> AddFile(FileManagement file)
        {
            _context.FileManagement.Add(file);
            await _context.SaveChangesAsync();

            return Ok(await _context.FileManagement.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<FileManagement>>> UpdateFile(FileManagement request)
        {
            var dbFile = await _context.FileManagement.FindAsync(request.fileID);
            if (dbFile == null)
                return BadRequest("File not found.");

            dbFile.file_name = request.file_name;

            await _context.SaveChangesAsync();

            return Ok(await _context.FileManagement.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<FileManagement>>> DeleteFile(int id)
        {
            var dbFile = await _context.FileManagement.FindAsync(id);
            if (dbFile == null)
                return BadRequest("File not found.");

            _context.FileManagement.Remove(dbFile);
            await _context.SaveChangesAsync();

            return Ok(await _context.FileManagement.ToListAsync());
        }
    }
}
