using E_Library_04.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Library_04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,Teacher")]
    public class NotificationController : ControllerBase
    {
        private readonly DataContext _context;

        public NotificationController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<NotificationManagement>>> GetNotification()
        {
            return Ok(await _context.NotificationManagement.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<NotificationManagement>>> AddNotification(NotificationManagement notification)
        {
            _context.NotificationManagement.Add(notification);
            await _context.SaveChangesAsync();

            return Ok(await _context.NotificationManagement.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<NotificationManagement>>> UpdateNotification(NotificationManagement request)
        {
            var dbNotification = await _context.NotificationManagement.FindAsync(request.notificationID);
            if (dbNotification == null)
                return BadRequest("Notification not found.");

            dbNotification.notification_name = request.notification_name;
            dbNotification.notification_description = request.notification_description;

            await _context.SaveChangesAsync();

            return Ok(await _context.NotificationManagement.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<NotificationManagement>>> DeleteNotification(int id)
        {
            var dbNotification = await _context.NotificationManagement.FindAsync(id);
            if (dbNotification == null)
                return BadRequest("Notification not found.");

            _context.NotificationManagement.Remove(dbNotification);
            await _context.SaveChangesAsync();

            return Ok(await _context.NotificationManagement.ToListAsync());
        }
    }
}
