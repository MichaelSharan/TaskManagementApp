using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagementApp.Data;
using TaskManagementApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace TaskManagementApp.Controllers
{
    [Route("api/[controller]")] // Указывает, что этот контроллер работает через "api/testresults"
    [ApiController] // Делает контроллер API-контроллером
    [Authorize]
    public class TestResultsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly CountNumberService countNumberService;

        public TestResultsController(ApplicationDbContext context, CountNumberService countNumberService)
        {
            _context = context;
            this.countNumberService = countNumberService;
        }

        // GET: api/testresults
        [HttpGet]
        public async Task<IActionResult> GetAllTestResults()
        {
            return Ok(await _context.TestResults.ToListAsync());
        }

        // GET: api/testresults/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTestResult(string id)
        {
            var testResult = await _context.TestResults.FindAsync(id);
            if (testResult == null)
            {
                return NotFound();
            }
            return Ok(testResult);
        }

        // POST: api/testresults
        [HttpPost]
        public async Task<IActionResult> CreateTestResult([FromBody] CreateTestResultRequest request)
        {
            if (request == null)
            {
                return BadRequest("Данные не переданы.");
            }

            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("Пользователь не авторизован.");
            }

            string output = countNumberService.CalculateLargestOddNumber(request.Input.ToString());

            var testResult = new TestResult
            {
                Id = Guid.NewGuid().ToString(),
                Input = request.Input,
                Output = output,
                UserId = userId
            };

            _context.TestResults.Add(testResult);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTestResult), new { id = testResult.Id }, testResult);
        }


        // DELETE: api/testresults/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteTestResult(string id)
        {
            var testResult = await _context.TestResults.FindAsync(id);
            if (testResult == null)
            {
                return NotFound();
            }

            _context.TestResults.Remove(testResult);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}