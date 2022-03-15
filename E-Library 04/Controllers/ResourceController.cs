using E_Library_04.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Library_04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Teacher")]
    public class ResourceController : ControllerBase
    {
        private readonly DataContext _context;

        public ResourceController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<ResourceManagement>>> GetResource()
        {
            return Ok(await _context.ResourceManagement.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<ResourceManagement>>> AddResource(ResourceManagement resource)
        {
            _context.ResourceManagement.Add(resource);
            await _context.SaveChangesAsync();

            return Ok(await _context.ResourceManagement.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<ResourceManagement>>> UpdateResource(ResourceManagement request)
        {
            var dbResource = await _context.ResourceManagement.FindAsync(request.resourceID);
            if (dbResource == null)
                return BadRequest("Resource not found.");

            dbResource.resource_name = request.resource_name;
            dbResource.resource_description = request.resource_description;

            await _context.SaveChangesAsync();

            return Ok(await _context.ResourceManagement.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ResourceManagement>>> DeleteResource(int id)
        {
            var dbResource = await _context.ResourceManagement.FindAsync(id);
            if (dbResource == null)
                return BadRequest("Resource not found.");

            _context.ResourceManagement.Remove(dbResource);
            await _context.SaveChangesAsync();

            return Ok(await _context.ResourceManagement.ToListAsync());
        }
    }
}
