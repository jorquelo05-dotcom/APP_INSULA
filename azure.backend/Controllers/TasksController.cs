using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using TerapiaApp.API.Data;
using TerapiaApp.API.Models;

namespace TerapiaApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TasksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TasksController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("patient/{patientId}")]
        public async Task<IActionResult> GetTasksForPatient(string patientId)
        {
            var tasks = await _context.TherapyTasks
                .Where(t => t.PatientId == patientId)
                .OrderBy(t => t.DueDate)
                .ToListAsync();

            return Ok(tasks);
        }

        // ... resto del código usando TherapyTask en lugar de Task
    }
}