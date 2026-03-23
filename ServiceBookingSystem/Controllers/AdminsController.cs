using Microsoft.AspNetCore.Mvc;
using Servicebookingsystem.core.Entities;
using Servicebookingsystem.services.Interfaces;

namespace ServiceBookingSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminsController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminsController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Admin>>> GetAdmins() =>
            Ok(await _adminService.GetAdminsAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<Admin>> GetAdmin(int id)
        {
            var admin = await _adminService.GetAdminByIdAsync(id);
            if (admin == null) return NotFound();
            return Ok(admin);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAdmin(Admin admin)
        {
            await _adminService.AddAdminAsync(admin);
            return CreatedAtAction(nameof(GetAdmin), new { id = admin.AdminId }, admin);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAdmin(int id, Admin admin)
        {
            if (id != admin.AdminId) return BadRequest();
            await _adminService.UpdateAdminAsync(admin);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAdmin(int id)
        {
            var admin = await _adminService.GetAdminByIdAsync(id);
            if (admin == null) return NotFound();
            await _adminService.DeleteAdminAsync(admin);
            return NoContent();
        }
    }
}
