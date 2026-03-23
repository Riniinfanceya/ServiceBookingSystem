using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicebookingsystem.infrastructure.Data;

namespace ServiceBookingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HealthController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/health
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                // Simple DB connectivity check
                var canConnect = await _context.Database.CanConnectAsync();

                if (canConnect)
                {
                    return Ok(new
                    {
                        status = "Healthy ✅",
                        database = "Connected",
                        timestamp = DateTime.UtcNow
                    });
                }
                else
                {
                    return StatusCode(503, new
                    {
                        status = "Unhealthy ❌",
                        database = "Cannot connect",
                        timestamp = DateTime.UtcNow
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    status = "Error ⚠️",
                    message = ex.Message,
                    timestamp = DateTime.UtcNow
                });
            }
        }
    }
}

