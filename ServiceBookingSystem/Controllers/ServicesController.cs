using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Servicebookingsystem.core.Entities;
using Servicebookingsystem.services.Interfaces;

namespace ServiceBookingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServicesController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        // 🔓 Public: anyone can view services
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Service>>> GetServices() =>
            Ok(await _serviceService.GetServicesAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> GetService(int id)
        {
            var service = await _serviceService.GetServiceByIdAsync(id);
            if (service == null) return NotFound();
            return Ok(service);
        }

        // 🔒 Only Admins can create services
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> CreateService(Service service)
        {
            await _serviceService.AddServiceAsync(service);
            return CreatedAtAction(nameof(GetService), new { id = service.ServiceId }, service);
        }

        // 🔒 Only Admins can update services
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateService(int id, Service service)
        {
            if (id != service.ServiceId) return BadRequest();
            await _serviceService.UpdateServiceAsync(service);
            return NoContent();
        }

        // 🔒 Only Admins can delete services
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteService(int id)
        {
            var service = await _serviceService.GetServiceByIdAsync(id);
            if (service == null) return NotFound();
            await _serviceService.DeleteServiceAsync(service);
            return NoContent();
        }
    }
}
