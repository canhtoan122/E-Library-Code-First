using E_Library_04.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Library_04.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin,Teacher")]
    public class ExamAndTestController : ControllerBase
    {
        private readonly DataContext _context;

        public ExamAndTestController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<ExamAndTestManagement>>> GetExamAndTest()
        {
            return Ok(await _context.ExamAndTestManagement.ToListAsync());
        }


        [HttpPost]
        public async Task<ActionResult<List<ExamAndTestManagement>>> AddExamAndTest(ExamAndTestManagement ExamAndTest)
        {
            _context.ExamAndTestManagement.Add(ExamAndTest);
            await _context.SaveChangesAsync();

            return Ok(await _context.ExamAndTestManagement.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<ExamAndTestManagement>>> UpdateExamAndTest(ExamAndTestManagement request)
        {
            var dbExamAndTest = await _context.ExamAndTestManagement.FindAsync(request.exam_and_test_ID);
            if (dbExamAndTest == null)
                return BadRequest("Exam and Test not found.");

            dbExamAndTest.exam_and_test_name = request.exam_and_test_name;
            dbExamAndTest.exam_and_test_description = request.exam_and_test_description;
            dbExamAndTest.exam_bank = request.exam_bank;
            dbExamAndTest.test_bank = request.test_bank;


            await _context.SaveChangesAsync();

            return Ok(await _context.ExamAndTestManagement.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ExamAndTestManagement>>> DeleteExamAndTest(int id)
        {
            var dbExamAndTest = await _context.ExamAndTestManagement.FindAsync(id);
            if (dbExamAndTest == null)
                return BadRequest("Exam and Test not found.");

            _context.ExamAndTestManagement.Remove(dbExamAndTest);
            await _context.SaveChangesAsync();

            return Ok(await _context.ExamAndTestManagement.ToListAsync());
        }
    }
}
